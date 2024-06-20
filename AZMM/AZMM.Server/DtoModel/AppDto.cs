using Froghopper.Enums;
using Froghopper.models;

namespace AZMM.Server.DtoModel
{
    public class AppDto
    {
        public int Aid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Category Category { get; set; }
    }
}
