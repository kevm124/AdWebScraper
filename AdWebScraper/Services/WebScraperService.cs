using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using AngleSharp;
using AngleSharp.Html.Parser;
using AdWebScraper.Resources;
using AdWebScraper.Services.Communication;
using AdWebScraper.Models;
using AutoMapper;

namespace AdWebScraper.Services
{
    public class WebScraperService : IWebScraperService
    {
        private readonly IAdvertService _advertService;
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public WebScraperService(IAdvertService advertService, ICarService carService, IMapper mapper)
        {
            _advertService = advertService;
            _carService = carService;
            _mapper = mapper;
        }

        public async Task<AdvertResponse> GetPageData(string url)
        {            
            (SaveAdvertResource advertResource, SaveCarResource carResource) = await GetCarAdData(url);

            var advert = _mapper.Map<SaveAdvertResource, Advert>(advertResource);
            var result = await _advertService.SaveAsync(advert);
            if (!result.Success)
            {
                return result;
            }

            carResource.AdvertId = result.Advert._id;

            var car = _mapper.Map<SaveCarResource, Car>(carResource);
            var carResult = await _carService.SaveAsync(car);
            if (!carResult.Success)
            {
                return new AdvertResponse(carResult.Message);
            }

            return new AdvertResponse(advert);
        }

        public async Task<(SaveAdvertResource, SaveCarResource)> GetCarAdData(string url)
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(url);

            SaveAdvertResource advert = new SaveAdvertResource();
            SaveCarResource car = new SaveCarResource();

            advert.Url = url;

            var dateTime = document.QuerySelector("time.date.timeago");
            if (dateTime != null)
            {
                advert.DatePosted = DateTime.Parse(dateTime.GetAttribute("datetime"));
            }

            var price = document.QuerySelector("span.price");
            car.Price = (uint)int.Parse(price.TextContent, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowCurrencySymbol);

            var attributeGroup = document.QuerySelectorAll("p.attrgroup");

            MatchCollection matches = Regex.Matches(attributeGroup[0].TextContent, @"\d{4}");
            var year = uint.Parse(matches[0].ToString());
            car.Year = year;

            matches = Regex.Matches(attributeGroup[0].TextContent, @"[^\s\d].+");
            car.MakeModel = matches[0].ToString();

            var attributes = attributeGroup[1].QuerySelectorAll("span");

            foreach (var row in attributes)
            {
                string[] rowSplit = row.TextContent.Split(": ");
                switch (rowSplit[0])
                {
                    case "odometer":
                        car.Miles = uint.Parse(rowSplit[1]);
                        break;
                    case "paint color":
                        car.Color = rowSplit[1];
                        break;
                    case "condition":
                        car.Condition = rowSplit[1];
                        break;
                }
            }

            return (advert, car);
        }
    }
}
