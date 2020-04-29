using Ninject.Modules;
using ProductStockTracking.Business.Abstract;
using ProductStockTracking.Business.Concrete.Managers;
using ProductStockTracking.DataAccess.Abstract;
using ProductStockTracking.DataAccess.Concrete.EntityFramework;
using ProductStockTracking.DataAccess.Concrete.EntityFramework.Contexts;
using ProductStockTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStockTracking.Business.DepandencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPhoneService>().To<PhoneManager>().InSingletonScope(); // sadece 1 defa newlenir 
            Bind<IPhoneDal>().To<EfPhoneDal>().InSingletonScope(); // sadece 1 defa newlenir 

            Bind<IPhoneSaleService>().To<PhoneSaleManager>().InSingletonScope(); // sadece 1 defa newlenir 
            Bind<IPhoneSaleDal>().To<EfPhoneSaleDal>().InSingletonScope(); // sadece 1 defa newlenir 

            Bind<IFaultyPhoneService>().To<FaultyPhoneManager>().InSingletonScope(); // sadece 1 defa newlenir 
            Bind<IFaultyPhoneDal>().To<EfFaultyPhoneDal>().InSingletonScope(); // sadece 1 defa newlenir 

            Bind<IFaultyPhoneDeliveryService>().To<FaultyPhoneDeliveryManager>().InSingletonScope(); // sadece 1 defa newlenir 
            Bind<IFaultyPhoneDeliveryDal>().To<EfFaultyPhoneDeliveryDal>().InSingletonScope(); // sadece 1 defa newlenir 



            Bind<IProductService>().To<ProductManager>().InSingletonScope(); // sadece 1 defa newlenir 
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope(); // sadece 1 defa newlenir 

            Bind<IProductMovementService>().To<ProductMovementManager>().InSingletonScope(); // sadece 1 defa newlenir 
            Bind<IProductMovementDal>().To<EfProductMovementDal>().InSingletonScope(); // sadece 1 defa newlenir 

            Bind<IProductTypeService>().To<ProductTypeManager>().InSingletonScope(); // sadece 1 defa newlenir 
            Bind<IProductTypeDal>().To<EfProductTypeDal>().InSingletonScope(); // sadece 1 defa newlenir 

            Bind<IProductBarcodeService>().To<ProductBarcodeManager>().InSingletonScope(); // sadece 1 defa newlenir 
            Bind<IProductBarcodeDal>().To<EfProductBarcodeDal>().InSingletonScope(); // sadece 1 defa newlenir 

            Bind<IUserService>().To<UserManager>().InSingletonScope(); // sadece 1 defa newlenir 
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope(); // sadece 1 defa newlenir 

            Bind<IRoleService>().To<RoleManager>().InSingletonScope(); // sadece 1 defa newlenir 
            Bind<IRoleDal>().To<EfRoleDal>().InSingletonScope(); // sadece 1 defa newlenir 

            Bind<IUserRoleService>().To<UserRoleManager>().InSingletonScope(); // sadece 1 defa newlenir 
            Bind<IUserRoleDal>().To<EfUserRoleDal>().InSingletonScope(); // sadece 1 defa newlenir 



            Bind<DbContext>().To<ProductStockTrackingContext>();

        }
    }
}

