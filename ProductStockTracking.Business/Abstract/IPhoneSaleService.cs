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
    public interface IPhoneSaleService
    {
        IDataResult<PhoneSale> GetById(int phoneSaleId);
        IDataResult<List<PhoneSale>> GetList(Expression<Func<PhoneSale, bool>> filter = null);
        IResult Add(PhoneSale phoneSale);
        IResult Update(PhoneSale phoneSale);
        IResult Delete(PhoneSale phoneSale);
    }
}
