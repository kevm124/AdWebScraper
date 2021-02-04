using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdWebScraper.Models
{
    public class Car
    {
        public int _id { get; set; }
        public string MakeModel { get; set; }
        public uint Year { get; set; }
        public uint Price { get; set; }
        public uint Miles { get; set; }
        public string Condition { get; set; }
        public string Color { get; set; }

        public int AdvertId { get; set; }
        public Advert Advert { get; set; }
    }
}
