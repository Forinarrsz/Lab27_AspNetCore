using System.Data.Common;

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
app.MapGet("/sum/{a}/{b}", (int a, int b) => $"sum {a + b}");
//6
app.MapGet("/student", () => new
{
    Name = "Alina Shuvalova",
    Group = "ISP-231",
    Year = 3,
    Isactive = true
});
//7
app.MapGet("/subject", () => new[]
{
    "RPM",
    "RMP",
    "ISRPO",
    "SP",
});
//8
app.MapGet("/product/{id}", (int id) => new Product(
    Id: id,

    Name: $"Tovar #{id}",
    Price: id * 99.99m,
    InStock: id % 2 == 0

));
app.Run();
record Product(int Id, string Name, decimal Price, bool InStock);
