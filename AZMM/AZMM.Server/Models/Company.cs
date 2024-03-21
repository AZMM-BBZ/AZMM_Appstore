namespace Froghopper.models
{
    public class Company
    {
        public int Cid { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set;}
        public List<Authors> Employees { get; set; } = new List<Authors>();
        public List<App> CreatedApps { get; set; } = new List<App>();
        public List<Company> SubCompanys { get; set; } = new List<Company>();

        public double GetTotalRevenue()
        {
            var revenue = 0.0;
            foreach (var app in CreatedApps) 
            {
                var revenueMadeByApp = app.DownloadedByUsers.Count * app.Price;
                revenue += revenueMadeByApp;
            }
            foreach (var company in SubCompanys)
            {
                revenue += company.GetTotalRevenue();
            }
            return revenue;
        }
    }
}
