using DataAccess.DTO;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;
        private static readonly object instanceLock = new object();
        public static CategoryDAO GetInstance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CategoryDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            var listCategory = new List<Category>();
            try
            {
                using var context = new ExerciseDbContext();
                listCategory = context.Categories.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listCategory;
        }

        public Category GetCategoryById(int id)
        {
            var category = new Category();

            try
            {
                using var context = new ExerciseDbContext();
                category = context.Categories.Where(p => p.CategoryId == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return category;
        }

        public Category CreateCategory(CategoryRequest request)
        {
            Category category = new Category();
            try
            {
                using var context = new ExerciseDbContext();

                category.CategoryName = request.CategoryName;
                context.Categories.Add(category);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return category;
        }

        public Category UpdateCategory(int categoryId, CategoryRequest request)
        {
            var category = new Category();
            try
            {
                using var context = new ExerciseDbContext();

                category = context.Categories.Where(p => p.CategoryId == categoryId).SingleOrDefault();
                if (category == null)
                {
                    throw new Exception("Category not exist");
                }

                category.CategoryName = request.CategoryName;
                context.Categories.Update(category);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return category;
        }

        public bool DeleteCategory(int categoryId)
        {
            try
            {
                using var context = new ExerciseDbContext();

                var category = context.Categories.Where(p => p.CategoryId == categoryId).SingleOrDefault();
                if (category == null)
                {
                    throw new Exception("Category not exist");
                }

                context.Categories.Remove(category);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }
    }
}
