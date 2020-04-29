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
using ProductStockTracking.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductStockTracking.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IProductMovementService _productMovementService;

        public ProductManager(IProductDal productDal, IProductMovementService productMovementService)
        {
            _productDal = productDal;
            _productMovementService= productMovementService;
        }
        [FluentValidationAspect(typeof(ProductValidator))]
       
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

        public IDataResult<List<ProductListwithProductMovementsViewModel>> GetListWithProductMovements(Expression<Func<Product, bool>> filter = null)
        {
            try
            {
                var products = _productDal.GetList(filter, IncludeStatic.IncludeProduct);

                var productListwithProductMovementsViewModels = new List<ProductListwithProductMovementsViewModel>();

                foreach (var product in products)
                {
                    if (product.ProductBarcodes.Count==0)
                    {
                        continue;
                    }
                    ProductListwithProductMovementsViewModel productListwithProductMovementsViewModel = new ProductListwithProductMovementsViewModel();

                    var alisProductMovements = _productMovementService.GetList(c => c.ProductId == product.Id && c.ProductTransaction == Enums.ProductTransaction.Alis);
                    var satisProductMovements = _productMovementService.GetList(c => c.ProductId == product.Id && c.ProductTransaction == Enums.ProductTransaction.Satis);

                    var alisSum = alisProductMovements.Data.ToList().Sum(c => c.Piece);
                    var satisSum = satisProductMovements.Data.ToList().Sum(c => c.Piece);


                    productListwithProductMovementsViewModel.Product = product;
                    productListwithProductMovementsViewModel.ProductBarcodes = product.ProductBarcodes;
                    productListwithProductMovementsViewModel.ProductId = product.Id;
                    productListwithProductMovementsViewModel.ProductMovements = product.ProductMovements;
                    productListwithProductMovementsViewModel.ProductType = product.ProductType;
                    productListwithProductMovementsViewModel.ProductTypeId = product.ProductTypeId;
                    productListwithProductMovementsViewModel.Piece = alisSum - satisSum;

                    productListwithProductMovementsViewModels.Add(productListwithProductMovementsViewModel);
                }




                return new SuccessDataResult<List<ProductListwithProductMovementsViewModel>>(productListwithProductMovementsViewModels, Messages.TransactionSuccessful);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<ProductListwithProductMovementsViewModel>>(ex.Message);
            }
        }
        [FluentValidationAspect(typeof(ProductBarcodeValidator))]
      
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
