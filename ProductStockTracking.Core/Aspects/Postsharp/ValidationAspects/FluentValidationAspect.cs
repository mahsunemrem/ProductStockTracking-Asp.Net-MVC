using FluentValidation;
using PostSharp.Aspects;
using ProductStockTracking.Core.CrossCuttingConcerns.Validation.FluentValidation;
using System;
using System.Linq;

namespace ProductStockTracking.Core.Aspects.Postsharp.ValidationAspects
{
    [Serializable] //aop de seriazable olması gerekiyor !!!
    public class FluentValidationAspect : OnMethodBoundaryAspect
    {
        Type _validatorType;
        public FluentValidationAspect(Type validatorType)
        {
            _validatorType = validatorType; // productu kullandığımız için ninject de verdik productu ve her kullandığğını ver ninject validation klasörün de
        }
        //aspect oriented programming denir...
        public override void OnEntry(MethodExecutionArgs args)  // metoda daha girmeden attribute dde yakalar ve istersek metodun ortaında ve sonun da da aspect oriented program yazılabilir !!!
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); // fluent validation kütüphanesi olmal
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; // gelen tipin türediği sınıfın generic aldığı tiplerin 1.si // zaten bir tane var
            var entities = args.Arguments.Where(c => c.GetType() == entityType); //adlığı parametreler ettype type eşitse onu al 

            foreach (var entity in entities)
            {
                ValidatorTool.FluentVAlidate(validator, entity);

            }
        }
    }
}