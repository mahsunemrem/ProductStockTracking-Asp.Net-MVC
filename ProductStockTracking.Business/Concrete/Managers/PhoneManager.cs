using ProductStockTracking.Business.Abstract;
using ProductStockTracking.Business.Contants;
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
    public class PhoneManager : IPhoneService
    {
        private readonly IPhoneDal _phoneDal;

        public PhoneManager(IPhoneDal phoneDal)
        {
            _phoneDal = phoneDal;
        }

        public IResult Add(Phone phone)
        {
            try
            {
                _phoneDal.Add(phone);
                return new SuccessResult(Messages.PhoneAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IResult Delete(Phone phone)
        {
            try
            {
                _phoneDal.Delete(phone);
                return new SuccessResult(Messages.PHoneDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IDataResult<Phone> GetById(int phoneId)
        {
            try
            {
                var phone = _phoneDal.Get(c => c.Id == phoneId);
                return new SuccessDataResult<Phone>(phone, Messages.TransactionSuccessful);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Phone>(ex.Message);
            }
        }

        public IDataResult<List<Phone>> GetList(Expression<Func<Phone, bool>> filter = null)
        {
            try
            {
                var phones = _phoneDal.GetList(filter);
                return new SuccessDataResult<List<Phone>>(phones, Messages.TransactionSuccessful);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Phone>>(ex.Message);
            }
        }

        public IResult Update(Phone phone)
        {
            try
            {
                _phoneDal.Update(phone);
                return new SuccessResult(Messages.PhoneUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }
    }
}
