using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Delivery.Models
{
    public class Cargo
    {
        public int Id { get; set; }
        public double Weight { get; set; }
        public double Volume { get; set; }
        public int SenderContactId { get; set; }
        public int RecipientContactId { get; set; }
        public int? UserId { get; set; }
        public int? DriverId { get; set; }
        public int RouteId { get; set; }

        [Column(TypeName = "int")]
        public CargoStatus? Status { get; set; }

        [JsonIgnore]
        public virtual Contact Recipient { get; set; }
        [JsonIgnore]
        public virtual Contact Sender { get; set; }
        [JsonIgnore]
        public virtual Driver Driver { get; set; }
        [JsonIgnore]
        public virtual Route Route { get; set; }
    }
}