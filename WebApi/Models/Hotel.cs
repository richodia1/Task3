using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Hotel
    {
        public int HotelID { get; set; }
        public int Classification { get; set; }
        public string Name { get; set; }
        public float ReviewScore { get; set; }
    }
}
