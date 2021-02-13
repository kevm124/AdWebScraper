using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using AutoMapper;
using AdWebScraper.Services;
using AdWebScraper.Resources;
using AdWebScraper.Models;

namespace AdWebScraper.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class WebScraperController : ControllerBase
    {
        private readonly IWebScraperService _webScraperService;
        private readonly IMapper _mapper;

        public WebScraperController(IWebScraperService webScraperService, IMapper mapper)
        {
            _webScraperService = webScraperService;
            _mapper = mapper;
        }

        // Get: api/WebScraper
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromBody] string url)
        {
            if(!Regex.IsMatch(url, @"https:\/\/\w+.craigslist.org\/ct[od]\/d\/.+\.html"))
            {
                return BadRequest("URL is not valid");
            }

            var result = await _webScraperService.GetPageData(url);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var advertResource = _mapper.Map<Advert, AdvertResource>(result.Advert);
            return Ok(advertResource);
        }        
    }
}