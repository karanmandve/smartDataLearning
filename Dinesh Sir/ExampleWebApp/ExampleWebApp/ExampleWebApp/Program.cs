using App.Core;
using ExampleWebApp.Filters;
using ExampleWebApp.Hubs;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace ExampleWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            // Serilog bootstrap configuration 
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateBootstrapLogger();

            builder.Host.UseSerilog();

            // Add services to the container.
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(configuration);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Test",
                    builder => builder
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .WithOrigins("http://localhost:4200")
                    );
            });

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<AppExceptionFilterAttribute>();
            });

            builder.Services.AddSignalR();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("Test");


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            app.MapHub<ChatHub>("/chathub");

            //app.UseCors(opt => {
            //    opt.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");
            //});
            
            app.Run();
        }
    }
}
