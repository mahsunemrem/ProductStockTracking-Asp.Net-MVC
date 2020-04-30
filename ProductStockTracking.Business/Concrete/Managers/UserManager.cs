using ProductStockTracking.Business.Abstract;
using ProductStockTracking.Business.Contants;
using ProductStockTracking.Core.Utilities.Business;
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
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IRoleService _roleService;
         

        public UserManager(IUserDal userDal,IRoleService roleService)
        {
            _userDal = userDal;
            _roleService = roleService;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);

            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);

            return new SuccessResult();
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(c => c.Id == userId));
        }

        public IDataResult<User> GetByUserNameAndPassword(string userName, string password)
        {
            try
            {
                var user = _userDal.Get(u => u.UserName == userName & u.Password == password);

                var result = BusinessRules.Run(UserIsActive(user));

                if (result!=null && !result.Success)
                {
                    return (IDataResult<User>)result;
                }

                return new SuccessDataResult<User>(user);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<User>(null,ex.Message);
            }

            

            
        }

        public IDataResult<List<User>> GetList(Expression<Func<User, bool>> filter = null)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetList());
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);

            return new SuccessResult();
        }

        public IDataResult<User> UserIsActive(User user)
        {
            if (user!=null)
            {
                if (user.State)
                    return new SuccessDataResult<User>(user);

                else
                {
                    return new ErrorDataResult<User>(Messages.UserStateInActive);
                }
               
            }
            
            return new ErrorDataResult<User>(Messages.UserIsNull);
          
        }
    }
}
