using Projet.DAL.Contracts;
using Projet.Entities;
using System;
using System.Collections.Generic;

namespace Projet.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<Type, IRepository> _repositories;

        public UnitOfWork(IServiceProvider serviceProvider)
        {
            // Initialize the dictionary dynamically from the DI container
            _repositories = new Dictionary<Type, IRepository>
            {
                { typeof(User), serviceProvider.GetService(typeof(IRepository<User>)) as IRepository<User> },
                { typeof(Client), serviceProvider.GetService(typeof(IRepository<Client>)) as IRepository<Client> }
            };
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            if (_repositories.TryGetValue(typeof(T), out var repository))
            {
                return (IRepository<T>)repository;
            }

            throw new KeyNotFoundException($"No repository found for type {typeof(T).Name}");
        }

        public void Add<T>(T entity) where T : class
        {
            GetRepository<T>().Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            GetRepository<T>().Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            GetRepository<T>().Delete(entity);
        }

        public void SaveChanges()
        {
            foreach (var repository in _repositories.Values)
            {
                repository.Submit();
            }
        }

        public async Task SaveChangesAsync()
        {
            foreach (var repository in _repositories.Values)
            {
                await Task.Run(() => repository.Submit());
            }
        }
    }
}
