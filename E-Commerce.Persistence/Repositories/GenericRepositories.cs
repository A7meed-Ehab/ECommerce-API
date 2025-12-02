using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Interfaces;
using E_Commerce.Persistence.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Repositories
{
    public class GenericRepositories<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly StoreDbContext _storeDbContext;

        public GenericRepositories( StoreDbContext storeDbContext)
        {
            this._storeDbContext = storeDbContext;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
          return  await _storeDbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(TKey id)
        {
            return await _storeDbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
          await  _storeDbContext.Set<TEntity>().AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _storeDbContext.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _storeDbContext.Set<TEntity>().Update(entity);
        }

    }
}
