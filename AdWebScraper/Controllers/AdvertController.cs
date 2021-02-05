using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using AdWebScraper.Services;
using AdWebScraper.Models;
using AdWebScraper.Resources;

namespace AdWebScraper.Controllers
{
    [Route("/api/[controller]")]
    public class AdvertController : ControllerBase
    {
        private readonly IAdvertService _advertService;
        private readonly IMapper _mapper;

        public AdvertController(IAdvertService advertService, IMapper mapper)
        {
            _advertService = advertService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AdvertResource>> GetAllAsync()
        {
            var adverts = await _advertService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Advert>, IEnumerable<AdvertResource>>(adverts);

            return resources;
        }
    }
}
