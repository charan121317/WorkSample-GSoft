using Newtonsoft.Json;

namespace DeliveryLogistics.Models
{
    public class Product
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "factoryLocation")]
        public string FactoryLocation { get; set; }

        [JsonProperty(PropertyName = "destination")]
        public string Destination { get; set; }

        // in kg
        [JsonProperty(PropertyName = "weight")]
        public double Weight { get; set; }

        // in $
        [JsonProperty(PropertyName = "value")]
        public double Value { get; set; }

        [JsonProperty(PropertyName = "type")]
        public ProductType Type { get; set; }
    }   

    public enum ProductType
    {
        NonPerishable,
        Perishable
    }
}
