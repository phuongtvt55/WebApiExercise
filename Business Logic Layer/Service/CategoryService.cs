using BusinessLogic.IService;
using DataAccess.DAO;
using DataAccess.DTO;
using DataAccess.IRepository;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public class CategoryService(ICategoryRepository _categoryRepository) : ICategoryService
    {
        public Category CreateCategory(CategoryRequest request)
        {
            return _categoryRepository.CreateCategory(request);
        }

        public bool DeleteCategory(int categoryId)
        {
            return _categoryRepository.DeleteCategory(categoryId);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categoryRepository.GetCategories();
        }

        public Category GetCategoryById(int categoryId)
        {
            return _categoryRepository.GetCategoryById(categoryId);
        }

        public Category UpdateCategory(int categoryId, CategoryRequest request)
        {
            return _categoryRepository.UpdateCategory(categoryId, request);
        }
    }
}
