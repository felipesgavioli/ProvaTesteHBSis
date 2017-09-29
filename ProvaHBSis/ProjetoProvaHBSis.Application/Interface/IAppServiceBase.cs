﻿
using System;
using System.Collections.Generic;

namespace ProvaHBSis.Application.Interface
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Func<TEntity, bool> expr);
        TEntity Get(Func<TEntity, bool> expr);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}
