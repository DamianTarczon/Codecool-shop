using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
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
        public void GetProductsForCategory()
        {
            //arrange using NSubstitute
            var exampleResponseForProductCategoryDao = Substitute.For<ProductCategory>();
            var exampleResponseForProductDao = Substitute.For<IEnumerable<Product>>();
            IEnumerable<Product> expectedResult = Substitute.For<IEnumerable<Product>>();
            
            var supplierDao = Substitute.For<SupplierDaoDb>();

            var productCategoryDao = Substitute.For<ProductCategoryDaoDb>();
            productCategoryDao.Get(Arg.Any<int>()).ReturnsForAnyArgs(exampleResponseForProductCategoryDao);

            var productDao = Substitute.For<ProductDaoDb>();
            productDao.GetBy(Arg.Any<ProductCategory>()).ReturnsForAnyArgs(exampleResponseForProductDao);

            var productService = new ProductService(productDao, productCategoryDao, supplierDao);

            var result = productService.GetProductsForCategory(1);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void GetProductReturnsProductWhenExists()
        {
            //arrange
            var product = new Product() { Id = 1, Name = "cos tam" };

            var productDao = Substitute.For<IProductDao>();
            productDao.Get(Arg.Any<int>()).ReturnsForAnyArgs(product);

            var productService = new ProductService(productDao, null, null);

            // act
            var result = productService.GetProduct(1);

            //assert
            Assert.AreEqual(1, result.Id);
        }
    }
}