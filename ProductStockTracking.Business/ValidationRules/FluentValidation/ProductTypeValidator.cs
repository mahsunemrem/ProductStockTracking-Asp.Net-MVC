using FluentValidation;
using ProductStockTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStockTracking.Business.ValidationRules.FluentValidation
{
    public class ProductTypeValidator : AbstractValidator<ProductType>
    {
        public ProductTypeValidator()
        {
            RuleFor(c => c.Type).NotEmpty().WithMessage("Tip alanı boş geçilemez");
        }
    }
}
