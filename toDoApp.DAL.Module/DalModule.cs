using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toDoApp.DAL.Abstract;
using toDoApp.DAL.EF;

namespace toDoApp.DAL.Module
{
    public class DalModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<DbContext>().To<toDoAppDbContext>();
            Bind<IUnitofWork>().To<UnitofWork>();
        }
    }
}
