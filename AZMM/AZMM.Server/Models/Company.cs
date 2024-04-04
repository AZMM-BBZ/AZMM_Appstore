using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Froghopper.models
{
    [PrimaryKey(nameof(Cid))]
    public class Company
    {
        public int Cid { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set;}
        public List<User> Employees { get; set; } = new List<User>();
        public List<App> CreatedApps { get; set; } = new List<App>();

        public double GetTotalRevenue()
        {
            var revenue = 0.0;
            foreach (var app in CreatedApps) 
            {
                var revenueMadeByApp = app.DownloadedByUsers.Count * app.Price;
                revenue += revenueMadeByApp;
            }
            return revenue;
        }
    }
}
