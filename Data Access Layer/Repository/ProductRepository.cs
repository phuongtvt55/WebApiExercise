using DataAccess.DTO;
using DataAccess.Models;
using DataAccess.DAO;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public Product CreateProduct(ProductRequest request)
        {
            return ProductDAO.GetInstance.CreateProduct(request);
        }

        public bool DeleteProduct(int productId)
        {
            return ProductDAO.GetInstance.DeleteProduct(productId);
        }

        public Product GetProductById(int id)
        {
            return ProductDAO.GetInstance.GetProductById(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return ProductDAO.GetInstance.GetProducts();
        }

        public Product UpdateProduct(int productId, ProductRequest request)
        {
            return ProductDAO.GetInstance.UpdateProduct(productId, request);
        }
    }
}
