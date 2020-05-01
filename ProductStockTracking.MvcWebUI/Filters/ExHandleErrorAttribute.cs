using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace ProductStockTracking.MvcWebUI.Filters
{
    public class ExHandleErrorAttribute : HandleErrorAttribute
    {
        public ExHandleErrorAttribute()
        {
           
        }

        public override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            filterContext.Result = new ViewResult()

            {

                ViewName = "_Errors",


            };

            filterContext.Controller.ViewBag.Message = filterContext.Exception.Message;
            var a = 4;
        }
    }
}