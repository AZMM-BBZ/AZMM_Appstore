using Froghopper.models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace AZMM.Server.Models
{
    [PrimaryKey(nameof(Aid))]
    public class Author
    {
        public int Aid { get; set; }
        public List<App> CreatedApps { get; set; } = new List<App>();
    }
}
