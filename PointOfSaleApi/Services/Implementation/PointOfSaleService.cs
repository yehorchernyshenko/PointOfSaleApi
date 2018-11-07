using PointOfSaleApi.Entities;
using PointOfSaleApi.Services.Contracts;
using PointOfSaleApi.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace PointOfSaleApi.Services.Implementation
{
    public class PointOfSaleService : IPointOfSaleService
    {
        private readonly IProductsCache productsCache;

        public PointOfSaleService(IProductsCache productsCache)
        {
            this.productsCache = productsCache;
        }

        public double CalculateTotal(string productCodes)
        {
            var groupedProductCodes = productCodes.ToUpper().ToCharArray().GroupBy(productCode => productCode);

            double totalPrice = 0;

            foreach (var productCodeGroup in groupedProductCodes)
            {
                totalPrice += CalculateProductItemPrice(productCodeGroup.Key.ToString(), productCodeGroup.Count());
            }

            return totalPrice;
        }

        private double CalculateProductItemPrice(string productCode, int quantity)
        {
            List<ProductPrice> productPrices = productsCache.GetProductPricesByProductCode(productCode);

            ProductPrice defaultProductPrice = productPrices.First(productPrice => productPrice.Quantity == 1);

            //add check for default price existence??

            double totalProductPrice = 0;

            if (quantity == 1)
            {
                totalProductPrice = defaultProductPrice.Price;
            }
            else
            {
                ProductPrice volumeProductPrice = productPrices.First(productPrice => quantity >= productPrice.Quantity);

                //add check for volume price existence??

                totalProductPrice = volumeProductPrice.Price + (quantity - volumeProductPrice.Quantity) * defaultProductPrice.Price;
            }
            return totalProductPrice;
        }
    }
}