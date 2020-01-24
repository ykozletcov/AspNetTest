using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetTest.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetTest.Repository
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            DBConnection dbConnection = new DBConnection();
            optionsBuilder.UseNpgsql(dbConnection.GetConnectionString(),
                options => options.SetPostgresVersion(new Version(9, 6)));
        }
    }
}
