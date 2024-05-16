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

        public void GetAppFile()
        {

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
