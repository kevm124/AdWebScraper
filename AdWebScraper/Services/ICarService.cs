using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdWebScraper.Models;
using AdWebScraper.Services.Communication;

namespace AdWebScraper.Services
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> ListAsync();
        Task<CarResponse> SaveAsync(Car car);
        Task<CarResponse> UpdateAsync(int id, Car car);
        Task<CarResponse> DeleteAsync(int id);
    }
}
