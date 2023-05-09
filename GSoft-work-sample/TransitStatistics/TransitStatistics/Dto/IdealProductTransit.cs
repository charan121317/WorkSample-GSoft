using DeliveryLogistics.Models;
using Newtonsoft.Json;

namespace DeliveryLogistics.Dto
{
    public class IdealProductTransit
    {
        [JsonProperty(PropertyName = "transitName")]
        public string TransitName { get; set; }

        [JsonProperty(PropertyName = "annualCost")]
        public double AnnualCost { get; set; }

        [JsonProperty(PropertyName = "annualQuantity")]
        public double AnnualQuantity { get; set; }

        [JsonProperty(PropertyName = "profitPercentage")]
        public double ProfitPercentage { get; set; }
    }
}
