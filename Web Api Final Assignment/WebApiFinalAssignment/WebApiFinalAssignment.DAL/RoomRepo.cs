using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiFinalAssignment.DAL.Interface;
using WebApiFinalAssignment.Models;

namespace WebApiFinalAssignment.DAL
{
    public class RoomRepo : IRoomRepo
    {
        public List<RoomsModel> GetAllRooms(string city, string pincode, int price, string category)
        {

            using (var entity = new WebApiFinalAssignmentEntities())
            {
                //entity.Rooms.Join(entity.Hotels, room => room.HotelId, hotel => hotel.HotelId, (room, hotel) => new { Room = room, Hotel = hotel }).where(x => x.city = city).toList();
                var query = from room in entity.Rooms
                            join hotel in entity.Hotels on room.HotelId equals hotel.Id
                            where hotel.City == city || hotel.Pincode == pincode || room.Price == price || room.Category == category
                            orderby room.Price
                            select new RoomsModel()
                            {
                                Id = room.Id,
                                HotelId = room.HotelId,
                                Name = room.Name,
                                Category = room.Category,
                                Price = room.Price,
                                IsActive = room.IsActive,
                                CreatedBy = room.CreatedBy,
                                CreatedDate = room.CreatedDate,
                                UpdatedBy = room.UpdatedBy,
                                UpdatedDate = room.UpdatedDate
                            };
                List<RoomsModel> result = query.ToList<RoomsModel>();

                return result;
            }
        }

        public bool GetRoomAvailability(int room_id, DateTime date)
        {
            using (var entity = new WebApiFinalAssignmentEntities())
            {
                var query = (from booking in entity.Bookings
                             where booking.RoomId == room_id && booking.date == date
                             select booking.Status).FirstOrDefault();

                if (query == null)
                    return true;
                else
                    return false;

            }
        }

        public void PostBookRoom(BookingsModel model)
        {
            try
            {


                using (var entity = new WebApiFinalAssignmentEntities())
                {
                    Booking b = new Booking()
                    {
                        date =model.date,
                        RoomId =model.RoomId,
                        Status=model.Status
                    };
                    entity.Bookings.Add(b);
                    entity.SaveChanges();
                }
            }
            catch(Exception e)
            {

            }
        }

        public void PostAddRoom(RoomsModel model)
        {
            try
            {
                using (var entity = new WebApiFinalAssignmentEntities())
                {
                    Room r = new DAL.Room();
                    r.HotelId = model.HotelId;
                    r.Name = model.Name;
                    r.Category = model.Category;
                    r.Price = model.Price;
                    r.CreatedBy = model.CreatedBy;
                    r.CreatedDate = model.CreatedDate;
                    r.UpdatedBy = model.UpdatedBy;
                    r.UpdatedDate = model.UpdatedDate;

                    entity.Rooms.Add(r);
                    entity.SaveChanges();
                }

               

            }
            catch(Exception e)
            {

            }
        }

        public void PutUpdateBookingDate(int booking_id,BookingsModel model)
        {
            try
            {

                using (var entity = new WebApiFinalAssignmentEntities())
                {
                    var query = entity.Bookings.Where(x => x.Id==booking_id).FirstOrDefault();
                    query.date = model.date;
                    entity.SaveChanges();
                }

            }
            catch(Exception e)
            {

            }
            }

        public void PutUpdateBookingStatus(int booking_id, BookingsModel model)
        {
            try
            {

                using (var entity = new WebApiFinalAssignmentEntities())
                {
                    var query = entity.Bookings.Where(x => x.Id == booking_id).FirstOrDefault();
                    query.Status = model.Status;
                    entity.SaveChanges();
                }

            }
            catch (Exception e)
            {

            }
        }

        public void DeleteBooking(int booking_id)
        {
            try
            {

                using (var entity = new WebApiFinalAssignmentEntities())
                {
                    var query=entity.Bookings.Where(x => x.Id == booking_id).FirstOrDefault();
                    query.Status = "Deleted";
                    entity.SaveChanges();
                }
            }
            catch(Exception e)
            {

            }

         }


    }
}
