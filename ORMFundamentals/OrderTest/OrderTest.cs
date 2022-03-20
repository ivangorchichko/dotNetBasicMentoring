using System;
using System.Text.Json;
using NUnit.Framework;
using ORMFundamentals.Context;
using ORMFundamentals.Models;
using ORMFundamentals.Repository;

namespace OrderTest
{
    public class Tests
    {
        private Repository _orderRepository;

        [SetUp]
        public void Setup()
        {
            _orderRepository = new Repository(new OrderContext());
           // InitialOrder();
        }

        [Test]
        public void Create_Order()
        {
            var order = new OrderEntity
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
            var result =  _orderRepository.Read(1, OrderStatus.Arrived, 2022, 1);

            Assert.NotNull(result);
        }

        [Test]
        public void Update_Order()
        {
            var order = new OrderEntity
            {
                Id = 1,
                Status = OrderStatus.InProgress,
                CreatedDate = new DateTime(2022, 1, 1),
                UpdatedDate = new DateTime(2022, 1, 1),
                ProductId = 1
            };

            order.Status = OrderStatus.Done;
            order.CreatedDate = new DateTime(2021, 1, 1);
            order.UpdatedDate = new DateTime(2023, 3, 3);

            _orderRepository.Update(order);
            var result = _orderRepository.ReadById<OrderEntity>(order.Id);

            Assert.AreEqual(JsonSerializer.Serialize(order), JsonSerializer.Serialize(result));
        }

        [Test]
        public void Delete_Orders()
        {
            var order = new OrderEntity()
            {
                Status = OrderStatus.InProgress,
                CreatedDate = new DateTime(2022, 1, 1),
                UpdatedDate = new DateTime(2022, 1, 1),
                ProductId = 1
            };

            _orderRepository.Delete(order.CreatedDate.Month, order.Status, order.CreatedDate.Year, order.ProductId);
            var result = _orderRepository.ReadById<OrderEntity>(order.Id);

            Assert.IsNull(result);
        }

        private OrderEntity InitialOrder()
        {
            var order = new OrderEntity
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