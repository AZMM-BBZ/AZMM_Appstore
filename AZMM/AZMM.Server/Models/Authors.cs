using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Froghopper.models
{
    
    public class Authors : User
    {
        public bool IsLicensed { get; set; }
        public List<App> CreatedApps { get; set; } = new List<App>();
        public Company WorksForCompany { get; set; }
        
    }
}
