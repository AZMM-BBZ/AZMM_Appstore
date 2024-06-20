using AZMM.Server.Services.Interfaces;
using Froghopper.Context;
using Froghopper.models;
using log4net;
using Microsoft.EntityFrameworkCore;

namespace AZMM.Server.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly AzmmDbContext _azmmDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(ILogger<UserService> logger, AzmmDbContext azmmDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _azmmDbContext = azmmDbContext;
            _httpContextAccessor = httpContextAccessor;
        }
        public User GetCurrentUser()
        {
            var userId = Int32.Parse(_httpContextAccessor.HttpContext.User.FindFirst("userid").Value);
            _logger.LogDebug("Getting User with id: " + userId);
            return _azmmDbContext.Users.Include(x => x.OwendApps).FirstOrDefault(x => x.Uid == userId);
        }
        public List<User> GetUsersFromDatabase()
        {
            _logger.LogDebug("Getting all user from db");
            return _azmmDbContext.Users.ToList();
        }

        public User GetUserFromDatabase(string username, string password)
        {
            _logger.LogDebug("Getting specific user from db");
            var user = _azmmDbContext.Users.Include(x => x.OwendApps).FirstOrDefault(x => x.Name == username && x.Password == password);
            return user;
        }

        public bool AddUser(User user)
        {
            try
            {
                if (GetUserFromDatabase(user.Name, user.Password) != null) return false;
                _logger.LogDebug("Adding user:" + user.Name);
                _azmmDbContext.Users.Add(user);
                _azmmDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
            
        }
        public bool UpdateUser(User user)
        {
            try
            {
                _logger.LogDebug("Update user:" + user.Name);
                _azmmDbContext.Users.Update(user);
                _azmmDbContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
        public bool DeleteUser(User user)
        {
            try
            {
                _logger.LogDebug("Deleteing user:" + user.Name);
                _azmmDbContext.Users.Remove(user);
                _azmmDbContext.SaveChanges();
                return false;
            }
            catch(Exception ex) 
            {
                _logger.LogError(ex.Message);
                return false;
            }
           
        }
    }
}
