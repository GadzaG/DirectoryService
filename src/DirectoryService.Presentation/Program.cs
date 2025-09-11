using DirectoryService.Infrastructure.Postgres;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

foreach (var tz in TimeZoneInfo.GetSystemTimeZones())
{
    Console.WriteLine($"{tz.Id} |\t {tz.DisplayName} |\t {tz.StandardName}");
}

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.Debug()
    .WriteTo.Seq(builder.Configuration["ConnectionStrings:Seq"] ?? throw new InvalidOperationException("seq connection string not found"))
    .MinimumLevel.Override("Microsoft.AspNetCore.Hosting", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.AspNetCore.Mvc", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.AspNetCore.Routing", LogEventLevel.Warning)
    .CreateLogger();

builder.Services.AddSerilog();
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddPostgres(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();