using FluentValidation;
using ProductStockTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStockTracking.Business.ValidationRules.FluentValidation
{
    public class FaultyPhoneValidator : AbstractValidator<FaultyPhone>
    {
        public FaultyPhoneValidator()
        {
            RuleFor(c => c.Barcode).NotEmpty().WithMessage("Barkod alanı boş geçilemez");
            RuleFor(c => c.BrandModel).NotEmpty().WithMessage("Marka/Model alanı boş geçilemez");
            RuleFor(c => c.PhoneOwnersName).NotEmpty().WithMessage("İsim alanı boş geçilemez");
            RuleFor(c => c.PhoneOwnersNo).NotEmpty().WithMessage("No alanı boş geçilemez");
            RuleFor(c => c.FaultDescription).NotEmpty().WithMessage("Arıza açıklaması boş geçilemez");
        }
    }
}
