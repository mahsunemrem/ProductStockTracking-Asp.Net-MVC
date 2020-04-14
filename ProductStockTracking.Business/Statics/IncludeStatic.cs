using ProductStockTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductStockTracking.Business.Statics
{
    public class IncludeStatic
    {
        public static Expression<Func<Product, object>>[] IncludeProduct = {

            c=>c.ProductType,
            c=>c.ProductBarcodes,
            c=>c.ProductMovements
       };

        public static Expression<Func<ProductMovement, object>>[] IncludeProductMovement = {

            c=>c.Product,
        };
    }
}
