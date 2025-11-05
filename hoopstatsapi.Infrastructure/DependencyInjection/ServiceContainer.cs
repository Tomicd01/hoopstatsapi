using hoopstatsapi.Application.Interfaces;
using hoopstatsapi.Application.Mappings;
using hoopstatsapi.Application.Services;
using hoopstatsapi.Infrastructure.Data;
using hoopstatsapi.Infrastructure.Repositories.Generic;
using hoopstatsapi.Infrastructure.Repositories.PlayerGameStats;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoopstatsapi.Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(Environment.GetEnvironmentVariable("HoopStatsConnection"),
                sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(ServiceContainer).Assembly.FullName);
                    sqlOptions.EnableRetryOnFailure();
                }));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<IPlayerGameStatsService, PlayerGameStatsService>();
            services.AddScoped<IPlayerGameStatsRepository, PlayerGameStatsRepository>();
            services.AddAutoMapper(cfg => { }, typeof(MappingProfile).Assembly);

            return services;
        }
    }
}
