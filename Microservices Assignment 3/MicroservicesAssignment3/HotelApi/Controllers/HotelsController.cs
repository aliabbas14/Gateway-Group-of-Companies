using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelEntities.Entities;

namespace HotelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Hotel> GetHotels()
        {
            var hotels= new List<Hotel>()
            { 
                new Hotel()
                {
                    Id=1,
                    Name="Hotel 1",
                    Address="Ahmedabad",
                    Phone="2336732"

                },
                new Hotel()
                {
                    Id=2,
                    Name="Hotel 2",
                    Address="Mumbai",
                    Phone="3248923"

                },
            };

            return hotels;
        }
    }
}
