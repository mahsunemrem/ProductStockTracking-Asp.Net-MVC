using FluentValidation;
using ProductStockTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStockTracking.Business.ValidationRules.FluentValidation
{
    public class ProductBarcodeValidator : AbstractValidator<ProductBarcode>
    {
        public ProductBarcodeValidator()
        {
            RuleFor(m => m.Barcode).NotEmpty().WithMessage("Barkod alanı boş geçilemez");
        }
    }
}
