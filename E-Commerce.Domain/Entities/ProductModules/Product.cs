using E_Commerce.Domain.Entities.ProductModules;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace E_Commerce.Domain.Entities.ProductEntities
{
  public  class Product:BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        #region Relationships
        public int BrandId { get; set; }
        [ForeignKey(nameof(BrandId))]
        public ProductBrand ProductBrand { get; set; } = default;     
        public int TypeId { get; set; }
        [ForeignKey(nameof(TypeId))]
        public ProductType ProductType { get; set; } = default;
        #endregion

    }
}
