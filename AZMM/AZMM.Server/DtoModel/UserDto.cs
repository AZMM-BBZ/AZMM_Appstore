using Froghopper.models;

namespace AZMM.Server.DtoModel
{
    public class UserDto
    {
        public int Uid { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<App> OwendApps { get; set; } = new List<App>();
    }
}
