using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiFinalAssignment.Models;

namespace WebApiFinalAssignment.BAL.Interface
{
    public interface IRoom
    {
        List<RoomsModel> GetAllRooms(string city, string pincode, int price, string category);

        bool GetRoomAvailability(int room_id, DateTime date);

        void PostBookRoom(BookingsModel model);

        void PostAddRoom(RoomsModel model);

        void PutUpdateBookingDate(int booking_id, BookingsModel model);

        void PutUpdateBookingStatus(int booking_id, BookingsModel model);

        void DeleteBooking(int booking_id);
    }
}
