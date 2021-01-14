using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiFinalAssignment.BAL;
using WebApiFinalAssignment.BAL.Interface;
using WebApiFinalAssignment.DAL.Interface;
using WebApiFinalAssignment.Models;

namespace WebApiFinalAssignment.BAL
{
    public class Room : IRoom
    {
        IRoomRepo _roomrepo;

        public Room(IRoomRepo roomrepo)
        {
            _roomrepo = roomrepo;
        }

        public List<RoomsModel> GetAllRooms(string city, string pincode, int price, string category)
        {
                var result=_roomrepo.GetAllRooms(city,pincode,price,category);
                return result;
        }

        public bool GetRoomAvailability(int room_id, DateTime date)
        {
            return _roomrepo.GetRoomAvailability(room_id,date);
        }

        public void PostBookRoom(BookingsModel model)
        {
            _roomrepo.PostBookRoom(model);   
        }

        public void PostAddRoom(RoomsModel model)
        {
            _roomrepo.PostAddRoom(model);
        }

        public void PutUpdateBookingDate(int booking_id, BookingsModel model)
        {
            _roomrepo.PutUpdateBookingDate(booking_id, model);
        }

        public void PutUpdateBookingStatus(int booking_id, BookingsModel model)
        {
            _roomrepo.PutUpdateBookingStatus(booking_id, model);
        }

        public void DeleteBooking(int booking_id)
        {
                _roomrepo.DeleteBooking(booking_id);
            
        }
    }
}
