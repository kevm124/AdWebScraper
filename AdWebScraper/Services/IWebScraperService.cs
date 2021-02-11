using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdWebScraper.Services.Communication;

namespace AdWebScraper.Services
{
    public interface IWebScraperService
    {
        Task<AdvertResponse> GetPageData(string url);
    }
}
