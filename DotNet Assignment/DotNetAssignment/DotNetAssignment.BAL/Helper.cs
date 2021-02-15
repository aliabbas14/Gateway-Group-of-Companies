using DotNetAssignment.DAL.Interface;
using DotNetAssignment.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Extension;
using Unity;

namespace DotNetAssignment.BAL
{
    public class Helper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IAccountRepo, AccountRepo>();
            Container.RegisterType<IAdminAppointmentRepo, AdminAppointmentRepo>();
            Container.RegisterType<IAppointmentRepo, AppointmentRepo>();
        }
    }
}
