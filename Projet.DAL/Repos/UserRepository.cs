using Projet.Context;
using Projet.DAL.Contracts;
using Projet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.DAL.Repos
{
    public class UserRepository : GenericRepository<User>, IRepository<User>
    {
        public UserRepository(DataContext context) : base(context)
        {
        }
    }
}
