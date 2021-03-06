﻿using ProductStockTracking.Core.Utilities.Results;
using ProductStockTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductStockTracking.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> GetById(int userId);
        IDataResult<List<User>> GetList(Expression<Func<User, bool>> filter = null);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<User> GetByUserNameAndPassword(string userName, string password);

        IDataResult<User> UserIsActive(User user);

        string CreatePasswordHash(string password);

        IResult ExistEmailUniqueCode(string uniqueCode);
        IResult UpdatePassword(User user);
        IResult ExistEmail(string email);
        IResult SendForgotPasswordEmail(string email);
    }
}
