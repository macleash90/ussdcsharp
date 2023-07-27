using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using USSDCSharp;
using USSDCSharp.DBContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var configuration = builder.Configuration;

// Register your DbContext for dependency injection
//builder.Services.AddDbContext<UssdDBContext>();
builder.Services.AddDbContext<UssdDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("USSDConnection"));
});

configuration.AddJsonFile("appsettings.json");

// Populate AppSettings class with configuration values
AppSettings.USSDConnection = configuration.GetConnectionString("USSDConnection");
AppSettings.DisableAppMsg = (string)configuration.GetSection("AppSettings").GetValue(typeof(string), "DisableAppMsg");
AppSettings.DebugMsg = (string)configuration.GetSection("AppSettings").GetValue(typeof(string), "DebugMsg");
AppSettings.ShortCode = (string)configuration.GetSection("AppSettings").GetValue(typeof(string), "ShortCode");



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=USSD}/{action=Index}/{id?}");

app.Run();
