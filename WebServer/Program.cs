var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
//1
app.MapGet("/", () => "welcome to server!");
//2
app.MapGet("/about", () => "it`s my 1st ASP.NET Core Server");
//3
app.MapGet("/time", () => $"Time on server: {DateTime.Now}");
//4
app.MapGet("/hello/{name}", (string name) => $"Hi, {name}!");
//5
app.MapGet("/sum/{a}/{b}", (int a, int b) => $"sum {a+b}");
app.Run();
