using ProductStockTracking.Business.Abstract;
using ProductStockTracking.Core.Utilities.Results;
using ProductStockTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductStockTracking.MvcWebUI.Controllers
{
    public class PhoneController : Controller
    {

        private readonly IPhoneService _phoneService;

        public PhoneController(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }
        // GET: Phone
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PhoneList()
        {
            var result = _phoneService.GetList();
            if (result.Success)
            {
                return View(result.Data);
            }
            return View(new List<Phone>());
        }

        [HttpGet]
        public ActionResult AddPhone(int id = 0)
        {

            
            var result = _phoneService.GetById(id);
            if (result.Success && id != 0)
            {
                return View(result.Data);
            }
            return View(new Phone());
        }
        [HttpPost]
        public ActionResult AddPhone(Phone model)
            {
            IResult result;
            if (model.Id == 0)
            {

                result = _phoneService.Add(model);

            }

            else
            {
                result = _phoneService.Update(model);


            }
            if(result.Success)
                return RedirectToAction("/PhoneList");
            return View(model);
        }
    }
}