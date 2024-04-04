using Froghopper.models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security;

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

        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<App> App { get; set; }
    }
}
