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
    [SecuredOperation(Roles = "Admin,Editor,Student")]
    public class PhoneSaleManager : IPhoneSaleService
    {
        private readonly IPhoneSaleDal _phoneSaleDal;
        private readonly IPhoneService _phoneService;

        public PhoneSaleManager(IPhoneSaleDal phoneSaleDal, IPhoneService phoneService)
        {
            _phoneSaleDal = phoneSaleDal;
            _phoneService = phoneService;
        }
        [FluentValidationAspect(typeof(PhoneSaleValidator))]
        [CacheRemoveAspect("", typeof(MemoryCacheManager))]
        public IResult Add(PhoneSale phoneSale)
        {
            try
            {
                var result=_phoneService.GetById(phoneSale.PhoneId);
                _phoneSaleDal.Add(phoneSale);
                result.Data.SaleState = true;
                _phoneService.Update(result.Data);
                return new SuccessResult(Messages.PhoneSaleAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IResult Delete(PhoneSale phoneSale)
        {
            try
            {
                _phoneSaleDal.Delete(phoneSale);
                return new SuccessResult(Messages.PhoneSaleDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IDataResult<PhoneSale> GetById(int phoneSaleId)
        {
            try
            {
                var phoneSale = _phoneSaleDal.Get(c => c.PhoneId == phoneSaleId);
                return new SuccessDataResult<PhoneSale>(phoneSale, Messages.TransactionSuccessful);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<PhoneSale>(ex.Message);
            }
        }
        [CacheAspect(typeof(MemoryCacheManager))]
        public IDataResult<List<PhoneSale>> GetList(Expression<Func<PhoneSale, bool>> filter = null)
        {
            try
            {
                var phoneSales = _phoneSaleDal.GetList(filter);
                return new SuccessDataResult<List<PhoneSale>>(phoneSales, Messages.TransactionSuccessful);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<PhoneSale>>(ex.Message);
            }
        }
        [FluentValidationAspect(typeof(PhoneSaleValidator))]
        [CacheRemoveAspect("", typeof(MemoryCacheManager))]
        public IResult Update(PhoneSale phoneSale)
        {
            try
            {
                _phoneSaleDal.Update(phoneSale);
                return new SuccessResult(Messages.PhoneSaleUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }
    }
}