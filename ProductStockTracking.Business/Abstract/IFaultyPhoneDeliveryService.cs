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
    public interface IFaultyPhoneDeliveryService
    {
        IDataResult<FaultyPhoneDelivery> GetById(int faultyPhoneDeliveryId);
        IDataResult<List<FaultyPhoneDelivery>> GetList(Expression<Func<FaultyPhoneDelivery, bool>> filter = null);
        IResult Add(FaultyPhoneDelivery faultyPhoneDelivery);
        IResult Update(FaultyPhoneDelivery faultyPhoneDelivery);
        IResult Delete(FaultyPhoneDelivery faultyPhoneDelivery);
    }
}
