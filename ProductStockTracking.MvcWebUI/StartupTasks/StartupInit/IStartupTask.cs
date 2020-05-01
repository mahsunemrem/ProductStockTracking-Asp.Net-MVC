using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductStockTracking.MvcWebUI.StartupTasks.StartupInit
{
    public interface IStartupTask
    {
        void Run();
    }
}