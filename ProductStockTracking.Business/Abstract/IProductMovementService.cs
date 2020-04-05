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
    public interface IProductMovementService
    {
        IDataResult<ProductMovement> GetById(int productMovementId);
        IDataResult<List<ProductMovement>> GetList(Expression<Func<ProductMovement, bool>> filter = null);
        IResult Add(ProductMovement productMovement);
        IResult Update(ProductMovement productMovement);
        IResult Delete(ProductMovement productMovement);
    }
}
