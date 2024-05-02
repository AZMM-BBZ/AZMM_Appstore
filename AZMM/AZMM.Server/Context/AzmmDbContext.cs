﻿using AZMM.Server.Models;
using Froghopper.models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security;
using System.Security.Permissions;

namespace Froghopper.Context
{
    public class AzmmDbContext : DbContext
    {

        public AzmmDbContext()
        {
            this.Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var applicationDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

            var directory = Path.Combine(applicationDataFolder, "AZMM", "Metadata");
            var databaseName = "MetadataService.db";
            var databaseLocation = Path.Combine(directory, databaseName);

            Directory.CreateDirectory(directory);

            optionsBuilder.UseSqlite("Data Source=" + databaseLocation + ";");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("NOCASE");

            var userRole = new Role { Rid = 1, RoleName = "User" };
            var authorRole = new Role { Rid = 2, RoleName = "Author" };
            var adminRole = new Role { Rid = 3, RoleName = "ElevatedAuthor" };
            var elevatedAuthorRole = new Role { Rid = 4, RoleName = "Admin" };

            var adminUser = new User { Uid = 1, Name = "admin", Password = "lauqssiws$09", Email = "test@test.com", RoleId = 3 };
            var user = new User { Uid = 2, Name = "user", Password = "user", Email = "test@test.com", RoleId = 1 };


            var notepad = new App { Aid = 1, Name = "Notepad++", Description = "Notepad", Category = Enums.Category.Work, ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/6/69/Notepad%2B%2B_Logo.svg", Price = 0, Title = "Notenote" };

            modelBuilder.Entity<App>().HasData(notepad);
            modelBuilder.Entity<Role>().HasData(adminRole, authorRole, userRole, elevatedAuthorRole);
            modelBuilder.Entity<User>().HasData(adminUser, user);
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<App> App { get; set; }
    }
}
