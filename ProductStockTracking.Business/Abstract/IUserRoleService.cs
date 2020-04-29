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
    public interface IUserRoleService
    {
        IDataResult<UserRole> GetById(int userRoleId);
        IDataResult<List<UserRole>> GetList(Expression<Func<UserRole, bool>> filter = null);
        IResult Add(UserRole UserRole);
        IResult Update(UserRole UserRole);
        IResult Delete(UserRole UserRole);
    }
}
