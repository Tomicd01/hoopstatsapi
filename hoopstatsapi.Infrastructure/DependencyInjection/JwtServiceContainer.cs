using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoopstatsapi.Infrastructure.DependencyInjection
{
    public static class JwtServiceContainer
    {
        public static IServiceCollection AddJwtService(this IServiceCollection services)
        {
            services.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    options.Authority = "http://localhost:8080/realms/hoopstats"; // Isuuer
                    options.Audience = "hoopstatsapi"; // Keycloak Client
                    options.RequireHttpsMetadata = false; // Development only
                });
            services.AddAuthorizationBuilder();

            return services;
        }
    }
}
