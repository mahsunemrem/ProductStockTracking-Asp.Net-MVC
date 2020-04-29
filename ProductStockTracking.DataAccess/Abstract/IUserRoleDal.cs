using ProductStockTracking.Core.DataAccess.Abstract;
using ProductStockTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStockTracking.DataAccess.Abstract
{
    public interface IUserRoleDal : IEntityRepository<UserRole>
    {
    }
}
