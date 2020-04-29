using FluentValidation;

namespace ProductStockTracking.Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public class ValidatorTool
    {
        public static void FluentVAlidate(IValidator validator, object entity) //fluent validation dan impoort et
        {
            var result = validator.Validate(entity);

            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
            }

        }
    }
}
