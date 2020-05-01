using ProductStockTracking.Business.Abstract;
using ProductStockTracking.Entities.Concrete;
using ProductStockTracking.MvcWebUI.StartupTasks.StartupInit;
using ProductStockTracking.MvcWebUI.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductStockTracking.MvcWebUI.StartupTasks
{
    public class RoleStartupTask : IStartupTask
    {
        private readonly IRoleService _roleService;

        public RoleStartupTask(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public void Run()
        {
            var result = _roleService.GetList();
            if (result.Success)
                WebUIStatic.RoleList = result.Data;

        }
    }
}