using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdWebScraper.Models;

namespace AdWebScraper.Resources
{
    public class AdvertResource
    {
        public int _id { get; set; }
        public string Url { get; set; }
        public DateTime DatePosted { get; set; }
        public string Description { get; set; }
        public Car Car { get; set; }
    }
}
