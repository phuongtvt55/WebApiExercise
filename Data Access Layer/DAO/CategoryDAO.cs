using DataAccess.Config;
using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var listCategory = new List<Category>();
            try
            {
                using var context = new ExerciseDbContext();
                listCategory = await context.Categories.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listCategory;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var category = new Category();

            try
            {
                using var context = new ExerciseDbContext();
                category = await context.Categories.Where(p => p.CategoryId == id).AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return category;
        }

        public async Task<Category> CreateCategory(CategoryRequest request)
        {
            Category category = new Category();
            try
            {
                using var context = new ExerciseDbContext();

                var mapper = MapperConfig.InititalizeAutomapper();
                category = mapper.Map(request, category);

                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return category;
        }

        public async Task<Category> UpdateCategory(int categoryId, CategoryRequest request)
        {
            var category = new Category();
            try
            {
                using var context = new ExerciseDbContext();

                category = await context.Categories.Where(p => p.CategoryId == categoryId).SingleOrDefaultAsync();
                if (category == null)
                {
                    throw new Exception("Category not exist");
                }

                var mapper = MapperConfig.InititalizeAutomapper();
                category = mapper.Map(request, category);

                context.Categories.Update(category);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return category;
        }

        public async Task<bool> DeleteCategory(int categoryId)
        {
            try
            {
                using var context = new ExerciseDbContext();

                var category = await context.Categories.Where(p => p.CategoryId == categoryId).SingleOrDefaultAsync();
                if (category == null)
                {
                    throw new Exception("Category not exist");
                }

                context.Categories.Remove(category);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }
    }
}
