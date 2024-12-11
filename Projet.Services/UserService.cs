using Projet.DAL.Contracts;
using Projet.Entities;
using Projet.Services.Interfaces;
using System.Collections.Generic;

namespace Projet.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<User> GetUsers()
        {
            return _unitOfWork.GetRepository<User>().GetAll();
        }

        public User GetUserById(int id)
        {
            return _unitOfWork.GetRepository<User>().GetById(id);
        }

        public void AddUser(User user)
        {
            _unitOfWork.GetRepository<User>().Add(user);
            _unitOfWork.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _unitOfWork.GetRepository<User>().Update(user);
            _unitOfWork.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _unitOfWork.GetRepository<User>().GetById(id);
            if (user != null)
            {
                _unitOfWork.GetRepository<User>().Delete(user);
                _unitOfWork.SaveChanges();
            }
        }
    }
}
