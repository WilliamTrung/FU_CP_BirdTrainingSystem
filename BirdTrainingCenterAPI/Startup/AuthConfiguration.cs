using AppService;
using AppService.Implementation;
using AuthSubsystem;
using AuthSubsystem.Implementation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Models.ConfigModels;
using System.Text;

namespace BirdTrainingCenterAPI.Startup
{
    public static class AuthConfiguration
    {
        public static void JwtConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));
            builder.Services.AddTransient<IAuthFeature, AuthFeature>();
            builder.Services.AddTransient<IAuthService, AuthService>();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = builder.Configuration["JwtConfig:Issuer"],
                        ValidAudience = builder.Configuration["JwtConfig:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey
                            (Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:Key"])),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true
                };
            });
            builder.Services.AddAuthorization();
        }
    }
}
