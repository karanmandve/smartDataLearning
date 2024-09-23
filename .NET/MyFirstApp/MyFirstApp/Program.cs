var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.Run(async (HttpContext context) =>
{
    // QUERY STRING
    if (context.Request.Method == "GET")
    {
        if (context.Request.Query.ContainsKey("id"))
        {
            string id = context.Request.Query["id"];
            await context.Response.WriteAsync($"<h1>{id}</h1>");
        }
    }


    // REQUEST
    string path = context.Request.Path;
    string method = context.Request.Method;


    // RESPONSE
    context.Response.Headers["MyKey"] = "hello";
    context.Response.Headers["Server"] = "hello";
    context.Response.Headers["Content-Type"] = "text/html";
    context.Response.StatusCode = 200;
    await context.Response.WriteAsync("<h1>Hello World!!</h1>");
    await context.Response.WriteAsync($"<h1>{path}</h1>");
    await context.Response.WriteAsync($"<h1>{method}</h1>");




});

app.Run();
