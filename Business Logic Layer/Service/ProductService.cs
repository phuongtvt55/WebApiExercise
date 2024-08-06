using BusinessLogic.IService;
using DataAccess.DTO;
using DataAccess.IRepository;
using DataAccess.Models;

namespace BusinessLogic.Service
{
    public class ProductService(IProductRepository _productRepository) : IProductService
    {
        public async Task<Product> CreateProduct(ProductRequest request)
        {
            return await _productRepository.CreateProduct(request);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            return await _productRepository.DeleteProduct(productId);
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _productRepository.GetProductById(id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productRepository.GetProducts();
        }

        public async Task<Product> UpdateProduct(int productId, ProductRequest request)
        {
            return await _productRepository.UpdateProduct(productId, request);
        }
    }
}
