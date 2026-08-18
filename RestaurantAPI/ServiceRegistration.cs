using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Application.Services;
using System.Security.Claims;
using System.Text;

namespace RestaurantAPI
{
    public static class ServiceRegistration
    {
        public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            #region token
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(configuration["JWT:Key"]!)
                        ),

                        ValidateIssuer = true,
                        ValidIssuer = configuration["JWT:Issuer"],

                        ValidateAudience = true,
                        ValidAudience = configuration["JWT:Audience"],

                        RoleClaimType = ClaimTypes.Role,

                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            Console.WriteLine("JWT ERROR:");
                            Console.WriteLine(context.Exception.Message);

                            return Task.CompletedTask;
                        }
                    };

                });

            services.AddAuthorization();
            #endregion

            #region repositories
            services.AddScoped<IAuthService, AuthService>();
            #endregion
        }
    }
}
