using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelDataService _hotelService;

        public HotelController(IHotelDataService service)
        {
            _hotelService = service;
        }

        [HttpGet("{hotelId}/{arrivalDate}")]
        public async Task<ActionResult<HotelData>> Get(int hotelId, DateTime arrivalDate)
        {
            var hotel = await _hotelService.GetHotelDataAsync(hotelId, arrivalDate);

            if (hotel == null) return NotFound();

            return Ok(hotel);
        }
    }
}
