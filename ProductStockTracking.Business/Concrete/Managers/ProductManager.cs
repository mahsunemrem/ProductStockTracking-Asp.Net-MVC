using ProductStockTracking.Business.Abstract;
using ProductStockTracking.Business.Contants;
using ProductStockTracking.Business.Statics;
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
    class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            try
            {
                _productDal.Add(product);
                return new SuccessResult(Messages.ProductAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IResult Delete(Product product)
        {
            try
            {
                _productDal.Delete(product);
                return new SuccessResult(Messages.ProductDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IDataResult<Product> GetById(int productId)
        {
            try
            {
                var product = _productDal.Get(c => c.Id == productId, IncludeStatic.IncludeProduct);
                return new SuccessDataResult<Product>(product, Messages.TransactionSuccessful);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Product>(ex.Message);
            }
        }

        public IDataResult<List<Product>> GetList(Expression<Func<Product, bool>> filter = null)
        {
            try
            {
                var products = _productDal.GetList(filter,IncludeStatic.IncludeProduct);
                return new SuccessDataResult<List<Product>>(products, Messages.TransactionSuccessful);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Product>>(ex.Message);
            }
        }

        public IResult Update(Product product)
        {
            try
            {
                _productDal.Update(product);
                return new SuccessResult(Messages.ProductUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }
    }
}
