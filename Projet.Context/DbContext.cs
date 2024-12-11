using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Projet.Context; 
using Projet.Entities;

namespace Projet.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {

        public DataContext CreateDbContext(string[] args)
        {
            // Création d'un DbContextOptionsBuilder avec la configuration de votre base de données
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                         Initial Catalog=ProjetAziz;
                                         Integrated Security=True;MultipleActiveResultSets=True");

            // Retourne une nouvelle instance de DataContext avec les options configurées
            return new DataContext(optionsBuilder.Options);
        }
    }
}
