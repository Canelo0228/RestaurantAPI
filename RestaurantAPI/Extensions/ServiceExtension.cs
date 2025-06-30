using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace RestaurantAPI.Extensions
{
    public static class ServiceExtension
    {
        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", searchOption: SearchOption.TopDirectoryOnly).ToList();
                xmlFiles.ForEach(xmlFile => options.IncludeXmlComments(xmlFile));

                options.SwaggerDoc("v1", new OpenApiInfo
                {

                    Version = "v1",
                    Title = "Restaurant API",
                    Description = "This API will be responsible for overall data distribution",
                    Contact = new OpenApiContact
                    {
                        Name = "Jose Ignacio Canelo",
                        Email = "Josecanelo28@hotmail.com",
                        Url = new Uri("https://github.com/Canelo0228")
                    }
                });

                options.DescribeAllParametersInCamelCase();
                options.UseInlineDefinitionsForEnums();
            });
        }

        public static void AddApiVersioningExtension(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
        }
    }
}
