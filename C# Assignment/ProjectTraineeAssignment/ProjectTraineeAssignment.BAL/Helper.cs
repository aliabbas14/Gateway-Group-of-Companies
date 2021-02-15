using ProjectTraineeAssignment.DAL.Interface;
using ProjectTraineeAssignment.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Extension;

namespace ProjectTraineeAssignment.BAL
{
    public class Helper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IAccountRepo, AccountRepo>();
            Container.RegisterType<ICategoryRepo, CategoryRepo>();
            Container.RegisterType<IProductRepo, ProductRepo>();
        }
    }
}
