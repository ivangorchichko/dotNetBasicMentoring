using Newtonsoft.Json;

namespace WebAPI.DB.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public int SupplierId { get; set; }

        [JsonIgnore]
        public virtual Supplier Supplier { get; set; }

        public int CategoryId { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }

        public string ProductName { get; set; }

        public string QuantityPerUnit { get; set; }

        public decimal UnitPrice { get; set; }

        public short UnitsInStock { get; set; }

        public short UnitsOnOrder { get; set; }

        public short ReorderLevel { get; set; }

        public bool Discontinued { get; set; }
    }
}
