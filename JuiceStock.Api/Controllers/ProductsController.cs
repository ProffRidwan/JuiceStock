using JuiceStock.Api.Contracts.Products;
using JuiceStock.Application.Products;
using Microsoft.AspNetCore.Mvc;
using JuiceStock.Api.Mappings;

namespace JuiceStock.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public IActionResult Create(CreateProductRequest request)
        {
            var id = _productService.CreateProduct(
                request.Name,
                request.Price,
                request.ProductCategoryId,
                request.SupplierId
            );

            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            var product = _productService.GetProduct(id);
            return Ok(product.ToResponse());
        }
    }
}
