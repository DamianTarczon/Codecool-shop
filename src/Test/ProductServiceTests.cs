using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System.Net;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations.Database;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;

namespace Test
{
    [TestFixture]
    public class ProductServiceTests
    {

        [Test]
        public void GetProductsForCategoryReturnsProductsByCategoryWhenExists()
        {
            //arrange
            var exampleProductCategory = new ProductCategory() { Id = 1};
            var exampleResponseForProductDao = new List<Product>()
            {
                new Product() { Id = 1, ProductCategoryId = 1}, 
                new Product() { Id = 2, ProductCategoryId = 1}
            };

            var productCategoryDao = Substitute.For<IProductCategoryDao>();
            productCategoryDao.Get(1).Returns(exampleProductCategory);

            var productDao = Substitute.For<IProductDao>();
            productDao.GetBy(exampleProductCategory).Returns(exampleResponseForProductDao);

            var productService = new ProductService(productDao, productCategoryDao, null);

            var result = productService.GetProductsForCategory(1);

            foreach (var product in result)
            {
                Assert.AreEqual(typeof(Product), product.GetType());
            }
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public void GetProductReturnsProductWhenExists()
        {
            //arrange
            var product = new Product() { Id = 1, Name = "cos tam" };

            var productDao = Substitute.For<IProductDao>();
            productDao.Get(1).Returns(product);

            var productService = new ProductService(productDao, null, null);

            // act
            var result = productService.GetProduct(1);
            var result2 = productService.GetProduct(2);

            //assert
            Assert.AreEqual(1, result.Id);
            Assert.IsNull(result2);
        }

        [Test]
        public void GetProductWithCategoryAndSupplierReturnsProductSupplierAndCategory()
        {
            var product = new Product() { Id = 1, Name = "cos tam", ProductCategoryId = 1, SupplierId = 2};
            var productCategory = new ProductCategory() { Id = 1, Name = "category" };
            var supplier = new Supplier() { Id = 2, Name = "supplier" };

            product.ProductCategory = productCategory;
            product.Supplier = supplier;

            var productDao = Substitute.For<IProductDao>();
            productDao.GetWithCategoryAndSupplier(1).Returns(product);

            var productService = new ProductService(productDao, null, null);
            var result = productService.GetProductWithCategoryAndSupplier(1);

            Assert.AreEqual(typeof(ProductCategory), result.ProductCategory.GetType());
            Assert.AreEqual(typeof(Supplier), result.Supplier.GetType());

        }
    }
}