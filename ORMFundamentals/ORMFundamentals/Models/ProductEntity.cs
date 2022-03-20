using System;
using System.Collections.Generic;
using System.Text;
using ORMFundamentals.Interfaces;

namespace ORMFundamentals.Models
{
    public class ProductEntity : IGenericProperty
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float Weight { get; set; }

        public float Height { get; set; }

        public float Width { get; set; }

        public float Length { get; set; }
    }
}
