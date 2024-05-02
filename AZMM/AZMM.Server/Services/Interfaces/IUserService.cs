using Froghopper.models;

namespace AZMM.Server.Services.Interfaces
{
    public interface IUserService
    {
        User GetUserFromDatabase(string username, string password);
        List<User> GetUsersFromDatabase();
    }
}