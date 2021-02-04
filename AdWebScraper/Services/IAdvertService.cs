using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdWebScraper.Models;

namespace AdWebScraper.Services
{
    public interface IAdvertService
    {
        Task<IEnumerable<Advert>> ListAsync();
    }
}
