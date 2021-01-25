namespace Delivery.Website.Areas.Public.Models
{
    public class OrderModel
    {
        public double Weight { get; set; }

        public double Volume { get; set; }

        public CargoContactModel Sender { get; set; }

        public CargoContactModel Recipient { get; set; }

        public CargoPlaceModel OrigPlace { get; set; }

        public CargoPlaceModel DestPlace { get; set; }
    }
}