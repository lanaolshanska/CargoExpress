using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Delivery.Models
{
    public class Route
    {
        public int Id { get; set; }
        public int OriginWarehouseId { get; set; }
        public int DestinationWarehouseId { get; set; }
        public double Distance { get; set; }

        [JsonIgnore]
        public virtual Warehouse OrigWarehouse { get; set; }
        [JsonIgnore]
        public virtual Warehouse DestWarehouse { get; set; }
        
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
