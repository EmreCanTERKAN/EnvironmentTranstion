var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var connectionString = builder.Configuration.GetSection("SqlConnection");

Console.WriteLine(connectionString);

app.MapGet("/", () => "Hello World!");

app.Run();
