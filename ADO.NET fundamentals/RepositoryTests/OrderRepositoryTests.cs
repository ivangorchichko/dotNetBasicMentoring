using System;
using System.Linq;
using System.Text.Json;
using ADO.NET_fundamentals.Models;
using ADO.NET_fundamentals.Repository;
using NUnit.Framework;

namespace RepositoryTests
{
    public class OrderRepositoryTests
    {
        private OrderRepository _orderRepository;

        [SetUp]
        public void Setup()
        {
            _orderRepository = new OrderRepository();
            InitialOrder();
        }

        [Test]
        public void Create_Order()
        {
            var order = new Order
            {
                Status = OrderStatus.Arrived,
                CreatedDate = new DateTime(2022, 1, 1),
                UpdatedDate = new DateTime(2022, 1, 1),
                ProductId = 2
            };

            Assert.DoesNotThrow(() => _orderRepository.Create(order));
        }

        [Test]
        public void Read_Orders()
        {
            var result = _orderRepository.Read(1, OrderStatus.Arrived,2022,1);

            Assert.NotNull(result);
        }

        [Test]
        public void Update_Order()
        {
            var order = new Order
            {
                Id = 9,
                Status = OrderStatus.InProgress,
                CreatedDate = new DateTime(2022, 1, 1),
                UpdatedDate = new DateTime(2022, 1, 1),
                ProductId = 1
            };

            order.Status = OrderStatus.Done;
            order.CreatedDate = new DateTime(2021, 1, 1);
            order.UpdatedDate = new DateTime(2023, 3, 3);
            
            _orderRepository.Update(order);
            var result = _orderRepository.Read(order.CreatedDate.Month, order.Status, order.CreatedDate.Year, order.ProductId).First();

            Assert.AreEqual(JsonSerializer.Serialize(order), JsonSerializer.Serialize(result));
        }

        [Test]
        public void Delete_Order()
        {
            var order = new Order
            {
                Id = 55,
                Status = OrderStatus.InProgress,
                CreatedDate = new DateTime(2022, 1, 1),
                UpdatedDate = new DateTime(2022, 1, 1),
                ProductId = 1
            };

            _orderRepository.Delete(order.Id);
            var result = _orderRepository.Read(order.Id);

            Assert.IsEmpty(result);
        }

        private Order InitialOrder()
        {
            var order = new Order
            {
                Status = OrderStatus.Arrived,
                CreatedDate = new DateTime(2022, 1, 1),
                UpdatedDate = new DateTime(2022, 1, 1),
                ProductId = 1
            };

            _orderRepository.Create(order);

            return order;
        }
    }
}
