using Microsoft.EntityFrameworkCore;
using Projet.Entities;

namespace Projet.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Client> Client { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies()
                              .UseSqlServer(@"Data Source=TN-FYSYTR\SQLEXPRESS;Initial Catalog=Db26112024;Persist Security Info=True;User ID=sa;Password=sa;TrustServerCertificate=True");
            }
        }
    }
}
