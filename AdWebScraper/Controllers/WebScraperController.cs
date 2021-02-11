using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AdWebScraper.Services;

namespace AdWebScraper.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class WebScraperController : ControllerBase
    {
        private readonly IWebScraperService _webScraperService;

        public WebScraperController(IWebScraperService webScraperService)
        {
            _webScraperService = webScraperService;
        }

        // Get: api/WebScraper
        [HttpGet]
        public Task<string> Get()
        {
            var url = "https://indianapolis.craigslist.org/ctd/d/whiteland-2012-ford-fusion-hybrid/7275090025.html";
            var output = _webScraperService.GetPageData(url);

            return output;
        }        
    }
}