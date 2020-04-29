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
    public class ProductBarcodeManager : IProductBarcodeService
    {
        private readonly IProductBarcodeDal _productBarcodeDal;

        public ProductBarcodeManager(IProductBarcodeDal productBarcodeDal)
        {
            _productBarcodeDal = productBarcodeDal;
        }
        [FluentValidationAspect(typeof(ProductBarcodeValidator))]
        [CacheRemoveAspect("", typeof(MemoryCacheManager))]
        public IResult Add(ProductBarcode productBarcode)
        {
            try
            {
                _productBarcodeDal.Add(productBarcode);
                return new SuccessResult(Messages.ProductBarcodeAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IResult Delete(ProductBarcode productBarcode)
        {
            try
            {
                _productBarcodeDal.Delete(productBarcode);
                return new SuccessResult(Messages.ProductBarcodeDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IDataResult<ProductBarcode> GetById(int productBarcodeId)
        {
            try
            {
                var productBarcode = _productBarcodeDal.Get(c => c.Id == productBarcodeId);
                return new SuccessDataResult<ProductBarcode>(productBarcode, Messages.TransactionSuccessful);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ProductBarcode>(ex.Message);
            }
        }
        [CacheAspect(typeof(MemoryCacheManager))]
        public IDataResult<List<ProductBarcode>> GetList(Expression<Func<ProductBarcode, bool>> filter = null)
        {
            try
            {
                var productBarcodes = _productBarcodeDal.GetList(filter);
                return new SuccessDataResult<List<ProductBarcode>>(productBarcodes, Messages.TransactionSuccessful);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<ProductBarcode>>(ex.Message);
            }
        }
        [FluentValidationAspect(typeof(ProductBarcodeValidator))]
        [CacheRemoveAspect("", typeof(MemoryCacheManager))]
        public IResult Update(ProductBarcode productBarcode)
        {
            try
            {
                _productBarcodeDal.Update(productBarcode);
                return new SuccessResult(Messages.PhoneBarcodeUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }
    }
}
