using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Delivery.Models
{
    public class Shipment
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public int TruckId { get; set; }
        public int CargoId { get; set; }
        public int RouteId { get; set; }
        public DateTime? SentDate { get; set; }
        public DateTime? ReceivedDate { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Route Route { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Driver Driver { get; set; }

    }
}

