using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using AngleSharp;
using AngleSharp.Html.Parser;
using AdWebScraper.Resources;

namespace AdWebScraper.Services
{
    public class WebScraperService : IWebScraperService
    {
        public WebScraperService()
        {
        }

        public async void GetPageData(string url)
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
        }
    }
}
