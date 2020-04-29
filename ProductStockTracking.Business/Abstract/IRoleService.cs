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
    public interface IRoleService
    {
        IDataResult<Role> GetById(int roleId);
        IDataResult<List<Role>> GetList(Expression<Func<Role, bool>> filter = null);
        IResult Add(Role role);
        IResult Update(Role role);
        IResult Delete(Role role);
    }
}
