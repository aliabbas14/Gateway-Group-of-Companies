using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiFinalAssignment.Models;

namespace WebApiFinalAssignment.DAL.Interface
{
    public interface IHotelRepo
    {
        List<HotelsModel> GetAllHotels();

        void PostAddHotel(HotelsModel model);
    }
}
