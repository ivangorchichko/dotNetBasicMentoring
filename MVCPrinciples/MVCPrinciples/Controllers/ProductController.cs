using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using MVCPrinciples.DB.Interfaces;
using MVCPrinciples.DB.Models;
using MVCPrinciples.Enum;
using MVCPrinciples.Models;

namespace MVCPrinciples.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository _repository;
        private readonly IConfiguration _configuration;
        private readonly IEnumerable<Supplier> _suppliers;
        private readonly IEnumerable<Category> _categories;
        private IEnumerable<Product> _products;
        public ProductController(IRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
            _suppliers = _repository.Read<Supplier>();
            _categories = _repository.Read<Category>();
            _products = _repository.Read();
        }

        public IActionResult Index()
        {
            var productsViewModel = GetProductViewModel(ActionType.None);

            return View(productsViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var productsViewModel = GetProductViewModel(ActionType.Create);

            return View(productsViewModel);
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel clientViewModel)
        {
            var product = new Product()
            {
                Supplier = _suppliers.First(s => s.SupplierId == clientViewModel.SupplierId),
                Category = _categories.First(c => c.CategoryId == clientViewModel.CategoryId),
                Discontinued = clientViewModel.Discontinued,
                ProductName = clientViewModel.ProductName,
                QuantityPerUnit = clientViewModel.QuantityPerUnit,
                ReorderLevel = clientViewModel.ReorderLevel,
                UnitPrice = clientViewModel.UnitPrice,
                UnitsInStock = clientViewModel.UnitsInStock,
                UnitsOnOrder = clientViewModel.UnitsOnOrder
            };
            _repository.Create(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Modify(int? id)
        {
            var product = _repository.Read().First(p => p.ProductId == id);
            var productViewModel = GetProductViewModel(ActionType.Modify, product);

            return View(productViewModel);
        }

        [HttpPost]
        public ActionResult Modify(ProductViewModel clientViewModel)
        {
            if (!ModelState.IsValid)
                return View();

            var product = new Product()
                {
                    Supplier = _suppliers.First(s => s.SupplierId == clientViewModel.SupplierId),
                    Category = _categories.First(c => c.CategoryId == clientViewModel.CategoryId),
                    Discontinued = clientViewModel.Discontinued,
                    ProductName = clientViewModel.ProductName,
                    QuantityPerUnit = clientViewModel.QuantityPerUnit,
                    ReorderLevel = clientViewModel.ReorderLevel,
                    UnitPrice = clientViewModel.UnitPrice,
                    UnitsInStock = clientViewModel.UnitsInStock,
                    UnitsOnOrder = clientViewModel.UnitsOnOrder,
                    ProductId = clientViewModel.ProductId
                };
                _repository.Update<Product>(product);
                return RedirectToAction("Index");
            
        }

        private ProductViewModel GetProductViewModel(ActionType type, Product product = null)
        {
            switch (type)
            {
                case ActionType.None:
                {
                    return new ProductViewModel()
                    {
                        Product = _products,
                        ShowProductsNumber = _configuration.GetValue<int>("NumberOfProductsShown:Maximum")
                    };
                }
                case ActionType.Create:
                {
                    return new ProductViewModel()
                    {
                        //Product = _products,
                        //ShowProductsNumber = _configuration.GetValue<int>("NumberOfProductsShown:Maximum"),
                        CategoryList = new SelectList(_categories, "CategoryId", "CategoryName"),
                        SupplierList = new SelectList(_suppliers, "SupplierId", "CompanyName")
                    };
                }
                case ActionType.Modify:
                {
                    return new ProductViewModel()
                    {
                        //Product = _products,
                        //ShowProductsNumber = _configuration.GetValue<int>("NumberOfProductsShown:Maximum"),
                        CategoryId = product.Category.CategoryId,
                        CategoryList = new SelectList(_categories, "CategoryId", "CategoryName"),
                        SupplierList = new SelectList(_suppliers, "SupplierId", "CompanyName"),
                        Discontinued = product.Discontinued,
                        ProductName = product.ProductName,
                        ProductId = product.ProductId,
                        QuantityPerUnit = product.QuantityPerUnit,
                        ReorderLevel = product.ReorderLevel,
                        UnitPrice = product.UnitPrice,
                        UnitsInStock = product.UnitsInStock,
                        UnitsOnOrder = product.UnitsOnOrder
                    };
                }
            }

            return null;
        }
    }
}
