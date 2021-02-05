using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AdWebScraper.Resources
{
    public class SaveAdvertResource
    {
        [Required]
        [Url]
        public string Url { get; set; }
        public DateTime DatePosted { get; set; }
        public String Description { get; set; }
    }
}
