using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AdWebScraper.Models;
using AdWebScraper.Resources;

namespace AdWebScraper.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Advert, AdvertResource>();
            CreateMap<Car, CarResource>();
        }
    }
}
