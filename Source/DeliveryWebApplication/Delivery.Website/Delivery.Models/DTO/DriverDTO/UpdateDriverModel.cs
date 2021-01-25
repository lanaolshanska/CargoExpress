using Newtonsoft.Json;

namespace Delivery.Models.DTO
{
    public class UpdateDriverModel : DriverModel
    {
        [JsonIgnore]
        public int Id { get; set; }
    }
}
