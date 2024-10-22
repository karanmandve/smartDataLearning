using StockAppApiFetchExample.ServiceContracts;
using StockAppApiFetchExample.Services;

namespace StockAppApiFetchExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient();

            builder.Services.AddScoped<IFinnhubService, FinnhubService>();


            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllers();

            app.Run();
        }
    }
}
