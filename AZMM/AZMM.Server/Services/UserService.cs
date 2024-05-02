using Froghopper.Context;
using Froghopper.models;
using Microsoft.EntityFrameworkCore;

namespace AZMM.Server.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly AzmmDbContext _azmmDbContext;

        public UserService(ILogger<UserService> logger, AzmmDbContext azmmDbContext)
        {
            _logger = logger;
            _azmmDbContext = azmmDbContext;
        }
        public List<User> GetUsersFromDatabase()
        {
            _logger.LogDebug("Getting all user from db");
            return _azmmDbContext.Users.ToList();
        }

        public User GetUserFromDatabase(string username, string password)
        {
            _logger.LogDebug("Getting specific user from db");
            var user = _azmmDbContext.Users.Include(x => x.Role).FirstOrDefault(x => x.Name == username && x.Password == password);
            return user;
        }
    }
}
