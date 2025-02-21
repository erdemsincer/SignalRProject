using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _productService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            Product about = new Product()
            {
                Description = createProductDto.Description,
                ImageUrl = createProductDto.ImageUrl,
                ProductName = createProductDto.ProductName,
                Price = createProductDto.Price,
                ProductStatus = createProductDto.ProductStatus,
                CategoryId = createProductDto.CategoryId


            };
            _productService.TAdd(about);
            return Ok("eklendi");
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            Product about = new Product()
            {
                ProductId = updateProductDto.ProductId,
                Description = updateProductDto.Description,
                ImageUrl = updateProductDto.ImageUrl,
                ProductName = updateProductDto.ProductName,
                Price = updateProductDto.Price,
                ProductStatus = updateProductDto.ProductStatus,
                CategoryId = updateProductDto.CategoryId
            };

            _productService.TUpdate(about);
            return Ok("Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok("Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetByIdProduct(int id)
        {
            var value = _productService.TGetById(id);
            return Ok(value);
        }
    }
}
