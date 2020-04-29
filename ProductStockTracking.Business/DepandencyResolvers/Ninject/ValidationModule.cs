using FluentValidation;
using Ninject.Modules;
using ProductStockTracking.Business.ValidationRules.FluentValidation;
using ProductStockTracking.Entities.Concrete;

namespace ProductStockTracking.Business.DepandencyResolvers.Ninject
{
    public class ValidationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Phone>>().To<PhoneValidator>().InSingletonScope(); 
            Bind<IValidator<FaultyPhone>>().To<FaultyPhoneValidator>().InSingletonScope(); 
            Bind<IValidator<FaultyPhoneDelivery>>().To<FaultyPhoneDeliveryValidator>().InSingletonScope(); 
            Bind<IValidator<PhoneSale>>().To<PhoneSaleValidator>().InSingletonScope(); 
            Bind<IValidator<Product>>().To<ProductValidator>().InSingletonScope(); 
            Bind<IValidator<ProductMovement>>().To<ProductMovementValidator>().InSingletonScope(); 
            Bind<IValidator<ProductType>>().To<ProductTypeValidator>().InSingletonScope(); 
            Bind<IValidator<ProductBarcode>>().To<ProductBarcodeValidator>().InSingletonScope(); 
        }
    }
}