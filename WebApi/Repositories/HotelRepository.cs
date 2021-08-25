using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public HotelRepository(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<HotelData[]> GetHotelsAsync()
        {
            var fileLocation = _hostingEnvironment.ContentRootPath + "/hotelsrates.json";
            if (File.Exists(fileLocation))
            {
                using (StreamReader sr = new StreamReader(fileLocation))
                {
                    var text = await sr.ReadToEndAsync();
                    return JsonConvert.DeserializeObject<HotelData[]>(text);
                }
            }
            else
            {
                return new HotelData[] { };
            }
        }
    }
}
