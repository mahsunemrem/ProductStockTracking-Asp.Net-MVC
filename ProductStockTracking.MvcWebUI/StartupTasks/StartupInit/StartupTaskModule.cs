using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductStockTracking.MvcWebUI.StartupTasks.StartupInit
{
    public class StartupTaskModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IStartupTask>().To<RoleStartupTask>();
        }
    }
}