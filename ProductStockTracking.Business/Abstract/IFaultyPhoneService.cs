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
    public interface IFaultyPhoneService
    {
        IDataResult<FaultyPhone> GetById(int faultyPhoneId);
        IDataResult<List<FaultyPhone>> GetList(Expression<Func<FaultyPhone, bool>> filter = null);
        IResult Add(FaultyPhone faultyPhone);
        IResult Update(FaultyPhone faultyPhone);
        IResult Delete(FaultyPhone faultyPhone);       

    }
}
