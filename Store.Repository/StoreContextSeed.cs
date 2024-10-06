using Microsoft.Extensions.Logging;
using Store.Data.Contexts;
using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Repository
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreDbContext context,ILoggerFactory IloggerFactory) 
        { 
            try
            {
                if (context.ProductBrands != null && !context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../Store.Repository/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    if (brands is not null)
                        await context.ProductBrands.AddRangeAsync(brands);
                }

                if (context.ProductTypes != null && !context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../Store.Repository/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    if (types is not null)
                        await context.ProductTypes.AddRangeAsync(types);

                }
                        if (context.Products != null && !context.Products.Any())
                        {
                            var productsData = File.ReadAllText("../Store.Repository/SeedData/products.json");
                            var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                            if (products is not null)
                                await context.Products.AddRangeAsync(products);

                        }
                if (context.DeliveryMethods != null && !context.DeliveryMethods.Any())
                {
                    var deliveryMethodData = File.ReadAllText("../Store.Repository/SeedData/delivery.json");
                    var deliveryMethods = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveryMethodData);

                    if (deliveryMethods is not null)
                        await context.DeliveryMethods.AddRangeAsync(deliveryMethods);

                }
                await context.SaveChangesAsync();
                    }
            catch(Exception ex)
            {
                var logger = IloggerFactory.CreateLogger<StoreContextSeed> ();
                logger.LogError(ex.Message);
            }
        }
    }
}
