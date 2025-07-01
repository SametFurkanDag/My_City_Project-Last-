using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using My_City_Project.Data;
using My_City_Project.Extensions;
using My_City_Project.Helpers;
using My_City_Project.Mappings;
using My_City_Project.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// ✅ Serilog ile logging yapılandırması
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();
builder.Host.UseSerilog();

// ✅ DbContext (PostgreSQL)
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ JWT Authentication (özelleştirilmiş extension metodu)
builder.Services.AddJwtAuthentication(builder.Configuration);

// ✅ Authorization
builder.Services.AddAuthorization();

// ✅ API versiyonlama (örneğin: /api/v1/... )
builder.Services.AddApiVersioningServices();

// ✅ Custom servis ve repository kayıtları
builder.Services.AddRepositories();
builder.Services.AddServices();

// ✅ Controller, Swagger, DTO mapping, helpers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My City API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\""
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddScoped<IPasswordHelper, BcryptPasswordHelper>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
builder.Services.AddSingleton<TokenService>();

// ✅ Uygulama oluşturuluyor
var app = builder.Build();

// ✅ Global exception middleware (kendi extension metotlarından biri olmalı)
app.ConfigureExceptionMiddleware();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ✅ HTTPS yönlendirme ve middleware sırası ÖNEMLİ
app.UseHttpsRedirection();

// 🟨 Bu sıraya dikkat:
app.UseAuthentication();
app.UseAuthorization();

// ✅ Controller routing
app.MapControllers();

// ✅ Migration ve Admin user seed işlemi
app.ApplyMigrationsAndSeedAdmin();

// ✅ Uygulamayı başlat
app.Run();
