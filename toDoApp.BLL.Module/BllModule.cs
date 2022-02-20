using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toDoApp.BLL.Abstract;
using toDoApp.DAL.Module;

namespace toDoApp.BLL.Module
{
    public class BllModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IContentService>().To<ContentService>();            

            List<INinjectModule> modules = new List<INinjectModule>()
            {
                new DalModule()
            };
            Kernel.Load(modules);
        }
    }
}
