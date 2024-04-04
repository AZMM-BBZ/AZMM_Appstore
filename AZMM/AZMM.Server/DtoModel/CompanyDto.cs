﻿using Froghopper.models;

namespace AZMM.Server.DtoModel
{
    public class CompanyDto
    {
        public int Cid { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public List<User> Employees { get; set; } = new List<User>();
        public List<App> CreatedApps { get; set; } = new List<App>();
    }
}
