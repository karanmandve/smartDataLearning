var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// enable routing
app.UseRouting();

// creating endpoints
app.UseEndpoints(endpoints =>
{

    // add your endpoints here

    // execute for all the http verbs
    //endpoints.MapGet("map1", async (context) =>
    //{
    //    await context.Response.WriteAsync("<h1>Get Request !!</h1>");
    //});

    //endpoints.MapPost("map2", async (context) =>
    //{
    //    await context.Response.WriteAsync("<h1>Post Request !!</h1>");
    //});

    // incase-sensetive route parameter
    endpoints.Map("files/{filename}.{extension}", async (context) =>
    {
        var fileName = context.Request.RouteValues["filename"].ToString();
        var extension = context.Request.RouteValues["extension"].ToString();
        await context.Response.WriteAsync($"at file {fileName} and extension is {extension}");
    });



});


app.Run(async context =>
{
    await context.Response.WriteAsync($"Received request at : {context.Request.Path}");
});


app.Run();
