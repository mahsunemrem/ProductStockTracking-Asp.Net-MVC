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
    public interface IPhoneService
    {
        IDataResult<Phone> GetById(int phoneId);
        IDataResult<List<Phone>> GetList(Expression<Func<Phone, bool>> filter = null);
        IResult Add(Phone phone);
        IResult Update(Phone phone);
        IResult Delete(Phone phone);
    }
}
