using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCPrinciples.DB.Models;

namespace MVCPrinciples.Models
{
    public class ProductViewModel
    {
        public IEnumerable<Product> Product { get; set; }

        public int ProductId { get; set; }


        [Required(ErrorMessage = "Пожалуйста, введите имя продукта")]
        [DataType(DataType.Text)]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите кол-во на еденицу товара")]
        [DataType(DataType.Text)]
        public string QuantityPerUnit { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите цену продукта")]
        [DataType(DataType.Currency, ErrorMessage = "Неверный ввод цены")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите кол-во на складе")]
        [DataType(DataType.Currency, ErrorMessage = "Неверный ввод кол-ва")]
        [Range(0, 100, ErrorMessage = "Выход за диопозон от 0 до 100")]
        public short UnitsInStock { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите кол-во в заказе")]
        [DataType(DataType.Currency, ErrorMessage = "Неверный ввод кол-ва")]
        [Range(0, 100, ErrorMessage = "Выход за диопозон от 0 до 100")]
        public short UnitsOnOrder { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите Уровень переупорядочивания")]
        [DataType(DataType.Currency, ErrorMessage = "Неверный Уровень переупорядочивания")]
        public short ReorderLevel { get; set; }

        [Required(ErrorMessage = "Пожалуйста, выберите")]
        public bool Discontinued { get; set; }

        public int ShowProductsNumber { get; set; }

        [Required]
        public int SupplierId { get; set; }

        public SelectList SupplierList { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public SelectList CategoryList { get; set; }
    }
}
