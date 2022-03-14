using System.Text.Json;
using ADO.NET_fundamentals.Models;
using ADO.NET_fundamentals.Repository;
using NUnit.Framework;

namespace RepositoryTests
{
    public class ProductRepositoryTests
    {
        private ProductRepository _productRepository;

        [SetUp]
        public void Setup()
        {
            _productRepository = new ProductRepository();
            InsertInitialProduct();
        }

        [Test]
        public void Create_Product()
        {
            var product = new Product
            { 
                Name = "product",
                Description = "description",
                Weight = 1,
                Height = 1,
                Width = 1,
                Length = 1
            };

            Assert.DoesNotThrow(() => _productRepository.Create(product));
        }

        [Test]
        public void Read_Products()
        {
            var result = _productRepository.Read();

            Assert.NotNull(result);
        }

        [Test]
        public void Update_Product()
        {
            var product = new Product
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
            var result = _productRepository.Read(product.Id);

            Assert.AreEqual(JsonSerializer.Serialize(product), JsonSerializer.Serialize(result));
        }

        [Test]
        public void Delete_Product()
        {
            var product = new Product
            {
                Name = "product",
                Description = "description",
                Weight = 1,
                Height = 1,
                Width = 1,
                Length = 1
            };

            _productRepository.Delete(product.Id);
            var result = _productRepository.Read(product.Id);

            Assert.IsNull(result);
        }

        private Product InsertInitialProduct()
        {
            var product = new Product
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