using FluentValidation;
using ProductStockTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStockTracking.Business.ValidationRules.FluentValidation
{
    public class FaultyPhoneDeliveryValidator : AbstractValidator<FaultyPhoneDelivery>
    {
        public FaultyPhoneDeliveryValidator()
        {
            RuleFor(m => m.Barcode).NotEmpty().WithMessage("Barkod alanı boş geçilemez");
            RuleFor(m => m.Transactions).NotEmpty().WithMessage("İşlemler alanı boş geçilemez");
            RuleFor(m => m.TransactionPrice).NotEmpty().WithMessage("Fiyat alanı boş geçilemez");
        }
    }
}
