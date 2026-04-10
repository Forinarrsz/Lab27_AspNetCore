using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    var method = context.Request.Method;
    var path = context.Request.Path;
    Console.WriteLine($"-> {method} {path}");
    await next(context);

    
});



app.MapGet("/", () => Results.Ok(new {
    Message = "Welcome",
    version = "1.0",
    Time = DateTime.Now.ToString("HH:mm:ss")
}));

app.MapGet("/me", () => Results.Ok(new
{
    Name = "Alina Shuvalova",
    Group = "ISP-231",
    Course = 3,
    Skills = new[] { "C#", "HTML", "CSS" }
}));

app.MapGet("/calc/{a}/{b}", (double a, double b) =>
Results.Ok(new {
    A = a,
    B = b,
    Sum = a + b,
    Diff = a - b,
    Mul = a * b,
    Div = b != 0 ? a / b : 0
}));
app.MapFallback(() => Results.NotFound(new {
    Error = "path not found",
    Code = 404
}));

app.Run();
// record Product(int Id, string Name, decimal Price, bool InStock);
//middleware
// app.Use(async (context, next) =>
// {
//     Console.WriteLine($"[LOG] {context.Request.Method} {context.Request.Path}");
//     await next(context);
//     Console.WriteLine($"[LOG] ANSWER SEND {context.Response.StatusCode}");
// });

// // app.Use(async (context, next) =>
// // {
// //     var key = context.Request.Query["key"];
// //     if (key != "secret")
// //     {
// //         return context.Response.StatusCode;
// //     }
// // });


// app.Use(async (context, next) =>
// {
//     context.Response.Headers.Append("X-powered-By", "ASP.NET Core Lab27");
//     await next(context);
// });

// // app.Use(async (context, next) =>
// // {
// //     Console.WriteLine($"[LOG] {context.Request.Method} {context.Request.Path}");
// //     await next(context);
// //     Console.WriteLine($"[LOG] Ответ отправлен: {context.Response.StatusCode}");

// // });

// // app.Use(async (context, next) =>
// // {
// //     context.Response.Headers.Append("X-powered=By", "ASP.NET Core lab 27");
// //     await next(context);
// // });
// //1
// app.MapGet("/", () => "welcome to server!");
// //2
// app.MapGet("/about", () => "it`s my 1st ASP.NET Core Server");
// //3
// app.MapGet("/time", () => $"Time on server: {DateTime.Now}");
// //4
// app.MapGet("/hello/{name}", (string name) => $"Hi, {name}!");
// //5
// app.MapGet("/sum/{a}/{b}", (int a, int b) => $"sum {a + b}");
// //6
// app.MapGet("/student", () => new
// {
//     Name = "Alina Shuvalova",
//     Group = "ISP-231",
//     Year = 3,
//     Isactive = true
// });
// //7
// app.MapGet("/subject", () => new[]
// {
//     "RPM",
//     "RMP",
//     "ISRPO",
//     "SP",
// });
// //8
// app.MapGet("/product/{id}", (int id) => new Product(
//     Id: id,

//     Name: $"Tovar #{id}",
//     Price: id * 99.99m,
//     InStock: id % 2 == 0

// ));
