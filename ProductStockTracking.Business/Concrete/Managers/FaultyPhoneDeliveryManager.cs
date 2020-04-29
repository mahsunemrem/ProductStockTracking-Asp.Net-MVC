using ProductStockTracking.Business.Abstract;
using ProductStockTracking.Business.Contants;
using ProductStockTracking.Business.ValidationRules.FluentValidation;
using ProductStockTracking.Core.Aspects.Postsharp.AuthorizationAspects;
using ProductStockTracking.Core.Aspects.Postsharp.CacheAspects;
using ProductStockTracking.Core.Aspects.Postsharp.ValidationAspects;
using ProductStockTracking.Core.CrossCuttingConcerns.Caching.Microsoft;
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
    [SecuredOperation(Roles="Admin,Editor,Student")]
    public class FaultyPhoneDeliveryManager : IFaultyPhoneDeliveryService
    {
        private readonly IFaultyPhoneDeliveryDal _faultyPhoneDeliveryDal;
        private readonly IFaultyPhoneService _faultyPhoneService;

        public FaultyPhoneDeliveryManager(IFaultyPhoneDeliveryDal faultyPhoneDeliveryDal, IFaultyPhoneService faultyPhoneService)
        {
            _faultyPhoneDeliveryDal = faultyPhoneDeliveryDal;
            _faultyPhoneService = faultyPhoneService;
        }
        [FluentValidationAspect(typeof(FaultyPhoneDeliveryValidator))]
        [CacheRemoveAspect("", typeof(MemoryCacheManager))]
        public IResult Add(FaultyPhoneDelivery faultyPhoneDelivery)
        {

            try
            {
                var result = _faultyPhoneService.GetById(faultyPhoneDelivery.FaultyPhoneId);
                _faultyPhoneDeliveryDal.Add(faultyPhoneDelivery);
                result.Data.DeliveryState = true;
                _faultyPhoneService.Update(result.Data);
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
        [CacheAspect(typeof(MemoryCacheManager))]
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
        [FluentValidationAspect(typeof(FaultyPhoneDeliveryValidator))]
        [CacheRemoveAspect("", typeof(MemoryCacheManager))]
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
