using DataAccess.DTO;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
        Product CreateProduct(ProductRequest request);
        Product UpdateProduct(int productId, ProductRequest request);
        bool DeleteProduct(int productId);
    }
}
