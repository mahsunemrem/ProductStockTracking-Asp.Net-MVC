using ProductStockTracking.Core.Utilities.Results;
using ProductStockTracking.Entities.Concrete;
using ProductStockTracking.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductStockTracking.Business.Abstract
{
    public interface IProductService
    {
        IDataResult<Product> GetById(int productId);
        IDataResult<List<Product>> GetList(Expression<Func<Product, bool>> filter = null);
        IResult Add(Product product);
        IResult Update(Product product);
        IResult Delete(Product product);
        IDataResult<List<ProductListwithProductMovementsViewModel>> GetListWithProductMovements(Expression<Func<Product, bool>> filter = null);
    }
}
