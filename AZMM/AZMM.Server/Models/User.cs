using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Security.Cryptography;

namespace Froghopper.models
{
    [PrimaryKey(nameof(Uid))]
    public class User
    {
        public int Uid { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<App> OwendApps { get; set; } = new List<App>();
    }
}
