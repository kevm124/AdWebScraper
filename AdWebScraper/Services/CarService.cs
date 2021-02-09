using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdWebScraper.Models;
using AdWebScraper.Repository;
using AdWebScraper.Services.Communication;

namespace AdWebScraper.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CarService(ICarRepository carRepository, IUnitOfWork unitOfWork)
        {
            _carRepository = carRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Car>> ListAsync()
        {
            return await _carRepository.ListAsync();
        }       
       
        public async Task<CarResponse> SaveAsync(Car car)
        {
            try
            {
                await _carRepository.AddAsync(car);
                await _unitOfWork.CompleteAsync();

                return new CarResponse(car);
            }
            catch(Exception e)
            {
                return new CarResponse($"An error occured when saving the car: {e.Message}");
            }
        }

        public async Task<CarResponse> UpdateAsync(int id, Car car)
        {
            var existingCar = await _carRepository.FindByIdAsync(id);
            if(existingCar == null)
            {
                return new CarResponse($"Car not found");
            }

            existingCar.MakeModel = car.MakeModel;
            if(car.Year != 0)
                existingCar.Year = car.Year;
            if(car.Price != 0)
                existingCar.Price = car.Price;
            if (car.Miles != 0)
                existingCar.Miles = car.Miles;
            if (car.Condition != null)
                existingCar.Condition = car.Condition;
            if (car.Color != null)
                existingCar.Color = car.Color;
            if (car.AdvertId != 0)
                existingCar.AdvertId = car.AdvertId;

            try
            {
                _carRepository.Update(existingCar);
                await _unitOfWork.CompleteAsync();

                return new CarResponse(existingCar);
            }
            catch (Exception e)
            {
                return new CarResponse($"An error occured when saving the car: {e.Message}");
            }
        }

        public async Task<CarResponse> DeleteAsync(int id)
        {
            var existingCar = await _carRepository.FindByIdAsync(id);
            if (existingCar == null)
            {
                return new CarResponse($"Car not found");
            }

            try
            {
                _carRepository.Delete(existingCar);
                await _unitOfWork.CompleteAsync();

                return new CarResponse(existingCar);
            }
            catch (Exception e)
            {
                return new CarResponse($"An error occured when saving the car: {e.Message}");
            }
        }
    }
}
