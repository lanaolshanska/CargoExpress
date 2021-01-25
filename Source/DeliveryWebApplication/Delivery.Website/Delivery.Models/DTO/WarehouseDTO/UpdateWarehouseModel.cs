using Newtonsoft.Json;

namespace Delivery.Models.DTO
{
    public class UpdateWarehouseModel : WarehouseModel
    {
        [JsonIgnore]
        public int Id { get; set; }
    }
}
