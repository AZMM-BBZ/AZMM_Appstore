using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace AZMM.Server.Models
{
    [PrimaryKey(nameof(Rid))]
    [Table("Role")]
    public class Role
    {
        public int Rid { get; set; }
        public string RoleName { get; set; }
    }
}
