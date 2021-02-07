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
    public class AdvertController : ControllerBase
    {
        private readonly IAdvertService _advertService;
        private readonly IMapper _mapper;

        public AdvertController(IAdvertService advertService, IMapper mapper)
        {
            _advertService = advertService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AdvertResource>> GetAllAsync()
        {
            var adverts = await _advertService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Advert>, IEnumerable<AdvertResource>>(adverts);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveAdvertResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var advert = _mapper.Map<SaveAdvertResource, Advert>(resource);
            var result = await _advertService.SaveAsync(advert);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var advertResource = _mapper.Map<Advert, AdvertResource>(result.Advert);
            return Ok(advertResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAdvertResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var advert = _mapper.Map<SaveAdvertResource, Advert>(resource);
            var result = await _advertService.UpdateAsync(id, advert);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var advertResource = _mapper.Map<Advert, AdvertResource>(result.Advert);
            return Ok(advertResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _advertService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var advertResource = _mapper.Map<Advert, AdvertResource>(result.Advert);
            return Ok(advertResource);
        }
    }
}
