namespace Delivery.Models
{
    public class Truck
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Number { get; set; }
        public int? Year { get; set; }
        public int Payload { get; set; }
        public int FuelConsumption { get; set; }
        public int Volume { get; set; }
    }
}
