using System.Text.Json.Serialization;

namespace ADO.NET_fundamentals.Models
{
    public class Product
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float Weight { get; set; }

        public float Height { get; set; }

        public float Width { get; set; }

        public float Length { get; set; }
    }
}
