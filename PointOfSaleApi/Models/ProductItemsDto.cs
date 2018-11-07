using PointOfSaleApi.Attributes;

namespace PointOfSaleApi.Models
{
    public class ProductItemsDto
    {
        [ValidateProductCodes]
        public string ProductCodes { get; set; }
    }
}