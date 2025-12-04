using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistence
{
    internal static class SpecificationsEvaluator
    {
        public static IQueryable<TEntity> CreateQuery<TEntity, TKey>(IQueryable<TEntity> EntryPoint
            , ISpecifications<TEntity, TKey> specifications) where TEntity : BaseEntity<TKey>
        {
            var query = EntryPoint;
            if (specifications is not null)
            {
                if (specifications.IncludeExpressions is not null && specifications.IncludeExpressions.Any())
                {
                    query = specifications.IncludeExpressions.Aggregate(query,                   
                        (currentQuery, IncludeExp)=> currentQuery.Include(IncludeExp));
                }
            }
            return query;
        }
    }
}
