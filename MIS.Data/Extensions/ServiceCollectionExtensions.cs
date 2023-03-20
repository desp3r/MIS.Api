using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MIS.Data.Contexts;
using MIS.Data.Interfaces;
using MIS.Data.Repositories;

namespace MIS.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMisData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MisContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MisDatabase"))
                    .ConfigureWarnings(c => c.Ignore(CoreEventId.MultipleNavigationProperties))
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution)
                    .EnableSensitiveDataLogging());

            services.AddScoped<IMisRepository, MisRepository>();

            return services;
        }
    }
}
