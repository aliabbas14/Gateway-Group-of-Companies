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
    public class RoomApiController : ApiController
    {
        IRoom _room;

        public RoomApiController(IRoom room)
        {
            _room = room;
        }

        /*
            This api returns all the rooms sorted by price.
             */
        [Route("api/RoomApi/GetAllRooms/{city?}/{pincode?}/{price?}/{category?}")]
        public IHttpActionResult GetAllRooms(string city = null, string pincode = null, int price = 0, string category = null)
        {
            try
            {
                var result = _room.GetAllRooms(city, pincode, price, category);
                return Ok(result);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }

        }

        /*
         This api checks the availibilty of particular room on a particular date and returns boolean response.
             */
        [Route("api/RoomApi/GetRoomAvailability/{room_id?}/{date?}")]
        public IHttpActionResult GetRoomAvailability(int room_id, DateTime date)
        {
            var result=_room.GetRoomAvailability(room_id, date);
            return Ok(result);
        }

        /*
         This api accepts BookingsModel model as input and books a room by inserting data in booking table.
             */
        [Route("api/RoomApi/PostBookRoom")]
        [HttpPost]
        public IHttpActionResult PostBookRoom([FromBody]BookingsModel model)
        {
            _room.PostBookRoom(model);
            return Ok("Data Inserted");
        }

        /*
            This api accepts RoomsModel model and adds a room in the room table.
             */
        [Route("api/RoomApi/PostAddRoom")]
        [HttpPost]
        public IHttpActionResult PostAddRoom([FromBody]RoomsModel model)
        {
            _room.PostAddRoom(model);
            return Ok("Room Added");
        }

        /*
            This api updates booking date by booking_id in bookings table.
             */
        [Route("api/RoomApi/PutUpdateBookingDate")]
        [HttpPut]
        public IHttpActionResult PutUpdateBookingDate([FromUri]int booking_id,[FromBody]BookingsModel model)
        {
            _room.PutUpdateBookingDate(booking_id, model);
            return Ok("Updated");
        }

        /*
            This api updates booking status by booking_id in bookings table.
             */
        [Route("api/RoomApi/PutUpdateBookingStatus")]
        [HttpPut]
        public IHttpActionResult PutUpdateBookingStatus([FromUri]int booking_id, [FromBody]BookingsModel model)
        {
            _room.PutUpdateBookingStatus(booking_id, model);
            return Ok("Booking Status Updated");
        }

        /*
            This api deletes booking by booking_id.
             */
        [Route("api/RoomApi/DeleteBooking")]
        [HttpDelete]
        public IHttpActionResult DeleteBooking(int booking_id)
        {
            _room.DeleteBooking(booking_id);
            return Ok("Deleted");
        }
    }
}
