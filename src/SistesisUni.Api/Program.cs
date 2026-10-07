using SistesisUni.Infrastructure.Security;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SistesisUni.Core.Application.Interfaces;
using SistesisUni.Infrastructure.Persistence;
using SistesisUni.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ============================================
// 1. EF Core + PostgreSQL
// ============================================
builder.Services.AddDbContext<ThesisDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
// ============================================
// 2. Inyección de dependencias (Repository Pattern)
// ============================================
builder.Services.AddScoped<IThesisRepository, ThesisRepository>();
builder.Services.AddScoped<IJwtService, JwtService>();

// ============================================
// 3. Controllers
// ============================================
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// ============================================
// 4. JWT Authentication
// ============================================
var jwtKey = builder.Configuration["Jwt:Key"] ?? "SISTESIS_UNI_SUPER_SECRET_KEY_2026_MIN_32_CHARS!!";
var jwtIssuer = builder.Configuration["Jwt:Issuer"] ?? "SistesisUni";
var jwtAudience = builder.Configuration["Jwt:Audience"] ?? "SistesisUniUsers";

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtIssuer,
        ValidAudience = jwtAudience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});

builder.Services.AddAuthorization();

// ============================================
// 5. Swagger con soporte JWT
// ============================================
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SISTESIS-UNI API",
        Version = "v1",
        Description = "Sistema de Gestión de Tesis Monográficas - UNI",
        Contact = new OpenApiContact { Name = "UNI - FIIS", Email = "sistesis@uni.edu.pe" }
    });

    // Botón "Authorize" en Swagger UI
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Ingrese el token JWT: Bearer {token}"
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
            Array.Empty<string>()
        }
    });
});

// ============================================
// 6. CORS (para el frontend Angular)
// ============================================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// ============================================
// 7. Pipeline HTTP
// ============================================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SISTESIS-UNI API v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();