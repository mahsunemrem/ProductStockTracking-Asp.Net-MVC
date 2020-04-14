using ProductStockTracking.Business.Abstract;
using ProductStockTracking.Business.Concrete.Managers;
using ProductStockTracking.DataAccess.Concrete.EntityFramework;
using ProductStockTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductStockTracking.MvcWebUI.StartupTasks
{
    public static class ProductTypeStartUp
    {
        public static  IProductTypeService _productTypeService = new ProductTypeManager(new EfProductTypeDal());
        public  static  List<ProductType> productTypes= _productTypeService.GetList().Data;


       
    }
}