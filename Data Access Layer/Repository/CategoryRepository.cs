using DataAccess.DTO;
using DataAccess.Models;
using DataAccess.DAO;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public Category CreateCategory(CategoryRequest request)
        {
            return CategoryDAO.GetInstance.CreateCategory(request);
        }

        public bool DeleteCategory(int categoryId)
        {
            return CategoryDAO.GetInstance.DeleteCategory(categoryId);
        }

        public IEnumerable<Category> GetCategories()
        {
            return CategoryDAO.GetInstance.GetCategories();
        }

        public Category GetCategoryById(int categoryId)
        {
            return CategoryDAO.GetInstance.GetCategoryById(categoryId);
        }

        public Category UpdateCategory(int categoryId, CategoryRequest request)
        {
            return CategoryDAO.GetInstance.UpdateCategory(categoryId, request);
        }
    }
}
