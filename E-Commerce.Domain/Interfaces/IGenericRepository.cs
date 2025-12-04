using E_Commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Interfaces
{
  public  interface IGenericRepository<TEntity,TKey>where TEntity : BaseEntity<TKey>
    {
        //Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllAsync(
        Expression<Func<TEntity, bool>>? condition = null,
        List<Expression<Func<TEntity, object>>>? includes = null);
        Task<TEntity> GetByIdAsync(TKey id);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
