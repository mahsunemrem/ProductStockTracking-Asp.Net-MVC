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
    public class FaultyPhoneDeliveryManager : IFaultyPhoneDeliveryService
    {
        private readonly IFaultyPhoneDeliveryDal _faultyPhoneDeliveryDal;

        public FaultyPhoneDeliveryManager(IFaultyPhoneDeliveryDal faultyPhoneDeliveryDal)
        {
            _faultyPhoneDeliveryDal = faultyPhoneDeliveryDal;
        }

        public IResult Add(FaultyPhoneDelivery faultyPhoneDelivery)
        {

            try
            {
                _faultyPhoneDeliveryDal.Add(faultyPhoneDelivery);
                return new SuccessResult(Messages.FaultyPhoneDeliveryAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IResult Delete(FaultyPhoneDelivery faultyPhoneDelivery)
        {
            try
            {
                _faultyPhoneDeliveryDal.Delete(faultyPhoneDelivery);
                return new SuccessResult(Messages.FaultyPhoneDeliveryAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IDataResult<FaultyPhoneDelivery> GetById(int faultyPhoneDeliveryId)
        {
            try
            {
                var faultyPhoneDelivery=_faultyPhoneDeliveryDal.Get(c => c.FaultyPhoneId== faultyPhoneDeliveryId);
                return new SuccessDataResult<FaultyPhoneDelivery>(faultyPhoneDelivery, Messages.TransactionSuccessful);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<FaultyPhoneDelivery>(ex.Message);
            }
        }

        public IDataResult<List<FaultyPhoneDelivery>> GetList(Expression<Func<FaultyPhoneDelivery, bool>> filter = null)
        {
            try
            {
                var faultyPhoneDeliveries=_faultyPhoneDeliveryDal.GetList(filter);
                return new SuccessDataResult<List<FaultyPhoneDelivery>>(faultyPhoneDeliveries, Messages.TransactionSuccessful);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<FaultyPhoneDelivery>> (ex.Message);
            }
        }

        public IResult Update(FaultyPhoneDelivery faultyPhoneDelivery)
        {
            try
            {
                _faultyPhoneDeliveryDal.Update(faultyPhoneDelivery);
                return new SuccessResult(Messages.FaultyPhoneDeliveryUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }
    }
}
