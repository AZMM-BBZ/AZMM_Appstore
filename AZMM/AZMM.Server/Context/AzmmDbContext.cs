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

            //var userRole = new Role { Rid = 1, RoleName = "User" };
            //var authorRole = new Role { Rid = 2, RoleName = "Author" };
            //var adminRole = new Role { Rid = 3, RoleName = "ElevatedAuthor" };
            //var elevatedAuthorRole = new Role { Rid = 4, RoleName = "Admin" };

            var adminUser = new User { Uid = 1, Name = "admin", Password = "lauqssiws$09" };
            var user = new User { Uid = 2, Name = "user", Password = "user" };



            var notepad = new App { Aid = 1, Name = "Notepad++", Description = "Notepad", Category = Enums.Category.Work, ImageUrl = "https://localhost:5173/src/assets/Notepad++_Logo.png", FileName = "npp.8.5.8.Installer.x64" };
            var vsCode = new App { Aid = 2, Name = "VS Code", Description = "Notepad", Category = Enums.Category.Work, ImageUrl = "https://localhost:5173/src/assets/visual-studio-code4470.jpg", FileName = "VSCodeUserSetup-x64-1.88.1" };
            var manicDigger = new App { Aid = 3, Name = "Manic Digger", Description = "Notepad", Category = Enums.Category.Game, ImageUrl = "https://localhost:5173/src/assets/manicdigger.png", FileName = "ManicDigger2011-02-12Setup" };
            var jp2 = new App { Aid = 4, Name = "JP2", Description = "Notepad", Category = Enums.Category.Game, ImageUrl = "https://localhost:5173/src/assets/jigsaw.png", FileName = "jp2setup" };
            var fallDies = new App { Aid = 5, Name = "Fall Dies", Description = "Fall guys but not fall guys", Category = Enums.Category.Game, ImageUrl = "https://localhost:5173/src/assets/falldies.png", FileName = "FallDies" };
            var msLemonS = new App { Aid = 6, Name = "MsLemonS", Description = "Notepad", Category = Enums.Category.Game, ImageUrl = "https://localhost:5173/src/assets/ms.lemon.png", FileName = "MsLemonS" };
            var mrTomatoS = new App { Aid = 7, Name = "MrTomatoS", Description = "Notepad", Category = Enums.Category.Game, ImageUrl = "https://localhost:5173/src/assets/mr.tomato.png", FileName = "MrTomatoS" };
            var visualStudio = new App { Aid = 8, Name = "VisualStudio", Description = "Notepad", Category = Enums.Category.Work, ImageUrl = "https://localhost:5173/src/assets/vs2022.jpg", FileName = "VisualStudioSetup (1)" };
            var postman = new App { Aid = 9, Name = "Postman", Description = "Fall guys but not fall guys", Category = Enums.Category.Work, ImageUrl = "https://localhost:5173/src/assets/postman.png", FileName = "Postman-win64-Setup (1)" };
            var office = new App { Aid = 10, Name = "Office", Description = "Notepad", Category = Enums.Category.Work, ImageUrl = "https://localhost:5173/src/assets/office.png", FileName = "OfficeSetup" };
            var fileZilla = new App { Aid = 11, Name = "FileZilla", Description = "Notepad", Category = Enums.Category.Work, ImageUrl = "https://localhost:5173/src/assets/filezilla.png", FileName = "FileZilla_3.66.0_win64_sponsored2-setup" };
            var teams = new App { Aid = 12, Name = "Teams", Description = "Notepad", Category = Enums.Category.Work, ImageUrl = "https://localhost:5173/src/assets/teams.jpg", FileName = "Teams_windows_x64" };
            var ditto = new App { Aid = 13, Name = "Ditto", Description = "Fall guys but not fall guys", Category = Enums.Category.Work, ImageUrl = "https://localhost:5173/src/assets/ditto.png", FileName = "DittoSetup_64bit_3_24_246_0 (1)" };
            var mainFrame = new App { Aid = 14, Name = "Mainframe Blaster", Description = "Notepad", Category = Enums.Category.Game, ImageUrl = "https://localhost:5173/src/assets/blaster.png", FileName = "Mainframe Blaster" };
            var minecraft = new App { Aid = 15, Name = "Minecraft", Description = "Notepad", Category = Enums.Category.Game, ImageUrl = "https://localhost:5173/src/assets/minecraft.jpg", FileName = "MinecraftInstaller (1)" };
            var yoshi = new App { Aid = 16, Name = "Yoshi", Description = "Notepad", Category = Enums.Category.Game, ImageUrl = "https://localhost:5173/src/assets/yoshi.png", FileName = "Yoshi" };

            modelBuilder.Entity<App>().HasData(notepad, vsCode, manicDigger, jp2, fallDies, 
                msLemonS, mrTomatoS, visualStudio, postman, office, fileZilla, teams, ditto, mainFrame, minecraft, yoshi);
            //modelBuilder.Entity<Role>().HasData(adminRole, authorRole, userRole, elevatedAuthorRole);
            modelBuilder.Entity<User>().HasData(adminUser, user);
        }

        //public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<App> App { get; set; }
    }
}
