using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiFinalAssignment.Models;

namespace WebApiFinalAssignment.BAL.Interface
{
    public interface IHotel
    {
        List<HotelsModel> GetAllHotels();

        void PostAddHotel(HotelsModel model);
    }
}
