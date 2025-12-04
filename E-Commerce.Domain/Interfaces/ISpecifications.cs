using E_Commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Interfaces
{
  public  interface ISpecifications<TEntity,Tkey>where TEntity : BaseEntity<Tkey>
    {
        ICollection<Expression<Func<TEntity,object>>>? IncludeExpressions { get; }
    }
}
