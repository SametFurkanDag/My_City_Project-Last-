using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_City_Project.Data;
using My_City_Project.Extensions;
using My_City_Project.Helpers;

using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration) 
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();
builder.Host.UseSerilog();

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddJwtAuthentication(builder.Configuration); 
builder.Services.AddAuthorization();
builder.Services.AddApiVersioningServices(); 

builder.Services.AddRepositories(); 
builder.Services.AddServices();     

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPasswordHelper, BcryptPasswordHelper>();

var app = builder.Build();

app.ConfigureExceptionMiddleware(); 


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.ApplyMigrationsAndSeedAdmin();

app.Run();