using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPrinciples.DB.Interfaces;
using MVCPrinciples.DB.Models;

namespace MVCPrinciples.Controllers
{
    public class CategoriesController : Controller
    {
        private IRepository _repository;
        public CategoriesController(IRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var categories = _repository.Read<Category>();

            return View(categories);
        }
    }
}
