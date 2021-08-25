using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class HotelData
    {
        public Hotel Hotel { get; set; }
        public HotelRate[] HotelRates { get; set; }
    }
}
