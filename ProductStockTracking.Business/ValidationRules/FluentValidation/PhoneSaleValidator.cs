using FluentValidation;
using ProductStockTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStockTracking.Business.ValidationRules.FluentValidation
{
    public class PhoneSaleValidator : AbstractValidator<PhoneSale>
    {
        public PhoneSaleValidator()
        {
            RuleFor(c => c.Barcode).NotEmpty().WithMessage("Barkod alanı boç geçilemez");
            RuleFor(c => c.NewPhoneOwnersName).NotEmpty().WithMessage("İsim alanı boç geçilemez");
            RuleFor(c => c.NewPhoneOwnersNo).NotEmpty().WithMessage("No alanı boç geçilemez");
            RuleFor(c => c.DeliveryPrice).NotEmpty().WithMessage("Fiyat alanı boç geçilemez");
        }
    }
}
