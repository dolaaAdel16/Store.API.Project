using Microsoft.EntityFrameworkCore;
using Store.G02.Domain.Contracts;
using Store.G02.Domain.Entities.Products;
using Store.G02.Persistence.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.G02.Persistence
{
    public class DbInitializer(StoreDbContext _context) :IDbInitializer
    {
       
        public async Task IDbInitializeAsync()
        {
            // Create DB
            // Update DB 
            if (_context.Database.GetPendingMigrationsAsync().GetAwaiter().GetResult().Any())
            {
                await _context.Database.MigrateAsync();
            }
            // Data Seeding

            if (_context.ProductBrands.Any())
            {
                // Product Brands
                // 1. Read Data from Json File 
                //
                var brandsdata = await File.ReadAllTextAsync(@"..\Infrastructure\Store.G02.Presistence\Data\Data Seeding\brands.json");

                // 2. Convert the JsonString to List <Product Brand>
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsdata);

                if (brands is not null && brands.Count > 0)
                {
                    await _context.ProductBrands.AddRangeAsync(brands);
                }
            }

            // Product Types
            if (_context.ProductTypes.Any())
            {
                // Product Brands
                // 1. Read Data from Json File 
                //
                var typesdata = await File.ReadAllTextAsync(@"..\Infrastructure\Store.G02.Presistence\Data\Data Seeding\types.json");

                // 2. Convert the JsonString to List <Product Brand>
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesdata);

                if (types is not null && types.Count > 0)
                {
                    await _context.ProductTypes.AddRangeAsync(types);
                }
            }

            // Products
            if (_context.Products.Any())
            {
                // Product Brands
                // 1. Read Data from Json File 
                //
                var productsdata  = await File.ReadAllTextAsync(@"..\Infrastructure\Store.G02.Presistence\Data\Data Seeding\products.json");

                // 2. Convert the JsonString to List <Product Brand>
                var products = JsonSerializer.Deserialize<List<Product>>(productsdata);

                if (products is not null && products.Count > 0)
                {
                    await _context.Products.AddRangeAsync(products);
                }
            }

            await _context.SaveChangesAsync();

        }
    }
}
