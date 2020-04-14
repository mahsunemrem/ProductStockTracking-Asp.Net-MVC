using ProductStockTracking.Business.Abstract;
using ProductStockTracking.Core.Utilities.Results;
using ProductStockTracking.Entities.Concrete;
using ProductStockTracking.Entities.Dtos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductStockTracking.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductMovementService _productMovementService;
        private readonly IProductTypeService _productTypeService;
        private readonly IProductBarcodeService _productBarcodeService;


        public ProductController(IProductService productService, IProductMovementService productMovementService, IProductTypeService productTypeService, IProductBarcodeService productBarcodeService)
        {
            _productService = productService;
            _productMovementService = productMovementService;
            _productTypeService = productTypeService;
            _productBarcodeService = productBarcodeService;
        }
        public ActionResult Index()
        {
            return View();
        }

        #region productOperations 


        public ActionResult ProductListWithProductMovements(int id=0)
        {
            var result = _productService.GetListWithProductMovements(c => c.ProductTypeId==id);
            if (result.Success)
                return View(result.Data);
            return View(new List<ProductListwithProductMovementsViewModel>());
        }
        public ActionResult ProductListWithBarcode()
        {
            var result = _productService.GetList();
            if (result.Success)
                return View(result.Data);
            return View(new List<Product>());
        }





        [HttpGet]
        public ActionResult AddProduct(int id = 0)
        {
            var result = _productService.GetById(id);


            ViewBag.ProductTypeId = _productTypeService.GetList().Data.Select(c => new SelectListItem { Text = c.Type.ToString(), Value = c.Id.ToString() }).ToList();

             

            if (result.Success && id != 0)
            {
                return View(result.Data);
            }
            return View(new Product());
        }

        [HttpPost]
        public ActionResult AddProduct(Product model)
        {
            IResult result;
            if (model.Id == 0)
                result = _productService.Add(model);
            else
                result = _productService.Update(model);
            if (result.Success)
                return RedirectToAction("/ProductListWithBarcode");

            ViewBag.ErrorMessage = result.Message;
            

        
            return View(model);
        }

        public ActionResult AddBarcodeToProduct(int productId , string barcode)
        {
            try
            {

                if (productId<=0)
                {
                    throw new Exception("Olmayan üründe barcode eklenemez !");
                }

                var result = _productBarcodeService.Add(new ProductBarcode { Barcode = barcode, ProductId = productId });
               

                var resStr = Newtonsoft.Json.JsonConvert.SerializeObject(result);
                return Json(resStr);
            }
            catch (Exception)
            {
                var resStr = Newtonsoft.Json.JsonConvert.SerializeObject(new ErrorResult("Telefon teslim kaydı bilgileri gösterirken hata oluştu."));
                return Json(resStr);
            }
        }

        public ActionResult DeleteBarcodeFromProduct(int id)
        {

            
            try
            {
                if (id==0)
                    throw new Exception();

               var data = _productBarcodeService.GetById(id).Data;
               var result= _productBarcodeService.Delete(data);
               var resStr = Newtonsoft.Json.JsonConvert.SerializeObject(result);
                return Json(resStr);

            }
            catch (Exception r)
            {
                var resStr = Newtonsoft.Json.JsonConvert.SerializeObject(new ErrorResult("Barkod silinirken bir hata oluştu."));
                return Json(resStr);
            }
        }


        #endregion productOperations


        #region productMovement
        [HttpGet]
        public ActionResult AddProductMovement(int id=0)
        {
            var result = _productMovementService.GetById(id);


            if (result.Success && id != 0)
            {
                return View(result.Data);
            }
            return View(new ProductMovement());

        }


        [HttpPost]
        public ActionResult AddProductMovement(ProductMovement model)
        {
            IResult result;
            if (model.Id == 0)
                result = _productMovementService.Add(model);
            else
                result = _productMovementService.Update(model);
            if (result.Success)
                return RedirectToAction("/ProductMovementPhoneList");

            ViewBag.ErrorMessage = result.Message;



            return View(model);
        }

        public ActionResult ProductMovementPhoneList()
        {
            var result = _productMovementService.GetList();
            if (result.Success)
            {
                return View(result.Data);
            }
            return View(new List<ProductMovement>());
        }
        #endregion productMovement

        #region productTypeOperations

        [HttpGet]
        public ActionResult AddProductType(int id = 0)
        {
            var result = _productTypeService.GetById(id);
            if (result.Success && id != 0)
            {
                return View(result.Data);
            }
            return View(new ProductType());
        }

        [HttpPost]
        public ActionResult AddProductType(ProductType model)
        {
            IResult result;
            if (model.Id == 0)
                result = _productTypeService.Add(model);
            else
                result = _productTypeService.Update(model);
            if (result.Success)
                return RedirectToAction("/");

            ViewBag.ErrorMessage = result.Message;


            return View(model);
        }

        public ActionResult ProductTypeList()
        {
            var result = _productTypeService.GetList();
            if (result.Success)
                return View(result.Data);
            return View(new List<ProductType>());
        }

        public ActionResult AddProductTypeWithAjax(string type)
        {

            try
            {

                if (type=="")
                {
                 throw    new  Exception(" null geldi");
                }

                ProductType productType = new ProductType();

                productType.Type = type;
     
                var result = _productTypeService.Add(productType);

                var resStr = Newtonsoft.Json.JsonConvert.SerializeObject(result);
                return Json(resStr);
            }
            catch (Exception)
            {
                var resStr = Newtonsoft.Json.JsonConvert.SerializeObject(new ErrorResult("Ürün tipi kaydı yapılırken hata oluştu ! Lütfen bilgileri eksiksiz ve doğru bir şekilde girin."));

                return Json(resStr);
            }


        }
        #endregion productTypeOperations


    }
}