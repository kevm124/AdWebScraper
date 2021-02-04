using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdWebScraper.Models;

namespace AdWebScraper.Repository
{
    public interface IAdvertRepository
    {
        Task<IEnumerable<Advert>> ListAsync();
    }
}
