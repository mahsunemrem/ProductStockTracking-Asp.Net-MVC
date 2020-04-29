using FluentValidation;
using ProductStockTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStockTracking.Business.ValidationRules.FluentValidation
{
    public class ProductMovementValidator : AbstractValidator<ProductMovement>
    {
        public ProductMovementValidator()
        {
            RuleFor(m => m.Barcode).NotEmpty().WithMessage("Barkod alanı boş geçilemez");
            RuleFor(m => m.Price).GreaterThan(0).WithMessage("Fiyat alanı 0 dan büyük olmalı");
            RuleFor(m => m.Piece).GreaterThan(0).WithMessage("Adet alanı 0 dan büyük olmalı");

        }
    }
}
