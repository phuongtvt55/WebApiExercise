using BusinessLogic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.IService;
using DataAccess.IRepository;
using Moq;
using DataAccess.DTO;
using DataAccess.Models;

namespace BusinessLogic.Service.Tests
{
    [TestClass()]
    public class ProductServiceTests
    {
        private readonly ProductService _productService;
        private readonly Mock<IProductRepository> _mockProductRepository;

        public ProductServiceTests()
        {
            _mockProductRepository = new Mock<IProductRepository>();
            _productService = new ProductService(_mockProductRepository.Object);
        }

        [TestMethod]
        public void CreateProduct_WhenCreateSuccess_ReturnProduct()
        {
            // Arrange
            var request = new ProductRequest
            {
                Name = "Test Product",
                Description = "Test Description",
                Price = 100m,
                Quantity = 10,
                CategoryId = 1
            };
            var product = new Product
            {
                ProductId = 1,
                Name = "Test Product",
                Description = "Test Description",
                Price = 100m,
                Quantity = 10,
                CategoryId = 1
            };
            _mockProductRepository.Setup(repo => repo.CreateProduct(request)).Returns(product);

            // Act
            var result = _productService.CreateProduct(request);

            // Assert
            Assert.AreEqual(product, result);
        }

        [TestMethod]
        public void CreateProduct_WhenProductIsInvalid_ReturnNull()
        {
            // Arrange
            var invalidRequest = new ProductRequest
            {
                Name = "",
                Description = "",
                Price = -1m, 
                Quantity = 10,
                CategoryId = 1
            };

            // Act
            var result = _productService.CreateProduct(invalidRequest);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void DeleteProduct_WhenDeleteSuccess_ReturnTrue()
        {
            // Arrange
            int productId = 5;         
            _mockProductRepository.Setup(repo => repo.DeleteProduct(productId)).Returns(true);

            // Act
            var result = _productService.DeleteProduct(productId);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeleteProduct_WhenIdNotFound_ReturnFalse()
        {
            // Arrange
            int productId = 1;

            // Act
            var result = _productService.DeleteProduct(productId);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetProductById_WhenGetSuccess_ReturnProduct()
        {
            // Arrange
            int productId = 1;
            var product = new Product
            {
                ProductId = productId,
                Name = "Test Product",
                Description = "Test Description",
                Price = 100m,
                Quantity = 10,
                CategoryId = 1
            };
            _mockProductRepository.Setup(repo => repo.GetProductById(productId)).Returns(product);

            // Act
            var result = _productService.GetProductById(productId);

            // Assert
            Assert.AreEqual(product, result);
        }

        [TestMethod]
        public void GetProductById_WhenIdNotFound_ReturnNull()
        {
            // Arrange
            int productId = 1;

            // Act
            var result = _productService.GetProductById(productId);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetProducts_WhenGetSuccess_ReturnProducts()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product
                {
                    ProductId = 1,
                    Name = "Test Product",
                    Description = "Test Description",
                    Price = 100m,
                    Quantity = 10,
                    CategoryId = 1
                }
            };
            _mockProductRepository.Setup(repo => repo.GetProducts()).Returns(products);

            // Act
            var result = _productService.GetProducts();

            // Assert
            Assert.AreEqual(products, result);
        }

        [TestMethod]
        public void UpdateProduct_WhenUpdateSuccess_ReturnProduct()
        {
            // Arrange
            int productId = 1;
            var request = new ProductRequest
            {
                Name = "Updated Product",
                Description = "Updated Description",
                Price = 150m,
                Quantity = 20,
                CategoryId = 2
            };
            var product = new Product
            {
                ProductId = productId,
                Name = "Updated Product",
                Description = "Updated Description",
                Price = 150m,
                Quantity = 20,
                CategoryId = 2
            };
            _mockProductRepository.Setup(repo => repo.UpdateProduct(productId, request)).Returns(product);

            // Act
            var result = _productService.UpdateProduct(productId, request);

            // Assert
            Assert.AreEqual(product, result);
        }

        [TestMethod]
        public void UpdateProduct_WhenProductIsInvalid_ReturnNull()
        {
            // Arrange
            int productId = 1;
            var request = new ProductRequest
            {
                Name = "",
                Description = "",
                Price = 150m,
                Quantity = 20,
                CategoryId = 2
            };

            // Act
            var result = _productService.UpdateProduct(productId, request);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void UpdateProduct_WhenNotFoundId_ReturnNull()
        {
            // Arrange
            int productId = 1;
            var request = new ProductRequest
            {
                Name = "Updated Product",
                Description = "Updated Description",
                Price = 150m,
                Quantity = 20,
                CategoryId = 2
            };

            // Act
            var result = _productService.UpdateProduct(productId, request);

            // Assert
            Assert.IsNull(result);
        }
    }
}