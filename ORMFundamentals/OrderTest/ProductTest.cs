using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using NUnit.Framework;
using ORMFundamentals.Context;
using ORMFundamentals.Models;
using ORMFundamentals.Repository;

namespace RepositoryTestEF
{
    public class ProductTest
    {
        private Repository _productRepository;

        [SetUp]
        public void Setup()
        {
            _productRepository = new Repository(new OrderContext());
            InsertInitialProduct();
        }

        [Test]
        public void Create_Product()
        {
            var product = new ProductEntity
            {
                Name = "product",
                Description = "description",
                Weight = 1,
                Height = 1,
                Width = 1,
                Length = 1,
            };

            Assert.DoesNotThrow(() => _productRepository.Create(product));
        }

        [Test]
        public void Read_Products()
        {
            var result = _productRepository.Read<ProductEntity>();

            Assert.NotNull(result);
        }

        [Test]
        public void Update_Product()
        {
            var product = new ProductEntity
            {
                Name = "product",
                Description = "description",
                Weight = 1,
                Height = 1,
                Width = 1,
                Length = 1
            };

            _productRepository.Create(product);

            product.Name = "updateProduct";
            product.Description = "updateDescription";
            _productRepository.Update(product);
            var result = _productRepository.ReadById<ProductEntity>(product.Id);

            Assert.AreEqual(JsonSerializer.Serialize(product), JsonSerializer.Serialize(result));
        }

        [Test]
        public void Delete_Product()
        {
            var product = new ProductEntity
            {
                Name = "product",
                Description = "description",
                Weight = 1,
                Height = 1,
                Width = 1,
                Length = 1,
                Id = 1
            };

            _productRepository.Delete(product);
            var result = _productRepository.ReadById<ProductEntity>(product.Id);

            Assert.IsNull(result);
        }

        private ProductEntity InsertInitialProduct()
        {
            var product = new ProductEntity()
            {
                Name = "product",
                Description = "description",
                Weight = 1,
                Height = 1,
                Width = 1,
                Length = 1
            };

            _productRepository.Create(product);

            return product;
        }
    }
}
