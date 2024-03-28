using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace Froghopper.models
{
    [PrimaryKey(nameof(Aid))]
    public class Authors
    {
        public string Aid { get; set; }
        public Person Person { get; set; }
        public bool IsLicensed { get; set; }
        public List<App> CreatedApps { get; set; } = new List<App>();
        public Company WorksForCompany { get; set; }
        
    }
}
