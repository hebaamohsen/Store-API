using Microsoft.OpenApi.Models;

namespace Store.Web.Extension
{
    public static class SwaggerServiceExtension
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Store Api",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Route Academy",
                        Email = "routeacademy@gmail.com",
                        Url = new Uri("https://twitter.com/routeacademy"),
                    }
                });
                var securityScheme = new OpenApiSecurityScheme
                {
                    Description = "jwt authorization header using the bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Id = "bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                };
                options.AddSecurityDefinition("bearer", securityScheme);

                var securityRequirements = new OpenApiSecurityRequirement
                {
                    {securityScheme , new[] { "bearer" } }
                };
                 options.AddSecurityRequirement(securityRequirements);
                });
            return services;

        }
    }
}

