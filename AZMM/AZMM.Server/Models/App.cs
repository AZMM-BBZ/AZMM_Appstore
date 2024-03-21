using Froghopper.Enums;
using Microsoft.EntityFrameworkCore;

namespace Froghopper.models
{
    [PrimaryKey(nameof(Aid))]
    public class App
    {
        public int Aid {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Author { get; set; }
        public string AuthorUrl { get; set; }
        public Category Category { get; set; }
        //public List<Category> Categories { get; set; }
        public List<User> DownloadedByUsers { get; set; } = new List<User>();

    }
}
