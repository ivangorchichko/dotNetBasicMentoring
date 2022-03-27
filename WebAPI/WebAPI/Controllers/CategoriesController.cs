using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.DB.Context;
using WebAPI.DB.Models;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly NorthwindContext _context;
        public CategoriesController(NorthwindContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var products = _context.Categories.ToArray();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var product = _context.Categories.FirstOrDefault(p => p.CategoryId == id);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return CreatedAtAction(
                "GetCategory",
                new { id = category.CategoryId},
                category
            );
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory([FromRoute] int id, [FromBody] Category category)
        {
            if (id != category.CategoryId)
            {
                BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                if (_context.Categories.FirstOrDefault(p => p.CategoryId == id) == null)
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(p => p.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return Ok(category);
        }
    }
}
