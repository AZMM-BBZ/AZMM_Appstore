namespace Froghopper.models
{
    public class User : Person
    {
        public List<App> OwendApps { get; set; } = new List<App>();
        public double MoneySpent { get; set; }
    }
}
