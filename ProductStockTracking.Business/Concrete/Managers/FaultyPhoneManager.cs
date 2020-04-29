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
    [SecuredOperation(Roles = "Editor,Student")]
    public class FaultyPhoneManager : IFaultyPhoneService
    {
        private readonly IFaultyPhoneDal _faultyPhoneDal;

        public FaultyPhoneManager(IFaultyPhoneDal faultyPhoneDal)
        {
            _faultyPhoneDal = faultyPhoneDal;
        }
        [FluentValidationAspect(typeof(FaultyPhoneValidator))]
        [CacheRemoveAspect("", typeof(MemoryCacheManager))]
        public IResult Add(FaultyPhone faultyPhone)
        {
            try
            {
                _faultyPhoneDal.Add(faultyPhone);
                return new SuccessResult(Messages.FaultyPhoneAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IResult Delete(FaultyPhone faultyPhone)
        {
            try
            {
                _faultyPhoneDal.Delete(faultyPhone);
                return new SuccessResult(Messages.FaultyPhoneDeliveryDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IDataResult<FaultyPhone> GetById(int faultyPhoneId)
        {
            try
            {
                var faultyPhone = _faultyPhoneDal.Get(c => c.Id == faultyPhoneId);
                return new SuccessDataResult<FaultyPhone>(faultyPhone, Messages.TransactionSuccessful);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<FaultyPhone>(ex.Message);
            }
        }
        [CacheAspect(typeof(MemoryCacheManager))]
        public IDataResult<List<FaultyPhone>> GetList(Expression<Func<FaultyPhone, bool>> filter = null)
        {
            try
            {
                var faultyPhones = _faultyPhoneDal.GetList(filter).OrderBy(c => c.DeliveryState).ToList();
                return new SuccessDataResult<List<FaultyPhone>>(faultyPhones, Messages.TransactionSuccessful);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<FaultyPhone>>(ex.Message);
            }
        }
        [FluentValidationAspect(typeof(FaultyPhoneValidator))]
        [CacheRemoveAspect("", typeof(MemoryCacheManager))]
        public IResult Update(FaultyPhone faultyPhone)
        {
            try
            {
                _faultyPhoneDal.Update(faultyPhone);
                return new SuccessResult(Messages.FaultyPhoneUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }
    }
}
