using DeliveryLogistics.Dto;

namespace DeliveryLogistics.Services.Interface
{
    public interface IProductService
    {
        public IEnumerable<string> GetProductNames();

        public IdealProductTransit GetProductTransitDetails(string productName);
    }
}
