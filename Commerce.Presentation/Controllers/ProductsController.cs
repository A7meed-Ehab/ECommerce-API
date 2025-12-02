using E_Commerce.Services.Abstraction;
using E_Commerce.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Presentation.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
 public class ProductsController:ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            this._productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
        {
            var products =await _productService.GetAllProductsAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            return Ok(product);
        }
        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<TypeDTO>>> GetTypes()
        {
            var Types = await _productService.GetAllTypesAsync();
            return Ok(Types);
        }
        [HttpGet("Brands")]
        public async Task<ActionResult<IEnumerable<BrandDTO>>> GetBrands()
        {
            var Brands = await _productService.GetAllBrandsAsync();
            return Ok(Brands);
        }
    }
}
