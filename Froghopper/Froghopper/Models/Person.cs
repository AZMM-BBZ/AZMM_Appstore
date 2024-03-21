using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Froghopper.models
{
    [PrimaryKey(nameof(Pid))]
    public class Person
    {
        public int Pid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
