using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ORMFundamentals.Context;
using ORMFundamentals.Interfaces;
using ORMFundamentals.Models;

namespace ORMFundamentals.Repository
{
    public class Repository
    {
        public Repository(OrderContext context)
        {
            _context = context;
        }

        private readonly OrderContext _context;

        public void Create<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> Read<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>();
        }

        public TEntity ReadById<TEntity>(int id) where TEntity : class, IGenericProperty
        {
            var entities = Read<TEntity>();
            return entities.FirstOrDefault(e => e.Id == id);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<OrderEntity> Read(int? month = null,
            OrderStatus? status = null,
            int? year = null,
            int? productId = null)
        {
            var statusParam = new SqlParameter("@status", status);
            var monthParam = new SqlParameter("@month", month);
            var yearParam = new SqlParameter("@year", year);
            var productIdParam = new SqlParameter("@productId", productId);
            return _context.Orders.FromSqlRaw("GetOrders @status,@month,@year,@productId", statusParam, monthParam, yearParam, productIdParam).ToList();
        }

        public void Delete(int? month = null,
            OrderStatus? status = null,
            int? year = null,
            int? productId = null)
        {
            var statusParam = new SqlParameter("@status", status);
            var monthParam = new SqlParameter("@month", month);
            var yearParam = new SqlParameter("@year", year);
            var productIdParam = new SqlParameter("@productId", productId);

            _context.Database.ExecuteSqlInterpolated($"DeleteOrders {statusParam}, {monthParam}, {yearParam}, {productIdParam}");
        }
    }
}
