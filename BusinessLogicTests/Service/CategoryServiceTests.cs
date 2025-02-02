﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.IRepository;
using Moq;
using BusinessLogic.IService;
using DataAccess.DTO;
using DataAccess.Models;

namespace BusinessLogic.Service.Tests
{
    [TestClass()]
    public class CategoryServiceTests
    {
        private readonly ICategoryService _categoryService;
        private readonly Mock<ICategoryRepository> _mockCategoryRepository;

        public CategoryServiceTests()
        {
            _mockCategoryRepository = new Mock<ICategoryRepository>();
            _categoryService = new CategoryService(_mockCategoryRepository.Object);

        }
        [TestMethod]
        public void CreateCategory_WhenCreateSuccess_ReturnCategory()
        {
            // Arrange
            var request = new CategoryRequest
            {
                CategoryName = "Test Category"
            };
            var category = new Category
            {
                CategoryId = 1,
                CategoryName = "Test Category"
            };
            _mockCategoryRepository.Setup(repo => repo.CreateCategory(request)).Returns(category);

            // Act
            var result = _categoryService.CreateCategory(request);

            // Assert
            Assert.AreEqual(category, result);
        }

        [TestMethod]
        public void CreateCategory_WhenCategoryIsInvalid_ReturnNull()
        {
            // Arrange
            var invalidRequest = new CategoryRequest
            {
                CategoryName = ""
            };

            // Act
            var result = _categoryService.CreateCategory(invalidRequest);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void UpdateCategory_WhenUpdateSuccess_ReturnCategory()
        {
            // Arrange
            int categoryId = 1;
            var request = new CategoryRequest
            {
                CategoryName = "Updated Category"
            };
            var category = new Category
            {
                CategoryId = categoryId,
                CategoryName = "Updated Category"
            };
            _mockCategoryRepository.Setup(repo => repo.UpdateCategory(categoryId, request)).Returns(category);

            // Act
            var result = _categoryService.UpdateCategory(categoryId, request);

            // Assert
            Assert.AreEqual(category, result);
        }

        [TestMethod]
        public void UpdateCategory_WhenProductIsInvalid_ReturnNull()
        {
            // Arrange
            int categoryId = 1;
            var invalidRequest = new CategoryRequest
            {
                CategoryName = ""
            };

            // Act
            var result = _categoryService.UpdateCategory(categoryId, invalidRequest);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void UpdateCategory_WhenNotFoundId_ReturnNull()
        {
            // Arrange
            int categoryId = 1;
            var category = new CategoryRequest
            {
                CategoryName = "Update Category"
            };

            // Act
            var result = _categoryService.UpdateCategory(categoryId, category);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void DeleteCategory_WhenDeleteSuccess_ReturnTrue()
        {
            // Arrange
            int categoryId = 1;
            _mockCategoryRepository.Setup(repo => repo.DeleteCategory(categoryId)).Returns(true);

            // Act
            var result = _categoryService.DeleteCategory(categoryId);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeleteCategory_WhenNotFoundId_ReturnFalse()
        {
            // Arrange
            int categoryId = 1;

            // Act
            var result = _categoryService.DeleteCategory(categoryId);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetCategoryById_WhenGetSuccess_ReturnCategory()
        {
            // Arrange
            int categoryId = 1;
            var category = new Category
            {
                CategoryId = categoryId,
                CategoryName = "Test Category"
            };
            _mockCategoryRepository.Setup(repo => repo.GetCategoryById(categoryId)).Returns(category);

            // Act
            var result = _categoryService.GetCategoryById(categoryId);

            // Assert
            Assert.AreEqual(category, result);
        }

        [TestMethod]
        public void GetCategoryById_WhenNotFoundId_ReturnNull()
        {
            // Arrange
            int categoryId = 1;

            // Act
            var result = _categoryService.GetCategoryById(categoryId);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetCategories_WhenGetSuccess_ReturnCategories()
        {
            // Arrange
            var categories = new List<Category>
            {
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Test Category"
                }
            };
            _mockCategoryRepository.Setup(repo => repo.GetCategories()).Returns(categories);

            // Act
            var result = _categoryService.GetCategories();

            // Assert
            Assert.AreEqual(categories, result);
        }

    }
}