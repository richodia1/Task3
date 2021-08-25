using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApiText
{
   public class Utility
    {
        public static HotelData[] LoadTestData()
        {
            var fileLocation = Path.Combine(Directory.GetCurrentDirectory(), "hotelsrates.json");
            if (File.Exists(fileLocation))
            {
                using (StreamReader sr = new StreamReader(fileLocation))
                {
                    var text = sr.ReadToEnd();
                    return JsonConvert.DeserializeObject<HotelData[]>(text);
                }
            }
            else
            {
                return new HotelData[] { };
            }
        }

        public static DateTime? ParseDate(string dateString)
        {
            if (DateTime.TryParse(dateString, out DateTime date))
            {
                return date;
            }
            else
            {
                return null;
            }
        }
    }
}