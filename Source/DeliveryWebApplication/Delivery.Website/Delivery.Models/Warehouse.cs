using Newtonsoft.Json;
using System.Collections.Generic;

namespace Delivery.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public string Phone { get; set; }

        [JsonIgnore]
        public virtual List<Route> RouteDestWarehouse { get; set; }
        [JsonIgnore]
        public virtual List<Route> RouteOrigWarehouse { get; set; }
    }
}
