using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.SeadData;

public class GenerateFakeData
{
    public static async Task SeedDataAsync(ApplicationDbContext context,ILoggerFactory loggerFactory)
    {
        try
        {
            if(!await context.Products.AnyAsync())
            {
                var products = new List<Product>() {
                    new()
                    {
                      Description = "test",
                      PictureUrl = "",
                      Price = 15000,
                      Title = "Test",
                      Summery = "summery test"
                    }
                };
               await context.AddRangeAsync(products);
               await context.SaveChangesAsync();
            }
            if (!await context.ProductBrands.AnyAsync())
            {
                var brands = new List<ProductBrand>()
                {
                    new()
                    {
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed molestie lacus et est sagittis varius. Phasellus lobortis hendrerit sollicitudin. Suspendisse eu pulvinar risus, vehicula luctus felis. Vivamus a convallis sapien." ,
                        Summery = "Lorem ipsum dolor sit amet,",
                        Title = "Brand1"
                    },
                    new()
                    {
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed molestie lacus et est sagittis varius. Phasellus lobortis hendrerit sollicitudin. Suspendisse eu pulvinar risus, vehicula luctus felis. Vivamus a convallis sapien." ,
                        Summery = "Lorem ipsum dolor sit amet,",
                        Title = "Brand2"
                    }
                };
                await context.ProductBrands.AddRangeAsync(brands);
                await context.SaveChangesAsync();
            }
            if (!await context.ProductTypes.AnyAsync())
            {
                var types = new List<ProductType>()
                {
                    new()
                    {
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed molestie lacus et est sagittis varius. Phasellus lobortis hendrerit sollicitudin. Suspendisse eu pulvinar risus, vehicula luctus felis. Vivamus a convallis sapien." ,
                        Summery = "Lorem ipsum dolor sit amet,",
                        Title = "Brand1"
                    },
                    new()
                    {
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed molestie lacus et est sagittis varius. Phasellus lobortis hendrerit sollicitudin. Suspendisse eu pulvinar risus, vehicula luctus felis. Vivamus a convallis sapien." ,
                        Summery = "Lorem ipsum dolor sit amet,",
                        Title = "Brand2"
                    }
                };
                await context.ProductTypes.AddRangeAsync(types);
                await context.SaveChangesAsync();
            }
        }
        catch(Exception e)
        {
            var logger = loggerFactory.CreateLogger<GenerateFakeData>();
            logger.LogError(e, "Error in sead data");
        }
    }
}
