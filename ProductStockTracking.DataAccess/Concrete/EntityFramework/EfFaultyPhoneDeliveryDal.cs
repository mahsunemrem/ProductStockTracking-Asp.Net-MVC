using ProductStockTracking.Core.DataAccess.Concrete.EntityFramework;
using ProductStockTracking.DataAccess.Abstract;
using ProductStockTracking.DataAccess.Concrete.EntityFramework.Contexts;
using ProductStockTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStockTracking.DataAccess.Concrete.EntityFramework
{
    public class EfFaultyPhoneDeliveryDal : EfEntityRepositoryBase<FaultyPhoneDelivery, ProductStockTrackingContext>, IFaultyPhoneDeliveryDal
    {
    }
}
