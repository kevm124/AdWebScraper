using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdWebScraper.Models;
using AdWebScraper.Services.Communication;

namespace AdWebScraper.Services
{
    public interface IAdvertService
    {
        Task<IEnumerable<Advert>> ListAsync();
        Task<AdvertResponse> SaveAsync(Advert advert);
        Task<AdvertResponse> UpdateAsync(int id, Advert advert);
        Task<AdvertResponse> DeleteAsync(int id);
    }
}
