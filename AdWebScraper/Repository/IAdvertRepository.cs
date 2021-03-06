﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdWebScraper.Models;

namespace AdWebScraper.Repository
{
    public interface IAdvertRepository
    {
        Task<IEnumerable<Advert>> ListAsync();
        Task AddAsync(Advert advert);
        Task<Advert> FindByIdAsync(int id);
        void Update(Advert advert);
        void Delete(Advert advert);
    }
}
