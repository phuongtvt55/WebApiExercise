using DataAccess.DAO;
using DataAccess.DTO;
using DataAccess.IRepository;
using DataAccess.Models;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public async Task<Product> CreateProduct(ProductRequest request)
        {
            return await ProductDAO.GetInstance.CreateProduct(request);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            return await ProductDAO.GetInstance.DeleteProduct(productId);
        }

        public async Task<Product> GetProductById(int id)
        {
            return await ProductDAO.GetInstance.GetProductById(id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await ProductDAO.GetInstance.GetProducts();
        }

        public async Task<Product> UpdateProduct(int productId, ProductRequest request)
        {
            return await ProductDAO.GetInstance.UpdateProduct(productId, request);
        }
    }
}
