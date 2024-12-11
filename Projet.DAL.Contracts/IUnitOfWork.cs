using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projet.DAL.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : class;

        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
