using System;

namespace Task1
{
    public class Product
    {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) throw new ArgumentNullException();

            if (obj.GetType() != this.GetType()) return false;

            Product product = (Product)obj;
            return (this.Name == product.Name && this.Price == product.Price);
        }
    }
}
