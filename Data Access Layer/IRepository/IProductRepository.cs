using DataAccess.DTO;
using DataAccess.Models;

namespace DataAccess.IRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        Task<Product> CreateProduct(ProductRequest request);
        Task<Product> UpdateProduct(int productId, ProductRequest request);
        Task<bool> DeleteProduct(int productId);

    }
}
