using DeliveryLogistics.Models;

namespace DeliveryLogistics.Utilities
{
    public class Helper
    {
        public static double GetDistance(string factoryLocation, string destination)
        {
            var parsedFactoryLocation = ParseCoordinates(factoryLocation);
            var parsedDestination = ParseCoordinates(destination);

            var dx = parsedDestination[0] - parsedFactoryLocation[0];
            var dy = parsedDestination[1] - parsedFactoryLocation[1];
            return Math.Sqrt(dx * dx + dy * dy);
        }

        private static double[] ParseCoordinates(string coordinates)
        {
            return coordinates.Split(',').Select(double.Parse).ToArray();
        }
    }
}
