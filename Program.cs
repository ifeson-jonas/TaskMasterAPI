using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TaskMasterAPI.Data;
using TaskMasterAPI.Interfaces.Repositories;
using TaskMasterAPI.Interfaces.Services;
using TaskMasterAPI.Repositories;
using TaskMasterAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// ========= CONFIGURAÇÃO DO SWAGGER =========
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "TaskMaster API", 
        Version = "v1",
        Description = "API para gerenciamento de tarefas com autenticação JWT",
        Contact = new OpenApiContact
        {
            Name = "Jonas",
            Email = "seu@email.com"
        }
    });
    
    // Configuração da segurança JWT no Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
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
    
    // Habilita anotações XML
    c.EnableAnnotations();
});
// ==========================================

// ========= CONFIGURAÇÃO CORS =========
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});
// =====================================

builder.WebHost.UseUrls("http://0.0.0.0:5000");

// Configurar DbContext com SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuração do JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? "default_key"))
        };
    });

builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddControllers();

var app = builder.Build();

// ========= ATIVA O SWAGGER =========
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskMaster API v1");
    c.RoutePrefix = "swagger";
    c.OAuthClientId("swagger-ui");
    c.OAuthAppName("Swagger UI");
});
// ===================================

// ========= APLICA CORS =========
app.UseCors("ReactFrontend");
// ==============================

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
