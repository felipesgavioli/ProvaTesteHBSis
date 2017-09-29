using System;
using System.Collections.Generic;
using ProvaHBSis.Domain.Interfaces.Repositories;
using ProvaHBSis.Domain.Interfaces.Services;

namespace ProvaHBSis.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _repository.Remove(obj);
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> expr)
        {
            return _repository.Find(expr);
        }

        public TEntity Get(Func<TEntity, bool> expr)
        {
            return _repository.Get(expr);
        }
        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
