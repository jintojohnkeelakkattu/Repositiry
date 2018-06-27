﻿using System;
using System.Linq;
using System.Threading.Tasks;

namespace JobMaster
{
    public interface IRepository:IDisposable, IUnitOfWork
    {
        IQueryable<T> GetAll<T>() where T: class;
        void Add<T>(T entity) where T : class;
        //Task Update<T>() where T : class;
        //Task Delete<T>() where T : class;
    }
}
