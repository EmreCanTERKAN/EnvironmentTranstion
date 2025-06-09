var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


var env = builder.Environment.EnvironmentName;
Console.WriteLine(env);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
    .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: false);

var connectionString = builder.Configuration.GetSection("SqlConnection").Value;
Console.WriteLine(connectionString);

app.MapGet("/", () => "Hello World!");

app.Run();
