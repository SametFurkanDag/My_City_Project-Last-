using Microsoft.AspNetCore.Mvc;
using My_City_Project.Model.Entities;
using My_City_Project.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace My_City_Project.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetProductById(Guid id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
                return NotFound("Ürün bulunamadı");

            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if (product.ProductId == Guid.Empty)
            {
                product.ProductId = Guid.NewGuid();
            }

            _productService.CreateProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, "Ürün eklendi");
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateProduct(Guid id, [FromBody] Product product)
        {
            var existingProduct = _productService.GetProductById(id);
            if (existingProduct == null)
                return NotFound("Ürün bulunamadı");

            if (product.ProductId != id)
                return BadRequest("Ürün ID'si rota ID'si ile eşleşmiyor.");

            _productService.UpdateProduct(product);
            return Ok("Ürün güncellendi");
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteProduct(Guid id)
        {
          
            var existingProduct = _productService.GetProductById(id);

            if (existingProduct == null)
                return NotFound("Ürün bulunamadı");

            _productService.DeleteProduct(id);
            return Ok("Ürün silindi");
        }
    }
}