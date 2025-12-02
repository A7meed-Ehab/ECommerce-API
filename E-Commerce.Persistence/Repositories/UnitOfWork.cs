using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Interfaces;
using E_Commerce.Persistence.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Repositories
{
     public  class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _storeDbContext;
        private readonly Dictionary<Type, Object> _repsitories;

        public UnitOfWork(StoreDbContext storeDbContext)
        {
            this._storeDbContext = storeDbContext;
        }
        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var EntityType = typeof(TEntity);
            if(_repsitories.TryGetValue(EntityType, out object? repository))
                return (IGenericRepository<TEntity, TKey>)repository;
            var newRepo = new GenericRepositories<TEntity, TKey>(_storeDbContext);
            _repsitories[EntityType] = newRepo;
            return newRepo;

        }

        public async Task<int> SaveChangesAsync()
        {
         return await _storeDbContext.SaveChangesAsync();
        }
    }
}
