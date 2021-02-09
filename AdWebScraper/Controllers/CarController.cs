using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using AdWebScraper.Services;
using AdWebScraper.Models;
using AdWebScraper.Resources;
using AdWebScraper.Extensions;

namespace AdWebScraper.Controllers
{
    [Route("/api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public CarController(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CarResource>> GetAllAsync()
        {
            var cars = await _carService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Car>, IEnumerable<CarResource>>(cars);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCarResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var car = _mapper.Map<SaveCarResource, Car>(resource);
            var result = await _carService.SaveAsync(car);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var carResource = _mapper.Map<Car, CarResource>(result.Car);
            return Ok(carResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCarResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var car = _mapper.Map<SaveCarResource, Car>(resource);
            var result = await _carService.UpdateAsync(id, car);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var carResource = _mapper.Map<Car, CarResource>(result.Car);
            return Ok(carResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _carService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var carResource = _mapper.Map<Car, CarResource>(result.Car);
            return Ok(carResource);
        }
    }
}
