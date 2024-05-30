using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using BoldReports.Server.DIResolvers;
using BoldReports.Server.Base.Resolvers;
using BoldReports.Server.Base;

namespace BoldReports.Server.DIResolvers.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add necessary  services to the container.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <returns>Returns result as IServiceCollection.</returns>
        public static IServiceCollection AddServiceProjects(this IServiceCollection services)
        {
            services.AddScoped<SystemSetting>();
            services.AddScoped<IItemManagement, ItemManagement>();
            return services;
        }

        /// <summary>
        /// Add necessary Multitenancy services to the container.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <returns>Returns result as IServiceCollection.</returns>
        public static IServiceCollection AddMultitenantServices(this IServiceCollection services)
        {
            ////Register Multitenancy as a service.
            services.AddScoped<TenantResolver>();
            services.AddScoped<TenantHandler>();
            return services;
        }
    }
}
