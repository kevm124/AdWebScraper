using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdWebScraper.Models
{
    public class Advert
    {
        public int _id { get; set; }
        public string Url { get; set; }
        public DateTime DatePosted { get; set; }
        public string Description { get; set; }
        public Car Car { get; set; }
    }
}
