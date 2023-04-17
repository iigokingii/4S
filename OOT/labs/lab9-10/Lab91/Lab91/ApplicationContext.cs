using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab91
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string connectionString = "Server=GOKING;Database=lab9OOTEntity;Trusted_Connection=True;TrustServerCertificate=True;";
            builder.UseSqlServer(connectionString);
        }
       /* public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }*/
    }
}
