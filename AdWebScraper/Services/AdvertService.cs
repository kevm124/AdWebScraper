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
                return new AdvertResponse($"An error occured when saving the category: {e.Message}");
            }
        }
    }
}
