

using Kart.WebStore.Infrastructure.Services;
using Kart.WebStore.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kart.WebStore.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCommon(this IServiceCollection services, IConfiguration config)
        {
            services.AddOptions();
            services.Configure<WebStoreParams>(config.GetSection("webstoreparams"));
            return services;
        }
        public static IServiceCollection AddKartWebStoreServices(this IServiceCollection services)
        {
            ConfigureDependencyInjection(services);
            return services;
        }

        static IServiceCollection ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddSingleton<IOrderRepo, MongoDBOrderRepo>();
            services.AddSingleton<IProductRepo, MongoDBProductRepo>();  
            services.AddSingleton<IShippingRepo, MongoDBShippingRepo>();    
            services.AddSingleton<IOrderServices, OrderService>();
            services.AddSingleton<IProductServices, ProductService>();
            services.AddSingleton<IShippingServices, ShippingService>();
            return services;
        }
    }
}
