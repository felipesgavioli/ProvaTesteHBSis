

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ProvaHBSis.Domain.Interfaces.Repositories;
using ProvaHBSis.Infra.Data.Contexto;

namespace ProvaHBSis.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected ProjetoModeloContext Db = new ProjetoModeloContext();

        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> expr)
        {
            return Db.Set<TEntity>().Where(expr);
        }

        public TEntity Get(Func<TEntity, bool> expr)
        {
            return Db.Set<TEntity>().FirstOrDefault(expr);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
