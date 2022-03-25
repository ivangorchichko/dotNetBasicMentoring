using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MVCPrinciples.DB.Context;
using MVCPrinciples.DB.Interfaces;
using MVCPrinciples.DB.Models;

namespace MVCPrinciples.DB.Repository
{
    public class Repository : IRepository
    {
        private NorthwindContext _context;
        public Repository(NorthwindContext context)
        {
            _context = context;
        }

        public void Create<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> Read<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>();
        }

        public IEnumerable<Product> Read()
        {
            return _context.Products.Include(p => p.Category).Include(p => p.Supplier);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }
    }
}
