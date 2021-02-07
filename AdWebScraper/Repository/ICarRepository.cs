using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdWebScraper.Models;

namespace AdWebScraper.Repository
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> ListAsync();
        Task AddAsync(Car car);
        Task<Car> FindByIdAsync(int id);
        void Update(Car car);
        void Delete(Car car);
    }
}
