using Newtonsoft.Json;

namespace DeliveryLogistics.Models
{
    public class Transit
    {
        [JsonProperty(PropertyName = "type")]
        public TransportType Type {get; set;}

        // metric ton
        [JsonProperty(PropertyName = "capacity")]
        public int Capacity { get; set; }

        // $ per metric ton
        [JsonProperty(PropertyName = "cost")]
        public double Cost { get; set; }

        // km/h
        [JsonProperty(PropertyName = "speed")]
        public double Speed { get; set; }
    }

    public enum TransportType
    {
        Truck,
        Train,
        Plane,
        Boat
    }
}
