using BusinessLogic.IService;
using DataAccess.DTO;
using DataAccess.IRepository;
using DataAccess.Models;

namespace BusinessLogic.Service
{
    public class CategoryService(ICategoryRepository _categoryRepository) : ICategoryService
    {
        public async Task<Category> CreateCategory(CategoryRequest request)
        {
            return await _categoryRepository.CreateCategory(request);
        }

        public async Task<bool> DeleteCategory(int categoryId)
        {
            return await _categoryRepository.DeleteCategory(categoryId);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryRepository.GetCategories();
        }

        public async Task<Category> GetCategoryById(int categoryId)
        {
            return await _categoryRepository.GetCategoryById(categoryId);
        }

        public async Task<Category> UpdateCategory(int categoryId, CategoryRequest request)
        {
            return await _categoryRepository.UpdateCategory(categoryId, request);
        }
    }
}
