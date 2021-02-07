using AdWebScraper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdWebScraper.Repository;
using AdWebScraper.Services.Communication;

namespace AdWebScraper.Services
{
    public class AdvertService : IAdvertService
    {
        private readonly IAdvertRepository _advertRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AdvertService(IAdvertRepository advertRepository, IUnitOfWork unitOfWork)
        {
            _advertRepository = advertRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Advert>> ListAsync()
        {
            return await _advertRepository.ListAsync();
        }

        public async Task<AdvertResponse> SaveAsync(Advert advert)
        {
            try
            {
                await _advertRepository.AddAsync(advert);
                await _unitOfWork.CompleteAsync();

                return new AdvertResponse(advert);
            }
            catch (Exception e)
            {
                return new AdvertResponse($"An error occured when saving the advert: {e.Message}");
            }
        }

        public async Task<AdvertResponse> UpdateAsync(int id, Advert advert)
        {
            var existingAdvert = await _advertRepository.FindByIdAsync(id);
            if(existingAdvert == null)
            {
                return new AdvertResponse("Advert not found");
            }

            existingAdvert.Url = advert.Url;
            if (advert.DatePosted != default(DateTime))
                existingAdvert.DatePosted = advert.DatePosted;
            if (advert.Description != null)
                existingAdvert.Description = advert.Description;


            try
            {
                _advertRepository.Update(existingAdvert);
                await _unitOfWork.CompleteAsync();

                return new AdvertResponse(existingAdvert);
            }
            catch (Exception e)
            {
                return new AdvertResponse($"An error occured when saving the advert: {e.Message}");
            }
        }

        public async Task<AdvertResponse> DeleteAsync(int id)
        {
            var existingAdvert = await _advertRepository.FindByIdAsync(id);
            if (existingAdvert == null)
            {
                return new AdvertResponse("Advert not found");
            }

            try
            {
                _advertRepository.Delete(existingAdvert);
                await _unitOfWork.CompleteAsync();

                return new AdvertResponse(existingAdvert);
            }
            catch (Exception e)
            {
                return new AdvertResponse($"An error occured when saving the advert: {e.Message}");
            }
        }
    }
}
