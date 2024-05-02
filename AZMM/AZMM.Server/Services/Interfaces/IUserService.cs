using Froghopper.models;

namespace AZMM.Server.Services.Interfaces
{
    public interface IUserService
    {
        void AddUser(User user);
        void DeleteUser(User user);
        User GetUserFromDatabase(string username, string password);
        List<User> GetUsersFromDatabase();
        void UpdateUser(User user);
    }
}