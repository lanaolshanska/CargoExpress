using Newtonsoft.Json;

namespace Delivery.Models.DTO
{
    public class UpdateContactModel : ContactModel
    {
        [JsonIgnore]
        public int Id { get; set; }
    }
}
