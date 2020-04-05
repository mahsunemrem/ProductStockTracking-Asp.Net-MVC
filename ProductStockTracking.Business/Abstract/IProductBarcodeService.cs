using ProductStockTracking.Core.Utilities.Results;
using ProductStockTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductStockTracking.Business.Abstract
{
    public interface IProductBarcodeService
    {
        IDataResult<ProductBarcode> GetById(int productBarcodeId);
        IDataResult<List<ProductBarcode>> GetList(Expression<Func<ProductBarcode, bool>> filter = null);
        IResult Add(ProductBarcode productBarcode);
        IResult Update(ProductBarcode productBarcode);
        IResult Delete(ProductBarcode productBarcode);
    }
}
