using DataAccess.DAO;
using DataAccess.DTO;
using DataAccess.IRepository;
using DataAccess.Models;

namespace DataAccess.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public async Task<Category> CreateCategory(CategoryRequest request)
        {
            return await CategoryDAO.GetInstance.CreateCategory(request);
        }

        public async Task<bool> DeleteCategory(int categoryId)
        {
            return await CategoryDAO.GetInstance.DeleteCategory(categoryId);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await CategoryDAO.GetInstance.GetCategories();
        }

        public async Task<Category> GetCategoryById(int categoryId)
        {
            return await CategoryDAO.GetInstance.GetCategoryById(categoryId);
        }

        public async Task<Category> UpdateCategory(int categoryId, CategoryRequest request)
        {
            return await CategoryDAO.GetInstance.UpdateCategory(categoryId, request);
        }
    }
}
