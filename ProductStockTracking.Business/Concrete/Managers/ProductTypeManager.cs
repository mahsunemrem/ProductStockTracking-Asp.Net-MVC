using ProductStockTracking.Business.Abstract;
using ProductStockTracking.Business.Contants;
using ProductStockTracking.Business.ValidationRules.FluentValidation;
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
    public class ProductTypeManager : IProductTypeService
    {
        private readonly IProductTypeDal _productTypeDal;

        public ProductTypeManager(IProductTypeDal productTypeDal)
        {
            _productTypeDal = productTypeDal;
        }
        [FluentValidationAspect(typeof(ProductTypeValidator))]
        [CacheRemoveAspect("", typeof(MemoryCacheManager))]
        public IResult Add(ProductType productType)
        {
            try
            {
                _productTypeDal.Add(productType);
                return new SuccessResult(Messages.ProductTypeAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IResult Delete(ProductType productType)
        {
            try
            {
                _productTypeDal.Delete(productType);
                return new SuccessResult(Messages.ProductTypeDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IDataResult<ProductType> GetById(int productTypeId)
        {
            try
            {
                var productType = _productTypeDal.Get(c => c.Id == productTypeId);
                return new SuccessDataResult<ProductType>(productType, Messages.TransactionSuccessful);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ProductType>(ex.Message);
            }
        }
        [CacheAspect(typeof(MemoryCacheManager))]
        public IDataResult<List<ProductType>> GetList(Expression<Func<ProductType, bool>> filter = null)
        {
            try
            {
                var productTypes = _productTypeDal.GetList(filter);
                return new SuccessDataResult<List<ProductType>>(productTypes, Messages.TransactionSuccessful);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<ProductType>>(ex.Message);
            }
        }
        [FluentValidationAspect(typeof(ProductTypeValidator))]
        [CacheRemoveAspect("", typeof(MemoryCacheManager))]
        public IResult Update(ProductType productType)
        {
            try
            {
                _productTypeDal.Update(productType);
                return new SuccessResult(Messages.ProductTypeUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }
    }
}
