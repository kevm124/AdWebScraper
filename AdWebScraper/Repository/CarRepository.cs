using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdWebScraper.Models;
using AdWebScraper.Contexts;

namespace AdWebScraper.Repository
{
    public class CarRepository : BaseRepository, ICarRepository
    {
        public CarRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Car>> ListAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task AddAsync(Car car)
        {
            await _context.Cars.AddAsync(car);
        }

       
        public async Task<Car> FindByIdAsync(int id)
        {
            return await _context.Cars.FindAsync(id);
        }

        
        public void Update(Car car)
        {
            _context.Cars.Update(car);
        }

        public void Delete(Car car)
        {
            _context.Cars.Remove(car);
        }
    }
}
