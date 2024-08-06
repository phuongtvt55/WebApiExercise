using DataAccess.DTO;
using DataAccess.Models;

namespace BusinessLogic.IService
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategoryById(int categoryId);
        Task<Category> CreateCategory(CategoryRequest request);
        Task<Category> UpdateCategory(int categoryId, CategoryRequest request);
        Task<bool> DeleteCategory(int categoryId);
    }
}
