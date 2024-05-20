using AZMM.Server.Services.Interfaces;
using Froghopper.Context;
using Froghopper.Enums;
using Froghopper.models;
using System.IO.Compression;

namespace AZMM.Server.Services
{
    public class AppService : IAppService
    {
        private readonly ILogger<AppService> _logger;
        private readonly AzmmDbContext _azmmDbContext;
        private readonly IUserService _userService;

        public AppService(ILogger<AppService> logger, AzmmDbContext azmmDbContext, IUserService userService)
        {
            _logger = logger;
            _azmmDbContext = azmmDbContext;
            _userService = userService;
        }

        public Stream GetAppFile(int appId)
        {
            var app = _azmmDbContext.App.First(x => x.Aid == appId);


            using (var zipFileStream = new FileStream(@"C:\temp\temp2.zip", FileMode.CreateNew))
            {
                using (var archive = new ZipArchive(zipFileStream, ZipArchiveMode.Create, true))
                {

                    using MemoryStream responseStream = new MemoryStream();
                    Stream fileStream = System.IO.File.Open("C:\\ProgramData\\AZMM\\Metadata\\apps\\npp.8.5.8.Installer.x64.exe", FileMode.Open);

                    var AppbyteArray = new byte[1024];
                    using (BinaryReader br = new BinaryReader(fileStream))
                    {
                        var b = br.ReadBytes((int)fileStream.Length);
                    }

 
                    var zipArchiveEntry = archive.CreateEntry(app.FileName, CompressionLevel.Fastest);
                    var zipStream = zipArchiveEntry.Open();
                    zipStream.Write(AppbyteArray, 0, AppbyteArray.Length);
                    return zipStream;
                }
            }
        }

        public List<App> GetAppsWithCategory(Category category)
        {
            _logger.LogDebug("Getting all apps with category" + category);
            return _azmmDbContext.App.Where(x => x.Category == category).ToList();
        }

        public List<App> GetAppsOwendByUser()
        {
            return _userService.GetCurrentUser().OwendApps;
        }

        public void AddApp(App app)
        {
            _logger.LogDebug("Adding app: " + app.Name);
            _azmmDbContext.App.Add(app);
            _azmmDbContext.SaveChanges();
        }

        public void UpdateApp(App app)
        {
            _logger.LogDebug("Updating app: " + app.Name);
            _azmmDbContext.App.Update(app);
            _azmmDbContext.SaveChanges();
        }

        public void DeleteApp(App app)
        {
            _logger.LogDebug("Deleting app: " + app.Name);
            _azmmDbContext.App.Remove(app);
            _azmmDbContext.SaveChanges();
        }

        public bool BuyApp(App app)
        {
            var user = _userService.GetCurrentUser();
            user.OwendApps.Add(app);
            _userService.UpdateUser(user);
            return true;
        }
    }
}
