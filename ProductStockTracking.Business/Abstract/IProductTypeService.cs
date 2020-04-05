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
    public interface IProductTypeService
    {
        IDataResult<ProductType> GetById(int productTypeId);
        IDataResult<List<ProductType>> GetList(Expression<Func<ProductType, bool>> filter = null);
        IResult Add(ProductType productType);
        IResult Update(ProductType productType);
        IResult Delete(ProductType productType);
    }
}
