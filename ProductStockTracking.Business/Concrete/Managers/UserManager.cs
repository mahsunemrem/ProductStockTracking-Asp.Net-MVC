using ProductStockTracking.Business.Abstract;
using ProductStockTracking.Business.Contants;
using ProductStockTracking.Core.Utilities.Business;
using ProductStockTracking.Core.Utilities.Results;
using ProductStockTracking.DataAccess.Abstract;
using ProductStockTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;

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
            user.Password = CreatePasswordHash(user.Password);
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
                var hashPassword = CreatePasswordHash(password);

                var user = _userDal.Get(u => u.UserName == userName & u.Password == hashPassword);

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

        public string CreatePasswordHash(string password)
        {

            MD5 md5 = new MD5CryptoServiceProvider();

            //metnin boyutuna göre hash hesaplar
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));

            //hesapladıktan sonra hashi alır
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //her baytı 2 hexadecimal hane olarak değiştirir
                strBuilder.Append(result[i].ToString("x2"));
            }


            return strBuilder.ToString();

        }
    }
}
