using DataAccess.Config;
using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class ProductDAO
    {
        private static ProductDAO instance;
        private static readonly object instanceLock = new object();
        public static ProductDAO GetInstance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var listProduct = new List<Product>();
            try
            {
                using var context = new ExerciseDbContext();
                listProduct = await context.Products.Include(c => c.Category).AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listProduct;
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = new Product();

            try
            {
                using var context = new ExerciseDbContext();
                product = await context.Products.Where(p => p.ProductId == id).AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return product;
        }

        public async Task<Product> CreateProduct(ProductRequest request)
        {
            Product product = new Product();
            try
            {
                using var context = new ExerciseDbContext();

                var mapper = MapperConfig.InititalizeAutomapper();
                product = mapper.Map(request, product);

                await context.Products.AddAsync(product);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return product;
        }

        public async Task<Product> UpdateProduct(int productId, ProductRequest request)
        {
            var product = new Product();
            try
            {
                using var context = new ExerciseDbContext();

                product = await context.Products.Where(p => p.ProductId == productId).SingleOrDefaultAsync();
                if (product == null)
                {
                    return null;
                }

                var mapper = MapperConfig.InititalizeAutomapper();
                product = mapper.Map(request, product);

                context.Products.Update(product);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                using var context = new ExerciseDbContext();

                var product = await context.Products.Where(p => p.ProductId == productId).SingleOrDefaultAsync();
                if (product == null)
                {
                    return false;
                }

                context.Products.Remove(product);
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
