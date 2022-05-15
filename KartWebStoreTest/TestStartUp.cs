using Kart.WebStore.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace KartWebStoreTest
{
    public static class TestStartUp
    {
        public static IServiceProvider BootStrap()
        {
            var args = new string[] { };

            var builder = WebApplication.CreateBuilder(args);

            builder.Host.ConfigureAppConfiguration((context, builder) => {
                GetApplicationConfiguration(@"D:\Karthik\Tehnology\Learnings\KartWebStoreTest");
            });
            builder.Services.AddCommon(builder.Configuration);
            builder.Services.AddKartWebStoreServices();
            
            builder.Services.AddSingleton(builder.Services);
            return builder.Build().Services;
        }

        public static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.dev.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
                
        }

        public static WebStoreParams GetApplicationConfiguration(string outputPath)
        {
             WebStoreParams webStoreParams = new WebStoreParams();

             var iConfig = GetIConfigurationRoot(outputPath);

            iConfig
                .GetSection("WebStoreParams").Bind(webStoreParams);
            return webStoreParams;
        }
    }
}
