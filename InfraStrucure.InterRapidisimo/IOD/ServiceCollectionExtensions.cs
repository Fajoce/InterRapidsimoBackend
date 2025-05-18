using Domain.IterRapisimo.Repositories;
using InfraStrucure.InterRapidisimo.DataContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace InfraStrucure.InterRapidisimo.IOD
{
    public static  class ServiceCollectionExtensions
    {
        public static IServiceCollection MyDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
            var connectionString = configuration.GetConnectionString("myConection");

            services.AddDbContext<ColegioDbContext>(options =>
                options.UseSqlServer(connectionString));           

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(key)
                    };
                });
            services.AddCors(options =>
            {
                options.AddPolicy("myPolicies", app =>
                {
                    app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });


            services.AddAuthorization();
            return services;
        }

    }
}
