using BusinessLogic.IService;
using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ExerciseApi.Controllers
{
    [Route("exercise/v1/category")]
    [ApiController]
    public class CategoryController(ICategoryService _categoryService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var listCategory = await _categoryService.GetCategories();
            return Ok(listCategory);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound(new Response<string> { StatusCode = HttpStatusCode.NotFound, Message = $"Can't not find category with id {id}" });
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryRequest request)
        {
            var category = await _categoryService.CreateCategory(request);
            if (category != null)
            {
                return Ok(new Response<Category> { StatusCode = HttpStatusCode.OK, Message = "Create category successfully", Data = category });
            }

            return BadRequest(new Response<string> { StatusCode = HttpStatusCode.BadRequest, Message = "Invalid category" });
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] CategoryRequest request)
        {
            var category = await _categoryService.UpdateCategory(id, request);
            if (category != null)
            {
                return Ok(new Response<Category> { StatusCode = HttpStatusCode.OK, Message = "Update category successfully", Data = category });
            }
            else
            {
                return NotFound(new Response<string> { StatusCode = HttpStatusCode.NotFound, Message = $"Not found category with id {id}" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            var flag = await _categoryService.DeleteCategory(id);
            if (flag)
            {
                return Ok(new Response<string> { StatusCode = HttpStatusCode.OK, Message = "Delete category successfully" });
            }
            else
            {
                return NotFound(new Response<string> { StatusCode = HttpStatusCode.NotFound, Message = $"Not found category with id {id}" });
            }
        }
    }
}
