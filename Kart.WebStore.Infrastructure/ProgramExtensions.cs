using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Kart.WebStore.Infrastructure
{
    public static class ProgramExtensions
    {

        public static void ConfigureSwaggerGen(
            this IServiceCollection services, 
            string title, 
            string applicationName, 
            string version)
        {
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = title, Version = version });
                //swagger.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{applicationName}.xml"));
                swagger.EnableAnnotations();
            });
        }

        public static void ConfigureSwagger(this IApplicationBuilder app, string applicationName)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", applicationName);
            });
        }
    }
}
