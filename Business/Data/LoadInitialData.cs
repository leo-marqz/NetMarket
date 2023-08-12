using Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Business.Data
{
    public class LoadInitialData
    {
        public static async Task LoadAsync(MarketplaceDbContext context, ILoggerFactory loggerFactory)
        {
			try
			{
				if (!context.Brands.Any())
				{
					var dataBrand = File.ReadAllText("../Business/InitialData/brands.json");
					var brands = JsonSerializer.Deserialize<List<Brand>>(dataBrand);
					foreach (var brand in brands)
					{
						context.Brands.Add(brand);
					}
					await context.SaveChangesAsync();
				}

				if(!context.Categories.Any())
				{
					var dataCategories = File.ReadAllText("../Business/InitialData/categories.json");
					var categories = JsonSerializer.Deserialize<List<Category>>(dataCategories);
					foreach (var category in categories)
					{
						context.Categories.Add(category);
					}
					await context.SaveChangesAsync();
				}

				if (!context.Products.Any())
				{
					var dataProducts = File.ReadAllText("../Business/InitialData/products.json");
					var products = JsonSerializer.Deserialize<List<Product>>(dataProducts);
					foreach (var product in products)
					{
						context.Products.Add(product);
					}
					await context.SaveChangesAsync();
				}
			}
			catch ( Exception ex)
			{
				var logger = loggerFactory.CreateLogger<LoadInitialData>();
				logger.LogError(ex, "Error en la insercion de data inicial");
			}
        }
    }
}
