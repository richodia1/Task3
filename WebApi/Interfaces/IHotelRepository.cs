﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Interfaces
{
   public interface IHotelRepository
    {
        Task<HotelData[]> GetHotelsAsync();
    }
}
