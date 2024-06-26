﻿using Froghopper.Enums;
using Microsoft.EntityFrameworkCore;

namespace Froghopper.models
{
    [PrimaryKey(nameof(Aid))]
    public class App
    {
        public int Aid {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl {  get; set; }
        //public double Price { get; set; }
        public string FileName { get; set; }
        //public List<Author> MadeByAuthors { get; set; } = new List<Author>();
        public Category Category { get; set; }
        public List<User> DownloadedByUsers { get; set; } = new List<User>();

    }
}
