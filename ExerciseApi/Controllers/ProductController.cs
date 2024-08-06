﻿using BusinessLogic.IService;
using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ExerciseApi.Controllers
{
    [Route("exercise/v1/products")]
    [ApiController]
    public class ProductController(IProductService _productService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var listProduct = await _productService.GetProducts();
            return Ok(listProduct);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound(new Response<string> { StatusCode = HttpStatusCode.NotFound, Message = $"Not found product with id {id}" });
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductRequest request)
        {
            var product = await _productService.CreateProduct(request);
            if (product != null)
            {
                return Ok(new Response<Product> { StatusCode = HttpStatusCode.OK, Message = "Create product successfully!", Data = product });
            }

            return BadRequest(new Response<string> { StatusCode = HttpStatusCode.BadRequest, Message = "Server error" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] ProductRequest request)
        {
            var product = await _productService.UpdateProduct(id, request);
            if (product != null)
            {
                return Ok(new Response<Product> { StatusCode = HttpStatusCode.OK, Message = "Update successfully", Data = product });
            }
            else
            {
                return NotFound(new Response<Product> { StatusCode = HttpStatusCode.NotFound, Message = $"Not found product with id {id}" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            var flag = await _productService.DeleteProduct(id);
            if (flag)
            {
                return Ok(new Response<string> { StatusCode = HttpStatusCode.OK, Message = "Delete product successfully" });
            }
            else
            {
                return NotFound(new Response<string> { StatusCode = HttpStatusCode.NotFound, Message = $"Not found product with id {id}" });
            }
        }
    }
}
