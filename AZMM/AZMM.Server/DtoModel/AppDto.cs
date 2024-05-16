using Froghopper.Enums;
using Froghopper.models;

namespace AZMM.Server.DtoModel
{
    public class AppDto
    {
        public int Aid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public List<User> MadeByAuthors { get; set; } = new List<User>();
        public Category Category { get; set; }
        public List<User> DownloadedByUsers { get; set; } = new List<User>();
    }
}
