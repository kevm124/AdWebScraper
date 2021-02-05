using AdWebScraper.Models;

namespace AdWebScraper.Services.Communication
{
    public class AdvertResponse : BaseResponse
    {
        public Advert Advert { get; private set; }

        private AdvertResponse(bool success, string message, Advert advert) : base(success, message)
        {
            Advert = advert;
        }

        //Creates success response
        public AdvertResponse(Advert advert) : this(true, string.Empty, advert) { }

        //Creates an error response
        public AdvertResponse(string message) : this(false, message, null) { }
    }
}
