using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PointOfSaleApi.Models;
using PointOfSaleApi.Services.Contracts;

namespace PointOfSaleApi.Controllers
{
    [Route("api/point-of-sale")]
    public class PointsOfSaleController : ControllerBase
    {
        private readonly IPointOfSaleService pointOfSaleService;

        public PointsOfSaleController(IPointOfSaleService pointOfSaleService)
        {
            this.pointOfSaleService = pointOfSaleService;
        }

        [Route("calculate-total")]
        [HttpPost]
        public IActionResult CalculateTotal(ProductItemsDto productItemsDto)
        {
           if (!ModelState.IsValid)
           {
                return BadRequest(ModelState.Values.SelectMany(modelStateErrors => modelStateErrors.Errors));
           }

            double totalAmount = pointOfSaleService.CalculateTotal(productItemsDto.ProductCodes);

            return Ok(totalAmount);
        }
    }
}