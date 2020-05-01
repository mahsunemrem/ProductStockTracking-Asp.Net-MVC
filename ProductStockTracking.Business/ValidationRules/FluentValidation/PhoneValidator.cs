using FluentValidation;
using ProductStockTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStockTracking.Business.ValidationRules.FluentValidation
{
    public class PhoneValidator : AbstractValidator<Phone>
    {
        public PhoneValidator()
        {
            RuleFor(m => m.Barcode).NotEmpty().WithMessage("Barkod alanı boş geçilemez");
            RuleFor(m => m.BrandModel).NotEmpty().WithMessage("Marka/Model alanı boş geçilemez");
            RuleFor(m => m.OldPhoneOwnersName).NotEmpty().WithMessage("Adı alanı boş geçilemez");
            RuleFor(m => m.OldPhoneOwnersNo).NotEmpty().WithMessage("No boş geçilemez");
            RuleFor(m => m.ReceivedPrice).GreaterThan(0).WithMessage("Fiyat alanı boş geçilemez");
            RuleFor(m => m.BrandModel).Must(StartWithA);



        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A"); // kendi kuralımızı yazdık ve a ile başlamalı product ismi
        }
    }
}
