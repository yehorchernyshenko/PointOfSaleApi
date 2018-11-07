using PointOfSaleApi.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PointOfSaleApi.Utilities
{
    public class ProductsCache: IProductsCache
    {
        private List<string> productCodes { get; set; }
        private List<ProductPrice> productPrices { get; set; }

        public ProductsCache()
        {
            productCodes = new List<string> { "A", "B", "C", "D"};
            productPrices = new List<ProductPrice>
            {
                new ProductPrice {ProductCode = "A", Quantity=1, Price=1.25},
                new ProductPrice {ProductCode = "A", Quantity=3, Price=3.00},
                new ProductPrice {ProductCode = "B", Quantity=1, Price=4.25},
                new ProductPrice {ProductCode = "C", Quantity=1, Price=1.00},
                new ProductPrice {ProductCode = "C", Quantity=6, Price=5.00},
                new ProductPrice {ProductCode = "D", Quantity=1, Price=0.75}
            };
        }

        public List<string> GetProductCodes()
        {
            return productCodes;
        }

        public List<ProductPrice> GetProductPricesByProductCode(string productCode)
        {
            return productPrices.
                    Where(productPrice => productPrice.ProductCode == productCode).
                    OrderByDescending(productPrice => productPrice.Quantity).
                    ToList();
        }
    }
}