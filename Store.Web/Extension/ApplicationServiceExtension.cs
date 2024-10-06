using Microsoft.AspNetCore.Mvc;
using Store.Repository.Basket;
using Store.Repository.Interfaces;
using Store.Repository.Repositories;
using Store.Service.BasketService;
using Store.Service.BasketService.Dtos;
using Store.Service.HandleResponses;
using Store.Service.Services.CacheServices;
using Store.Service.Services.TheProducts;
using Store.Service.Services.TheProducts.Dtos;

namespace Store.Web.Extension
{
    public static  class ApplicationServiceExtension
    {
        public static IServiceCollection AddAplicationService(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICacheServices,CacheService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IBasketRepositry, BasketRepository>();
            services.AddAutoMapper(typeof(ProductProfile));
            services.AddAutoMapper(typeof(BasketProfile));
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                                 .Where(model => model.Value?.Errors.Count > 0)
                                 .SelectMany(model => model.Value?.Errors)
                                 .Select(error => error.ErrorMessage)
                                 .ToList();

                    var errorResponse = new ValidationErrorResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });
            return services;
        }
    }
}
