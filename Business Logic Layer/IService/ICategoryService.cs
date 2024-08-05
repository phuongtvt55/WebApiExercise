using DataAccess.DTO;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int categoryId);
        Category CreateCategory(CategoryRequest request);
        Category UpdateCategory(int categoryId, CategoryRequest request);
        bool DeleteCategory(int categoryId);
    }
}
