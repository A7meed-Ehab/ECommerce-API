using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Entities.ProductEntities;
using E_Commerce.Domain.Entities.ProductModules;
using E_Commerce.Domain.Interfaces;
using E_Commerce.Persistence.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Data.DataSeed
{
    public class DataInitializer : IDataInitializer
    {
        private readonly StoreDbContext _dbContext;

        public DataInitializer(StoreDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task InitializeAsync()
        {
            try
            {
                var HasProducts =await _dbContext.Products.AnyAsync();
                var HasBrands =await _dbContext.ProductBrands.AnyAsync();
                var HasTypes =await _dbContext.ProductTypes.AnyAsync();
                if (HasProducts && HasBrands && HasTypes) return ;
                if (!HasBrands)
                {
                 await SeedDataFromJsonAsync<ProductBrand, int>("brands.json", _dbContext.ProductBrands);
                }
                if (!HasTypes)
                {
                 await SeedDataFromJsonAsync<ProductType, int>("types.json", _dbContext.ProductTypes);

                }
                _dbContext.SaveChanges();
                if (!HasProducts)
                {
                  await SeedDataFromJsonAsync<Product, int>("products.json", _dbContext.Products);
                }
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error While seeding data {ex}");
                return;
            }

        }
        private async Task SeedDataFromJsonAsync<T,Tkey>(string fileName, DbSet<T>dbset)where T : BaseEntity<Tkey>
        {
            var FilePath = @"../E-Commerce.Persistence/Data/DataSeed/JSONFiles/" + fileName;
            if (!File.Exists(FilePath)) throw new FileNotFoundException($"File {fileName} Not Found");
            try
            {
             using  var dataStream = File.OpenRead(FilePath);
             var data =await JsonSerializer.DeserializeAsync<List<T>>(dataStream, new JsonSerializerOptions
             {
                 PropertyNameCaseInsensitive = true
             });
                if(data is not null)
                {
                  await  dbset.AddRangeAsync(data);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error While Reading the json file {ex}");
                return;
            }

        }

    }
}
