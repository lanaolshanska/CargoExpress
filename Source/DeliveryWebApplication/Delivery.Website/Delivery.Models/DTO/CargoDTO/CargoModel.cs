namespace Delivery.Models.DTO
{
    public class CargoModel
    {
        public double Weight { get; set; }
        public double Volume { get; set; }
        public int SenderContactId { get; set; }
        public int RecipientContactId { get; set; }
        public int OriginWarehouseId { get; set; }
        public int DestinationWarehouseId { get; set; }
    }
}