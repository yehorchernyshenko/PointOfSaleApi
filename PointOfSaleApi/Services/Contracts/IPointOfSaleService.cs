namespace PointOfSaleApi.Services.Contracts
{
    public interface IPointOfSaleService
    {
        double CalculateTotal(string productCodes);
    }
}