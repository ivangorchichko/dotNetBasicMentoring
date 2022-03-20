using System;
using System.ComponentModel.DataAnnotations.Schema;
using ORMFundamentals.Interfaces;

namespace ORMFundamentals.Models
{
    public class OrderEntity : IGenericProperty
    {
        public int Id { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int ProductId { get; set; }
    }
    public enum OrderStatus
    {
        Null,
        NotStarted,
        Loading,
        InProgress,
        Arrived,
        Unloading,
        Cancelled,
        Done
    }
}
