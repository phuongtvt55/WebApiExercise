using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IEnumerable<Product> GetProducts()
        {
            var listProduct = new List<Product>();
            try
            {
                using var context = new ExerciseDbContext();
                listProduct = context.Products.Include(c => c.Category).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listProduct;
        }

        public Product GetProductById(int id)
        {
            var product = new Product();

            try
            {
                using var context = new ExerciseDbContext();
                product = context.Products.Where(p => p.ProductId == id).FirstOrDefault();                
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return product;
        }

        public Product CreateProduct(ProductRequest request)
        {
            Product product = new Product();
            try
            {
                using var context = new ExerciseDbContext();

                product.Name = request.Name;
                product.Description = request.Description;
                product.Price = request.Price;
                product.Quantity = request.Quantity;  
                product.CategoryId = request.CategoryId;
                context.Products.Add(product);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return product;
        }

        public Product UpdateProduct(int productId, ProductRequest request)
        {
            var product = new Product();
            try
            {
                using var context = new ExerciseDbContext();

                product = context.Products.Where(p => p.ProductId == productId).SingleOrDefault();
                if(product == null)
                {
                    return null;
                }

                product.Name = request.Name;
                product.Description = request.Description;
                product.Price= request.Price;
                product.Quantity = request.Quantity;
                product.CategoryId = request.CategoryId;
                context.Products.Update(product);
                context.SaveChanges();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }

        public bool DeleteProduct(int productId)
        {
            try
            {
                using var context = new ExerciseDbContext();

                var product = context.Products.Where(p => p.ProductId == productId).SingleOrDefault();
                if(product == null)
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
