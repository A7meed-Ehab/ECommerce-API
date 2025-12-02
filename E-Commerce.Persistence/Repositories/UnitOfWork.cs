using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Interfaces;
using E_Commerce.Persistence.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _storeDbContext;

        // FIX 1: Initialize the dictionary
        private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }

        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
            where TEntity : BaseEntity<TKey>
        {
            var entityType = typeof(TEntity);

            // Check if already created
            if (_repositories.TryGetValue(entityType, out var repository))
            {
                return (IGenericRepository<TEntity, TKey>)repository;
            }

            // Create new repository
            var newRepo = new GenericRepositories<TEntity, TKey>(_storeDbContext);

            // FIX 2: Store it in dictionary
            _repositories[entityType] = newRepo;

            return newRepo;
        }

        public Task<int> SaveChangesAsync()
        {
            return _storeDbContext.SaveChangesAsync();
        }
    }
}
