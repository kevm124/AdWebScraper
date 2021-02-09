using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AdWebScraper.Models;
using AdWebScraper.Resources;

namespace AdWebScraper.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveAdvertResource, Advert>();
            CreateMap<SaveCarResource, Car>();
        }
    }
}
