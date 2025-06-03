using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TaskMasterAPI.Interfaces.Repositories;
using TaskMasterAPI.Interfaces.Services;
using TaskMasterAPI.Repositories;
using TaskMasterAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Permitir conexões externas (em todas as interfaces de rede)
builder.WebHost.UseUrls("http://0.0.0.0:5000");

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

// Injeção de dependência
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();

// Adicione os controllers
builder.Services.AddControllers();

var app = builder.Build();

// Middleware de autenticação/autorização
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
