using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.DB.Context;
using WebAPI.DB.Models;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly NorthwindContext _context;
        public ProductsController(NorthwindContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProducts([FromQuery] QueryParameters parameters)
        {
            IQueryable<Product> products = _context.Products;
            if (parameters.PageSize == 0)
                parameters.PageSize = 10;
            if (parameters.PageNumber == 0)
                parameters.PageSize = 1;

            if (parameters.CategoryId != 0)
                products = products
                    .Where(p => p.CategoryId == parameters.CategoryId);

            if (!products.Any())
            {
                NotFound();
            }

            products = products.Skip(parameters.PageSize * (parameters.PageNumber - 1))
                .Take(parameters.PageSize);

            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtAction(
                "GetProduct",
                new { id = product.ProductId },
                product
                );
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct([FromRoute] int id, [FromBody] Product product)
        {
            if (id != product.ProductId)
            {
                BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                if (_context.Products.FirstOrDefault(p => p.ProductId == id) == null)
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return Ok(product);
        }
    }
}
