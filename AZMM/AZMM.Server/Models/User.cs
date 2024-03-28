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
        public Person Person { get; set; }
        public List<App> OwendApps { get; set; } = new List<App>();
        public double MoneySpent { get; set; }
    }
}
