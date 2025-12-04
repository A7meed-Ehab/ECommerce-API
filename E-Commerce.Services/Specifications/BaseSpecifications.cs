using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Services.Specifications
{
    class BaseSpecifications<TEntity, Tkey> : ISpecifications<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        public ICollection<Expression<Func<TEntity, object>>>? IncludeExpressions { get; } = [];
        protected void AddInclude(Expression<Func<TEntity,object>> InlcudeExp)
        {
            IncludeExpressions.Add(InlcudeExp);
        }
    }
}
