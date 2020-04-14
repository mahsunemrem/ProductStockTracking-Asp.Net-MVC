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
    public class FaultyPhoneController : Controller
    {
        IFaultyPhoneService _faultyPhoneService;
        IFaultyPhoneDeliveryService _faultyPhoneDeliveryService;

        public FaultyPhoneController(IFaultyPhoneService faultyPhoneService, IFaultyPhoneDeliveryService faultyPhoneDeliveryService)
        {
            _faultyPhoneService = faultyPhoneService;
            _faultyPhoneDeliveryService = faultyPhoneDeliveryService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FaultyPhoneList()
        {
            var result = _faultyPhoneService.GetList();
            if (result.Success)
            {
                return View(result.Data);
            }
            return View(new List<FaultyPhone>());
        }

        [HttpGet]
        public ActionResult AddFaultyPhone(int id = 0)
        {
            var result = _faultyPhoneService.GetById(id);
            if (result.Success && id != 0)
            {
                return View(result.Data);
            }
            return View(new FaultyPhone());
        }
        [HttpPost]
        public ActionResult AddFaultyPhone(FaultyPhone model)
        {
            IResult result;
            if (model.Id == 0)           
                result = _faultyPhoneService.Add(model);
            else
                result = _faultyPhoneService.Update(model);
            if (result.Success)
                return RedirectToAction("/FaultyPhoneList");
            
            ViewBag.ErrorMessage = result.Message;


            return View(model);
        }

        public ActionResult AddFaultyPhoneDelivery(string[] faultyPhoneDeliveryModel)
        {

            try
            {
                FaultyPhoneDelivery faultyPhoneDelivery = new FaultyPhoneDelivery();

                faultyPhoneDelivery.FaultyPhoneId = Convert.ToInt32(faultyPhoneDeliveryModel[0]);
                faultyPhoneDelivery.Barcode = faultyPhoneDeliveryModel[1];
                faultyPhoneDelivery.Transactions = faultyPhoneDeliveryModel[2];
                faultyPhoneDelivery.TransactionPrice = Convert.ToInt32(faultyPhoneDeliveryModel[3]);
                faultyPhoneDelivery.DeliveryDate = Convert.ToDateTime(faultyPhoneDeliveryModel[4]);

                var result = _faultyPhoneDeliveryService.Add(faultyPhoneDelivery);

                var resStr = Newtonsoft.Json.JsonConvert.SerializeObject(result);
                return Json(resStr);
            }
            catch (Exception)
            {
                var resStr = Newtonsoft.Json.JsonConvert.SerializeObject(new ErrorResult("Telefon teslim kaydı bilgileri gönderirken hata oluştu ! Lütfen bilgileri eksiksiz ve doğru bir şekilde girin."));

                return Json(resStr);
            }


        }

        public ActionResult GetFaultyPhoneDeliveryInfo(int phoneId)
        {
            try
            {
                var result = _faultyPhoneDeliveryService.GetById(phoneId);
               
                if (result.Success)
                {
                    string[] arrayData = { result.Data.Barcode, result.Data.Transactions, result.Data.TransactionPrice.ToString(), result.Data.DeliveryDate.ToString("dd.MM.yyyy") };

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
                var resStr = Newtonsoft.Json.JsonConvert.SerializeObject(new ErrorResult("Telefon teslim kaydı bilgileri gösterirken hata oluştu."));
                return Json(resStr);
            }
        }
    }
}