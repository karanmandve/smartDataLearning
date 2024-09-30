using MiddlewareExample.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<MyCustomMiddleware>();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

// middleware 1 using lambda expression
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("<h1>Middleware 1");
    next(context);
});

// middleware 2
app.UseMiddleware<MyCustomMiddleware>();




// middleware 3
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync(" Middleware 3 !!</h1>");
});

app.Run();
