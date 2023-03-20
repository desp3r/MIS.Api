using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MIS.Business.Interfaces;
using MIS.Business.MapperProfiles;
using MIS.Business.Services;
using System.Reflection;

namespace MIS.Business.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => cfg.AddProfile<MisProfile>(), Assembly.GetExecutingAssembly());
            return services;
        }

        public static IServiceCollection AddMisBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IIdentityService, IdentityService>();
            return services;
        }
    }
}
