using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdWebScraper.Models;
using AdWebScraper.Contexts;

namespace AdWebScraper.Repository
{
    public class AdvertRepository : BaseRepository, IAdvertRepository
    {
        public AdvertRepository(AppDbContext context) : base(context)
        {
        }
       
        public async Task<IEnumerable<Advert>> ListAsync()
        {
            return await _context.Adverts.ToListAsync();
        }

        public async Task AddAsync(Advert advert)
        {
            await _context.Adverts.AddAsync(advert);
        }
    }
}
