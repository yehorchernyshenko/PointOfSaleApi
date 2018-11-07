using PointOfSaleApi.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PointOfSaleApi.Attributes
{
    public class ValidateProductCodesAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var productCodes = value as string;

            //add check for whitespace in string??

            if (productCodes == null)
            {
                return new ValidationResult("Product codes should not be empty.");
            }
            else
            {
                var productCodesCache = (IProductsCache)validationContext
                                                        .GetService(typeof(IProductsCache));

                var cachedProductCodes = productCodesCache.GetProductCodes();

                var distinctProductCodes = productCodes.ToUpper().ToCharArray().Distinct();

                if (distinctProductCodes.Any(productCode => !cachedProductCodes.Contains(productCode.ToString())))
                {
                    return new ValidationResult("Product codes contain unexistent product code.");
                } 
                else
                {
                    return ValidationResult.Success;
                }
            }
        }
    }
}