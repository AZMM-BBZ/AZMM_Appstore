using Froghopper.Enums;
using Froghopper.models;

namespace AZMM.Server.Services.Interfaces
{
    public interface IAppService
    {
        void AddApp(App app);
        bool BuyApp(App app);
        void DeleteApp(App app);
        Stream GetAppFile(int appId);
        List<App> GetAppsOwendByUser();
        List<App> GetAppsWithCategory(Category category);
        void UpdateApp(App app);
    }
}