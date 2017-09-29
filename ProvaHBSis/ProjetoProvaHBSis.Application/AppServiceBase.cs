

using System;
using System.Collections.Generic;
using ProvaHBSis.Application.Interface;
using ProvaHBSis.Domain.Interfaces.Services;

namespace ProvaHBSis.Application
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Add(TEntity obj)
        {
            _serviceBase.Add(obj);
        }

        public TEntity GetById(int id)
        {
            return _serviceBase.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public void Update(TEntity obj)
        {
            _serviceBase.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _serviceBase.Remove(obj);
        }


        public IEnumerable<TEntity> Find(Func<TEntity, bool> expr)
        {
            return _serviceBase.Find(expr);
        }

        public TEntity Get(Func<TEntity, bool> expr)
        {
            return _serviceBase.Get(expr);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }
    }
}
