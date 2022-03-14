using System;
using System.Text.Json.Serialization;

namespace ADO.NET_fundamentals.Models
{
    public class Order
    {
        [JsonIgnore]
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
