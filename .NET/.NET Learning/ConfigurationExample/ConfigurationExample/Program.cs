using ConfigurationExample;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//SUPPLY OBJECT OF WEATHERAPI SECTION AS A SERVICE
builder.Services.Configure<WeatherApiOptions>(builder.Configuration.GetSection("WeatherApi"));

// LOAD MYCONFIG.JSON
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("MyOwnConfig.json", optional: true, reloadOnChange: true);
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.Map("/config", async context =>
    {
        // NOT A CASE SENSETIVE
        var value = app.Configuration["MyKey"];
        await context.Response.WriteAsync(value);
    });
});

app.MapControllers();

app.Run();
