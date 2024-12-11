using Projet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();

        // Get user by ID
        User GetUserById(int id);

        // Add a new user
        void AddUser(User user);

        // Update an existing user
        void UpdateUser(User user);

        // Delete a user by ID
        void DeleteUser(int id);
    }
}
