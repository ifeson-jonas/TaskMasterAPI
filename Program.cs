using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

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
            ValidIssuer = builder.Configuration[Jwt:Issuer],
            ValidAudience = builder.Configuration[Jwt:Audience],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration[Jwt:Key]))
        };
    });

// Adicione ao seu appsettings.json:
// Jwt: {
//   Key: SUA_CHAVE_SECRETA_MUITO_SEGURA_AQUI,
//   Issuer: TaskMasterAPI,
//   Audience: TaskMasterAPI-Users
// }

