using MiageCorp.AwesomeShop.ProductApi.Models;
using MiageCorp.AwesomeShop.ProductApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiageCorp.AwesomeShop.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService ProductService { get; set; }

        public ProductsController(IProductService productService)
        {
            ProductService = productService;
        }

        // GET api/<ProductsController>/
        [HttpGet]
        public List<Product> Get()
        {
            return ProductService.GetProducts();
        }

        // GET api/<ProductsController>/5
        [HttpGet("/{productId}")]
        public Product? Get(string productId)
        {
            return ProductService.GetProductById(productId);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] Product model)
        {
            ProductService.AddProduct(model);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Product model)
        {
            ProductService.UpdateProduct(id, model);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("/{itemId}")]
        public void Delete(string userId, string itemId)
        {
            ProductService.DeleteProduct(itemId);
        }
    }
}
