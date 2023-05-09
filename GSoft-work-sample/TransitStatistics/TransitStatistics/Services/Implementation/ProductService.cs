using DeliveryLogistics.Dto;
using DeliveryLogistics.Models;
using DeliveryLogistics.Services.Interface;
using DeliveryLogistics.Utilities;
using Newtonsoft.Json;

namespace DeliveryLogistics.Services.Implementation
{
    public class ProductService: IProductService
    {
        private readonly IEnumerable<Product> _products;
        private readonly IEnumerable<Transit> _transits;

        public ProductService()
        {
            _products = LoadProductData();
            _transits = LoadTransitData();
        }

        public IEnumerable<string> GetProductNames()
        {
            return _products.Select(_ => _.Name);
        }

        public IdealProductTransit GetProductTransitDetails(string productName)
        {
            var listOfTransits = new List<IdealProductTransit>();
            var product = _products.Where(_ => _.Name.Equals(productName)).FirstOrDefault();

            if (product == null)
            {
                throw new Exception("Product not defined."); 
            }

            // Calculate distance between factory and destination using Pythagorean theorem
            var distance = Helper.GetDistance(product.FactoryLocation, product.Destination);

            var availableTransits = product.Type == ProductType.Perishable
            ? _transits.Where(t => t.Type != TransportType.Train && t.Type != TransportType.Boat)
            : _transits;


            foreach (var transit in availableTransits)
            {
                // Calculate delivery time using distance and transport speed
                var deliveryTime = distance / transit.Speed;               

                // Calculate total items delivered in one trip
                var itemsPerTrip = (transit.Capacity * 1000) / product.Weight;

                //Calculate total revenue per trip
                var revenue = itemsPerTrip * product.Value;                

                //Calculate total cost per trip
                var cost = transit.Capacity * transit.Cost;

                // Calculate profit using delivery cost and product value
                var profit = revenue - cost;

                // Calculate profit percentage
                var profitPercentage = profit / 100;

                // Calculate number of deliveries per year
                var numberOfDeliveriesInYear = (365 * 24)/ deliveryTime;

                listOfTransits.Add(new IdealProductTransit
                {
                    TransitName = transit.Type.ToString(),
                    AnnualCost = Math.Round(numberOfDeliveriesInYear * cost, 2),
                    AnnualQuantity = Math.Round(numberOfDeliveriesInYear * transit.Capacity, 2),
                    ProfitPercentage = Math.Round(profitPercentage, 2)
                });
            }

            // to be reviewed: the profit percentage does not seem to be right 
            return listOfTransits.OrderBy(_ => _.ProfitPercentage).Last();
        }

        #region private helper methods

        private IEnumerable<Product> LoadProductData()
        {
            // Read the products and transits JSON files
            var productsJson = File.ReadAllText(@"data/products.json");

            // Deserialize the JSON data into C# objects
            var products = JsonConvert.DeserializeObject<List<Product>>(productsJson);

            return products ?? new List<Product>();
        }

        private IEnumerable<Transit> LoadTransitData()
        {
            // Read the products and transits JSON files
            var transitsJson = File.ReadAllText(@"data/transits.json");

            // Deserialize the JSON data into C# objects
            var transits = JsonConvert.DeserializeObject<List<Transit>>(transitsJson);

            return transits ?? new List<Transit>();
        }

        #endregion priivate helper methods
    }
}
