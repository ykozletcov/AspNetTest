using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetTest.Models;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;

namespace AspNetTest.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }


        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            ConfigLoader loader = new ConfigLoader();
            optionsBuilder.UseNpgsql(loader.Config.ConnectionString.GetConnectionString(),
                options => options.SetPostgresVersion(new Version(9, 6)));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRoles>()
                .HasKey(t => new { t.UserId, t.RoleId });

            modelBuilder.Entity<UserRoles>()
                .HasOne(sc => sc.User)
                .WithMany(s => s.UserRoles)
                .HasForeignKey(sc => sc.UserId);

            modelBuilder.Entity<UserRoles>()
                .HasOne(sc => sc.Role)
                .WithMany(c => c.UserRoles)
                .HasForeignKey(sc => sc.RoleId);
        }
    }
}
