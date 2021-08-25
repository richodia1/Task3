using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class HotelRate
    {
		public string RateID { get; set; }
		public int Adults { get; set; }
		public int Los { get; set; }
		public Price Price { get; set; }
		public string RateDescription { get; set; }
		public string RateName { get; set; }
		public RateTag[] RateTags { get; set; }
		public DateTime TargetDay { get; set; }
	}
}
