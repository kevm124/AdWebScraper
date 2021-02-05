using AdWebScraper.Models;

namespace AdWebScraper.Services.Communication
{
    public class CarResponse : BaseResponse
    {
        public Car Car { get; private set; }

        private CarResponse(bool success, string message, Car car) : base(success, message)
        {
            Car = car;
        }

        //Creates success response
        public CarResponse(Car car) : this(true, string.Empty, car) { }

        //Creates an error response
        public CarResponse(string message) : this(false, message, null) { }
    }
}
