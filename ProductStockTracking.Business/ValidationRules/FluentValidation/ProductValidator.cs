using FluentValidation;
using ProductStockTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStockTracking.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {

        public ProductValidator()
        {
            RuleFor(m => m.BrandModel).NotEmpty().WithMessage("Marka/Model alanı boş geçilemez");
            RuleFor(m => m.Features).NotEmpty().WithMessage("Özellikler alanı boş geçilemez");
        }
    }
}
