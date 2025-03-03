using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddLogging();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Add the logging middleware directly in Program.cs
app.Use(async (context, next) =>
{
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    var stopwatch = Stopwatch.StartNew();

    logger.LogInformation($"Incoming request: {context.Request.Method} {context.Request.Path}");

    await next.Invoke();

    stopwatch.Stop();
    logger.LogInformation($"Outgoing response: {context.Response.StatusCode} in {stopwatch.ElapsedMilliseconds}ms");
});


app.MapControllers();

app.Run();

public class User
{
    required public string Id { get; set; }
    required public string Name { get; set; }
}