using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiFinalAssignment.BAL.Interface;
using WebApiFinalAssignment.Models;

namespace WebApiFinalAssignment.Controllers
{
    [AuthenticationFilter]
    public class HotelApiController : ApiController
    {
        IHotel _hotel;

        public HotelApiController(IHotel hotel)
        {
            _hotel = hotel;
        }

        /*
         This api gets all the hotels from the database sorted in aplhabetic order and returns the list in
         Ihttpactionresult.
             */
        [Route("api/HotelApi/GetAllHotels")]
        public IHttpActionResult GetAllHotels()
        {
            var result=_hotel.GetAllHotels();
            return Ok(result);

        }

        /*
            This api accepts HotelsModel model as input and inserts new hotel in database.
         */
        [HttpPost]
        [Route("api/HotelApi/PostAddHotel")]
        public IHttpActionResult PostAddHotel([FromBody]HotelsModel model)
        {
            _hotel.PostAddHotel(model);
            return Ok("Hotel Added");
        }
    }
}
