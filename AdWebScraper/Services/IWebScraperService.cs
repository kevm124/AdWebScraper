﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdWebScraper.Services
{
    public interface IWebScraperService
    {
        Task<string> GetPageData(string url);
    }
}