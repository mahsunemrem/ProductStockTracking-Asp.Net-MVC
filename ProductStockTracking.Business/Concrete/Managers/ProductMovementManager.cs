using ProductStockTracking.Business.Abstract;
using ProductStockTracking.Business.Contants;
using ProductStockTracking.Business.Statics;
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
    public class ProductMovementManager : IProductMovementService
    {
        private readonly IProductMovementDal _productMovementDal;
        private readonly IProductBarcodeService _productBarcodeService;

        public ProductMovementManager(IProductMovementDal productMovementDal, IProductBarcodeService productBarcodeService)
        {
            _productMovementDal = productMovementDal;
            _productBarcodeService = productBarcodeService;
        }
        [FluentValidationAspect(typeof(ProductMovementValidator))]
        [CacheRemoveAspect("", typeof(MemoryCacheManager))]
        public IResult Add(ProductMovement productMovement)
        {
            try
            {
                var productBarcode= _productBarcodeService.GetList(c => c.Barcode == productMovement.Barcode).Data.First();
                if (productBarcode==null)
                {
                    throw new Exception(Messages.ProductNotHasBarcode);
                }

                productMovement.ProductId=productBarcode.ProductId;

                _productMovementDal.Add(productMovement);
                return new SuccessResult(Messages.ProductMovementAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IResult Delete(ProductMovement productMovement)
        {
            try
            {
                _productMovementDal.Delete(productMovement);
                return new SuccessResult(Messages.ProductMovementDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IDataResult<ProductMovement> GetById(int productMovementId)
        {
            try
            {
                var productMovement = _productMovementDal.Get(c => c.ProductId == productMovementId,IncludeStatic.IncludeProductMovement);
                return new SuccessDataResult<ProductMovement>(productMovement, Messages.TransactionSuccessful);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ProductMovement>(ex.Message);
            }
        }
        [CacheAspect(typeof(MemoryCacheManager))]
        public IDataResult<List<ProductMovement>> GetList(Expression<Func<ProductMovement, bool>> filter = null)
        {
            try
            {
                var productMovements = _productMovementDal.GetList(filter, IncludeStatic.IncludeProductMovement);
                return new SuccessDataResult<List<ProductMovement>>(productMovements, Messages.TransactionSuccessful);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<ProductMovement>>(ex.Message);
            }
        }
        [FluentValidationAspect(typeof(ProductMovementValidator))]
        [CacheRemoveAspect("", typeof(MemoryCacheManager))]
        public IResult Update(ProductMovement productMovement)
        {
            try
            {
                _productMovementDal.Update(productMovement);
                return new SuccessResult(Messages.ProductMovementUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }
    }
}
