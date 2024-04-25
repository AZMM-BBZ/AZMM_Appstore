using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace AZMM.Server.Models
{
    [PrimaryKey(nameof(Rid))]
    public class Role
    {
        public int Rid { get; set; }
        public string RoleName { get; set; }
    }
}
