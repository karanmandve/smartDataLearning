using ControllerExample.Controllers;

namespace ControllerExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // SPECIFYING PERTICULAR CONTROLLER
            //builder.Services.AddTransient<HomeController>();

            // ADDING ALL CONTROLLERS
            builder.Services.AddControllers();

            var app = builder.Build();
            app.UseStaticFiles();
            // DIRECTLY ADD USE ROUTING AND ALL ENDPOINTS
            app.MapControllers();

            //app.UseRouting();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //};

            app.Run();
        }
    }
}
