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
    public class ProductMovementManager : IProductMovementService
    {
        private readonly IProductMovementDal _productMovementDal;

        public ProductMovementManager(IProductMovementDal productMovementDal)
        {
            _productMovementDal = productMovementDal;
        }

        public IResult Add(ProductMovement productMovement)
        {
            try
            {
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
                var productMovement = _productMovementDal.Get(c => c.ProductId == productMovementId);
                return new SuccessDataResult<ProductMovement>(productMovement, Messages.TransactionSuccessful);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ProductMovement>(ex.Message);
            }
        }

        public IDataResult<List<ProductMovement>> GetList(Expression<Func<ProductMovement, bool>> filter = null)
        {
            try
            {
                var productMovements = _productMovementDal.GetList(filter);
                return new SuccessDataResult<List<ProductMovement>>(productMovements, Messages.TransactionSuccessful);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<ProductMovement>>(ex.Message);
            }
        }

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
