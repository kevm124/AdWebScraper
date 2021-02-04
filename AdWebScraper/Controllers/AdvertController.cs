using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdWebScraper.Services;
using AdWebScraper.Models;

namespace AdWebScraper.Controllers
{
    [Route("/api/[controller]")]
    public class AdvertController : ControllerBase
    {
        private readonly IAdvertService _advertService;

        public AdvertController(IAdvertService advertService)
        {
            _advertService = advertService;
        }

        [HttpGet]
        public async Task<IEnumerable<Advert>> GetAllAsync()
        {
            var adverts = await _advertService.ListAsync();
            return adverts;
        }
    }
}
