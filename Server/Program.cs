using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var serverHandler = new ServerHandler();

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var serverUrl = configuration["ServerUrl"];

app.MapPost("/send", serverHandler.Send);
app.MapGet("/receive", serverHandler.Receive);

app.Run(serverUrl);