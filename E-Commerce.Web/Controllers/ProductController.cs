using E_Commerce.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace E_Commerce.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("GetById/{id:int}")]
        public ActionResult<Product> GetById([FromRoute]int id)
        {

            return new Product() { Id= id, Name="Rice"};
        }
        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            return product;
        }
    }
}
