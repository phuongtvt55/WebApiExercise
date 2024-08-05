using DataAccess.DTO;
using DataAccess.Models;
using DataAccess.IRepository;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using BusinessLogic.IService;

namespace ExerciseApi.Controllers
{
    [Route("exercise/v1/category")]
    [ApiController]
    public class CategoryController(ICategoryService _categoryService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCategories()
        {
            var listCategory = _categoryService.GetCategories();
            return Ok(listCategory);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null) { 
                return NotFound(new Response<string> { StatusCode = HttpStatusCode.NotFound, Message = $"Can't not find category with id {id}" });
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult CreateCategory(CategoryRequest request)
        {
            var category = _categoryService.CreateCategory(request);
            if(category != null)
            {
                return Ok(new Response<string> { StatusCode = HttpStatusCode.OK, Message = "Create category successfully" });
            }

            return BadRequest(new Response<string> { StatusCode = HttpStatusCode.BadRequest, Message = "Invalid category" });
        }


        [HttpPut]
        public IActionResult UpdateCategory([FromQuery] int categoryId, [FromBody] CategoryRequest request)
        {
            var category = _categoryService.UpdateCategory(categoryId, request);
            if (category != null)
            {
                return Ok(new Response<Category> { StatusCode = HttpStatusCode.OK, Message = "Update category successfully", Data = category });
            }
            else
            {
                return NotFound(new Response<string> { StatusCode = HttpStatusCode.NotFound, Message = $"Not found category with id {categoryId}" });
            }
        }

        [HttpDelete]
        public IActionResult DeleteCategory([FromQuery] int categoryId)
        {
            var flag = _categoryService.DeleteCategory(categoryId);
            if (flag)
            {
                return Ok(new Response<string> { StatusCode = HttpStatusCode.OK, Message = "Delete category successfully" });
            }
            else
            {
                return NotFound(new Response<string> { StatusCode = HttpStatusCode.NotFound, Message = $"Not found category with id {categoryId}" });
            }
        }
    }
}
