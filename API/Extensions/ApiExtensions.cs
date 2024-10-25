using API.Domain.Enums;
using API.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API.Extensions
{
    public static class ApiExtensions
    {
        public static void AddApiAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.RequireHttpsMetadata = true;
                    options.SaveToken = true;

                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions!.SecretKey))
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Cookies["login_info"];

                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();

            services.AddAuthorizationBuilder()
                .AddPolicy("Read", policy => policy.Requirements.Add(new PermissionRequirement([Permissions.Read])))
                .AddPolicy("ReadAll", policy => policy.Requirements.Add(new PermissionRequirement([Permissions.ReadAll])))
                .AddPolicy("Create", policy => policy.Requirements.Add(new PermissionRequirement([Permissions.Create])))
                .AddPolicy("Update", policy => policy.Requirements.Add(new PermissionRequirement([Permissions.Update])))
                .AddPolicy("Delete", policy => policy.Requirements.Add(new PermissionRequirement([Permissions.Delete])))
                .AddPolicy("ExtraPermission", policy => policy.Requirements.Add(new PermissionRequirement([Permissions.ExtraPermission])));
        }
    }
}
