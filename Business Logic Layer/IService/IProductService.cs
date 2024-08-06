using DataAccess.DTO;
using DataAccess.Models;

namespace BusinessLogic.IService
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        Task<Product> CreateProduct(ProductRequest request);
        Task<Product> UpdateProduct(int productId, ProductRequest request);
        Task<bool> DeleteProduct(int productId);
    }
}
