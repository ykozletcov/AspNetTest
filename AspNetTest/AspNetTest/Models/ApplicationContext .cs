﻿using System;
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
        public DbSet<UserRolesCollectionRow> UserRolesCollections { get; set; }


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
    }
}
