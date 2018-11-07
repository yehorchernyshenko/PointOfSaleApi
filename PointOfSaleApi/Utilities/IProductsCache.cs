using PointOfSaleApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSaleApi.Utilities
{
    public interface IProductsCache
    {
        List<string> GetProductCodes();
        List<ProductPrice> GetProductPricesByProductCode(string productCode);
    }
}
