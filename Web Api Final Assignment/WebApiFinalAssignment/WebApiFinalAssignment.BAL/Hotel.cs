using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiFinalAssignment.BAL.Interface;
using WebApiFinalAssignment.DAL.Interface;
using WebApiFinalAssignment.Models;

namespace WebApiFinalAssignment.BAL
{
    public class Hotel : IHotel
    {
        IHotelRepo _hotelrepo;

        public Hotel(IHotelRepo hotelrepo)
        {
            _hotelrepo = hotelrepo;
        }

        public List<HotelsModel> GetAllHotels()
        {
            var result=_hotelrepo.GetAllHotels();
            return result;
        }

        public void PostAddHotel(HotelsModel model)
        {
            _hotelrepo.PostAddHotel(model);
        }
    }
}
