using System;
using System.Collections.Generic;
using System.Text;
using MVCPrinciples.DB.Models;

namespace MVCPrinciples.DB.Interfaces
{
    public interface IRepository
    {
        void Create<TEntity>(TEntity entity) where TEntity : class;

        IEnumerable<TEntity> Read<TEntity>() where TEntity : class;

        void Update<TEntity>(TEntity entity) where TEntity : class;

        void Delete<TEntity>(TEntity entity) where TEntity : class;

        IEnumerable<Product> Read();
    }
}
