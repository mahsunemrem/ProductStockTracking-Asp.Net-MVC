using ProductStockTracking.Business.Abstract;
using ProductStockTracking.Core.Utilities.Results;
using ProductStockTracking.Entities.Concrete;
using ProductStockTracking.MvcWebUI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductStockTracking.MvcWebUI.Controllers
{
    [Authorize]
    public class PhoneController : Controller
    {

        private readonly IPhoneService _phoneService;
        private readonly IPhoneSaleService _phoneSaleService;

        public PhoneController(IPhoneService phoneService, IPhoneSaleService phoneSaleService)
        {
            _phoneService = phoneService;
            _phoneSaleService = phoneSaleService;
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
                return View(result.Data);
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
        [ValidateAntiForgeryToken]
      
        public ActionResult AddPhone(Phone model)
        {

            // özel validation kullandıysan eğer try catch bas !!!!!!!!!!!!!
            try
            {
                IResult result;
                if (model.Id == 0)
                    result = _phoneService.Add(model);
                else
                    result = _phoneService.Update(model);

                if (result.Success)
                    return RedirectToAction("/PhoneList");

                ViewBag.Message = result.Message;


                return View(model);
            }
            catch (Exception e)
            {

                var a = e.Message.Trim().Replace("\n", " ");

                a =a.Replace("\r", " ");


                ViewBag.Message =a ;


                return View(model); 
            }
            
        }



        public ActionResult AddPhoneSale(string[] phoneSaleModel)
        {

            try
            {

                PhoneSale phoneSale = new PhoneSale();

                phoneSale.PhoneId = Convert.ToInt32(phoneSaleModel[0]);
                phoneSale.Barcode = phoneSaleModel[1];
                phoneSale.NewPhoneOwnersName = phoneSaleModel[2];
                phoneSale.NewPhoneOwnersNo = phoneSaleModel[3];
                phoneSale.DeliveryDate = Convert.ToDateTime(phoneSaleModel[4]);
                phoneSale.DeliveryPrice = Convert.ToInt64(phoneSaleModel[5]);

                var result = _phoneSaleService.Add(phoneSale);

                var resStr = Newtonsoft.Json.JsonConvert.SerializeObject(result);
                return Json(resStr);
            }
            catch (Exception)
            {
                var resStr = Newtonsoft.Json.JsonConvert.SerializeObject(new ErrorResult("Telefon satış bilgilerini gönderirken hata oluştu ! Lütfen bilgileri eksiksiz ve doğru bir şekilde girin."));

                return Json(resStr);
            }

        }

        public ActionResult GetPhoneSaleInfo(int phoneId)
        {
            try
            {
                var result = _phoneSaleService.GetById(phoneId);

                string[] arrayData = { result.Data.Barcode, result.Data.NewPhoneOwnersName, result.Data.NewPhoneOwnersNo.ToString(), result.Data.DeliveryPrice.ToString(), result.Data.DeliveryDate.ToString("dd.MM.yyyy") };

                if (result.Success)
                {
                    var resStr = Newtonsoft.Json.JsonConvert.SerializeObject(new SuccessDataResult<string[]>(arrayData));
                    return Json(resStr);
                }

                else
                {
                    var resStr = Newtonsoft.Json.JsonConvert.SerializeObject(result);
                    return Json(resStr);
                }

            }
            catch (Exception)
            {
                var resStr = Newtonsoft.Json.JsonConvert.SerializeObject(new ErrorResult("Telefon satış kaydı bilgileri gösterirken hata oluştu."));
                return Json(resStr);
            }
        }

    }
}