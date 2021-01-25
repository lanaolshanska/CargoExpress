using Newtonsoft.Json;

namespace Delivery.Models.DTO
{
    public class UpdateCargoModel : CargoModel
    {
        [JsonIgnore]
        public int Id { get; set; }
    }
}
