using ProductStockTracking.Business.Abstract;
using ProductStockTracking.Business.Statics;
using ProductStockTracking.Core.Utilities.Results;
using ProductStockTracking.DataAccess.Abstract;
using ProductStockTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductStockTracking.Business.Concrete.Managers
{
    public class UserRoleManager : IUserRoleService
    {
        private readonly IUserRoleDal _userRoleDal;


        public UserRoleManager(IUserRoleDal userRoleDal)
        {
            _userRoleDal = userRoleDal;
        }

        public IResult Add(UserRole UserRole)
        {
            _userRoleDal.Add(UserRole);

            return new SuccessResult();
        }

        public IResult Delete(UserRole UserRole)
        {
            _userRoleDal.Delete(UserRole);

            return new SuccessResult();
        }

        public IDataResult<UserRole> GetById(int userRoleId)
        {
            return new SuccessDataResult<UserRole>(_userRoleDal.Get(c => c.Id == userRoleId, IncludeStatic.IncludeUserRole));
        }

        public IDataResult<List<UserRole>> GetList(Expression<Func<UserRole, bool>> filter = null)
        {
            return new SuccessDataResult<List<UserRole>>(_userRoleDal.GetList(filter, IncludeStatic.IncludeUserRole));
        }

        public IResult Update(UserRole UserRole)
        {
            _userRoleDal.Update(UserRole);

            return new SuccessResult();
        }
    }
}
