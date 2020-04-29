using ProductStockTracking.Business.Abstract;
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
    public class RoleManager : IRoleService
    {
        private readonly IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }
        public IResult Add(Role role)
        {
            _roleDal.Add(role);

            return  new SuccessResult();
        }

        public IResult Delete(Role role)
        {
            _roleDal.Delete(role);

            return new SuccessResult();
        }

        public IDataResult<Role> GetById(int roleId)
        {
            return new SuccessDataResult<Role>(_roleDal.Get(c => c.Id == roleId));
        }

        public IDataResult<List<Role>> GetList(Expression<Func<Role, bool>> filter = null)
        {
            return new SuccessDataResult<List<Role>>(_roleDal.GetList());
        }

        public IResult Update(Role role)
        {
            _roleDal.Update(role);

            return new SuccessResult();
        }
    }
}
