using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Services
{
    public class HotelDataService : IHotelDataService
    {
        private readonly IHotelRepository _hotelRepo;

        public HotelDataService(IHotelRepository hotelRepo)
        {
            _hotelRepo = hotelRepo;
        }

        public async Task<HotelData> GetHotelDataAsync(int hotelId, DateTimeOffset arrivalDate)
        {
            var hotels = await _hotelRepo.GetHotelsAsync();

            var query = from hotel in hotels
                        where hotel.Hotel.HotelID == hotelId
                        let rates = from rates in hotel.HotelRates
                                    where rates.TargetDay.Date == arrivalDate.Date
                                    select rates
                        where rates.Any()
                        select hotel;

            var result = query.FirstOrDefault();
            return result;
        }
    }
}