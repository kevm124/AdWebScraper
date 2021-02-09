using System.ComponentModel.DataAnnotations;

namespace AdWebScraper.Resources
{
    public class SaveCarResource
    {
        [Required]
        public string MakeModel { get; set; }
        public uint Year { get; set; }
        public uint Price { get; set; }
        public uint Miles { get; set; }
        public string Condition { get; set; }
        public string Color { get; set; }
        public int AdvertId { get; set; }
    }
}
