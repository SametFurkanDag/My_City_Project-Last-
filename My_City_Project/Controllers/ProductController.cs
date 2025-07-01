using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_City_Project.Dtos;
using My_City_Project.Dtos.ProductDtos;
using My_City_Project.Model.Entities;
using My_City_Project.Services.Interfaces;

namespace My_City_Project.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            var result = _mapper.Map<List<ResultProductDto>>(products);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(Guid id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<GetByIdProductDto>(product);
            return Ok(result);
        }
        [Authorize(Roles = "Admin,Vendor")]
        [HttpPost]
        public IActionResult CreateProduct([FromBody] CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);
            _productService.CreateProduct(product);
            return Ok();

        }
        [Authorize(Roles = "Admin,Vendor")]
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(Guid id, [FromBody] UpdateProductDto updateProductDto)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            _mapper.Map(updateProductDto, product);
            _productService.UpdateProduct(product);
            return Ok();
        }
        [Authorize(Roles = "Admin,Vendor")]
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            _productService.DeleteProduct(id);
            return Ok();
        }
    }
}
