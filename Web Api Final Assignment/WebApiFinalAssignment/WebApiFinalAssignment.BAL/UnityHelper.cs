using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Extension;
using WebApiFinalAssignment.DAL;
using WebApiFinalAssignment.DAL.Interface;

namespace WebApiFinalAssignment.BAL
{
    public class UnityHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IHotelRepo,HotelRepo>();
            Container.RegisterType<IRoomRepo, RoomRepo>();
        }
    }
}
