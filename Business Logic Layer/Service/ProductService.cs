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
    public class ProductService(IProductRepository _productRepository) : IProductService
    {
        public Product CreateProduct(ProductRequest request)
        {
            return _productRepository.CreateProduct(request);
        }

        public bool DeleteProduct(int productId)
        {
            return _productRepository.DeleteProduct(productId);
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public Product UpdateProduct(int productId, ProductRequest request)
        {
            return _productRepository.UpdateProduct(productId, request);
        }
    }
}
