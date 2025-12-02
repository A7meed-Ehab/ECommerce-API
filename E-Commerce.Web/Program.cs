
using E_Commerce.Domain.Interfaces;
using E_Commerce.Persistence.Data.DataSeed;
using E_Commerce.Persistence.Data.DbContexts;
using E_Commerce.Persistence.Repositories;
using E_Commerce.Services;
using E_Commerce.Services.Abstraction;
using E_Commerce.Services.MappingProfiles;
using E_Commerce.Web.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace E_Commerce.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IDataInitializer,DataInitializer>(); 
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddAutoMapper(typeof(ServicesAssemblyReference).Assembly);
            //builder.Services.AddAutoMapper(x=>x.AddProfile<ProductProfile>());
            //builder.Services.AddTransient<ProductPictureUrlResolver>();
            #endregion
            var app = builder.Build();
            #region Data Seeding
            await app.MigrateDatabaseAsync();
            await app.SeedDatabaseAsync();

            #endregion
            #region Configure the HTTP request pipeline.

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.MapControllers();

            #endregion
            app.Run();
        }
    }
}
