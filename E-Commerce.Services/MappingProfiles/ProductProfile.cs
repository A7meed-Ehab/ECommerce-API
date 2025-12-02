using AutoMapper;
using E_Commerce.Domain.Entities.ProductEntities;
using E_Commerce.Domain.Entities.ProductModules;
using E_Commerce.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Services.MappingProfiles
{
  public   class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductBrand, BrandDTO>();
            CreateMap<Product, ProductDTO>().ForMember(dest=>dest.ProductType,opt=>opt.MapFrom(src=>src.ProductType.Name));
            CreateMap<Product, ProductDTO>().ForMember(dest=>dest.ProductBrand,opt=>opt.MapFrom(src=>src.ProductBrand.Name));
            CreateMap<Product, ProductDTO>().ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<ProductPictureUrlResolver>());
            CreateMap<ProductType, TypeDTO>();
        }
    }
}
