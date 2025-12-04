using E_Commerce.Domain.Entities.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Services.Specifications
{
   internal class ProductWithBrandAndTypeSpecification:BaseSpecifications<Product,int>
    {
        public ProductWithBrandAndTypeSpecification():base()
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);
        }
    }
}
