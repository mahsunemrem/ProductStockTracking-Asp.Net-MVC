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


            //Bind<IUserService>().To<UserManager>().InSingletonScope(); // sadece 1 defa newlenir 
            //Bind<IUserDal>().To<EfUserDal>().InSingletonScope(); // sadece 1 defa newlenir 

            //Bind(typeof(IQueryableRepository<>)).To(typeof(EFQueryableRepository<>)).InSingletonScope(); // sadece 1 defa newlenir  gerekde y ok queryable için yaptık kullanılmıyor pek !!
            //Bind<DbContext>().To<NorthwindContext>().InSingletonScope();// queeryable ısınıfda  context newlendiği için yazdık .


            Bind<DbContext>().To<ProductStockTrackingContext>();

        }
    }
}

