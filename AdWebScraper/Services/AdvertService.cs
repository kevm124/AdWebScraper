using AdWebScraper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdWebScraper.Repository;

namespace AdWebScraper.Services
{
    public class AdvertService : IAdvertService
    {
        private readonly IAdvertRepository _advertRepository;

        public AdvertService(IAdvertRepository advertRepository)
        {
            _advertRepository = advertRepository;
        }

        public async Task<IEnumerable<Advert>> ListAsync()
        {
            return await _advertRepository.ListAsync();
        }
    }
}
