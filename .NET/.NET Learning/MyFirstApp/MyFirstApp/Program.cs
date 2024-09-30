using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.Run(async (HttpContext context) =>
{

    // CALCULATOR PROJECT

    //if (context.Request.Method == "GET")
    //{
    //    bool isFirstName = int.TryParse(context.Request.Query["firstNumber"], out var firstNumber);
    //    bool isSecondName = int.TryParse(context.Request.Query["secondNumber"], out var secondNumber);
    //    //var secondNumber = Convert.ToInt32(context.Request.Query["secondNumber"]);
    //    var operation = context.Request.Query["operation"].ToString();


    //    if (operation == "" || isFirstName == false || isSecondName == false)
    //    {
    //        context.Response.StatusCode = 400;
    //        await context.Response.WriteAsync("Invalid Input");
    //    }
    //    else
    //    {

    //        switch (operation.ToLower())
    //        {
    //            case "add":
    //                {
    //                    var result = firstNumber + secondNumber;
    //                    await context.Response.WriteAsync($"{result}");
    //                    break;
    //                }

    //            case "sub":
    //                {
    //                    var result = firstNumber - secondNumber;
    //                    await context.Response.WriteAsync($"{result}");
    //                    break;
    //                }

    //            case "multiply":
    //                {
    //                    var result = firstNumber * secondNumber;
    //                    await context.Response.WriteAsync($"{result}");
    //                    break;
    //                }

    //            case "div":
    //                {
    //                    var result = firstNumber / secondNumber;
    //                    await context.Response.WriteAsync($"{result}");
    //                    break;
    //                }

    //            case "mod":
    //                {
    //                    var result = firstNumber % secondNumber;
    //                    await context.Response.WriteAsync($"{result}");
    //                    break;
    //                }
    //            default:
    //                {
    //                    context.Response.StatusCode = 200;
    //                    await context.Response.WriteAsync($"Invalid input for 'operation'");
    //                    break;
    //                }

    //        }

    //    }





    //}





    // BODY
    if (context.Request.Method == "GET")
    {
        var reader = new StreamReader(context.Request.Body);
        string bodyData = await reader.ReadToEndAsync();
        var data = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(bodyData);
        await context.Response.WriteAsync(data["name"]);
    }





    // QUERY STRING
    //if (context.Request.Method == "GET")
    //{
    //    if (context.Request.Query.ContainsKey("id"))
    //    {
    //        string id = context.Request.Query["id"];
    //        await context.Response.WriteAsync($"<h1>{id}</h1>");
    //    }
    //}

    //if (context.Request.Headers.ContainsKey("User-Agent"))
    //{
    //    string userAgent = context.Request.Headers["User-Agent"];
    //    string responseContent = $"<h1>{userAgent}</h1>";
    //    await context.Response.WriteAsync(responseContent);
    //}

    //if (context.Request.Headers.ContainsKey("AuthKey"))
    //{
    //    string authKey = context.Request.Headers["AuthKey"];
    //    string responseContent = $"<h1>{authKey}</h1>";
    //    await context.Response.WriteAsync(responseContent);
    //}



    // REQUEST
    //string path = context.Request.Path;
    //string method = context.Request.Method;


    // RESPONSE
    //context.Response.Headers["MyKey"] = "hello";
    //context.Response.Headers["Server"] = "hello";
    //context.Response.Headers["Content-Type"] = "text/html";
    //context.Response.StatusCode = 200;
    //await context.Response.WriteAsync("<h1>Hello World!!</h1>");
    //await context.Response.WriteAsync($"<h1>{path}</h1>");
    //await context.Response.WriteAsync($"<h1>{method}</h1>");




});

app.Run();
