using RoutingExample.CustomeConstraints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting(option =>
{
    option.ConstraintMap.Add("months", typeof(MonthCustomConstraint));
});
var app = builder.Build();
app.UseStaticFiles();
// enable routing
app.UseRouting();

// creating endpoints
app.UseEndpoints(endpoints =>
{

    // ADD YOUR ENDPOINTS HERE

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
    //endpoints.Map("files/{filename}.{extension}", async (context) =>
    //{
    //    var fileName = context.Request.RouteValues["filename"].ToString();
    //    var extension = context.Request.RouteValues["extension"].ToString();
    //    await context.Response.WriteAsync($"at file {fileName} and extension is {extension}");
    //});


    // DEFAULT PARAMETER
    //endpoints.Map("employee/profile/{employeeName=John}", async (context) =>
    //{
    //    var employeeName = context.Request.RouteValues["employeeName"].ToString();
    //    await context.Response.WriteAsync($"Emplyee Name is {employeeName}");
    //});


    //OPTIONAL PARAMETER
    //endpoints.Map("product/{id?}", async (context) =>
    //{
    //    if (context.Request.RouteValues.ContainsKey("id"))
    //    {

    //    var id = Convert.ToInt32(context.Request.RouteValues["id"]);
    //    await context.Response.WriteAsync($"Product id is: {id}");
    //    }
    //    else
    //    {
    //        context.Response.WriteAsync("id not pass");
    //    }
    //});



    // CONSTRAINT
    //endpoints.Map("product/{id:long?}", async (context) =>
    //{
    //    if (context.Request.RouteValues.ContainsKey("id"))
    //    {

    //        var id = Convert.ToInt64(context.Request.RouteValues["id"]);
    //        await context.Response.WriteAsync($"Product id is: {id}");
    //    }
    //    else
    //    {
    //        context.Response.WriteAsync("id not pass");
    //    }
    //});



    // CUSTOME CONSTRAINTS
    endpoints.Map("sales-report/{month:months?}", async (context) =>
    {
        
        if (context.Request.RouteValues.ContainsKey("month"))
        {

            var month = Convert.ToString(context.Request.RouteValues["month"]);
            await context.Response.WriteAsync($"month is: {month}");
        }
        else
        {
            context.Response.WriteAsync("month not pass");
        }
    });



});


app.Run(async context =>
{
    await context.Response.WriteAsync($"Received request at : {context.Request.Path}");
});


app.Run();
