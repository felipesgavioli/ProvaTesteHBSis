using System;
using System.Collections.Generic;

namespace ProvaHBSis.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> Find(Func<TEntity, bool> expr);
        TEntity Get(Func<TEntity, bool> expr);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}
