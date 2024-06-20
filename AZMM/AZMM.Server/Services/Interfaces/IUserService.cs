using Froghopper.models;

namespace AZMM.Server.Services.Interfaces
{
    public interface IUserService
    {
        User GetCurrentUser();
        bool AddUser(User user);
        bool DeleteUser(User user);
        User GetUserFromDatabase(string username, string password);
        List<User> GetUsersFromDatabase();
        bool UpdateUser(User user);
    }
}