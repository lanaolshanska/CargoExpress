using Newtonsoft.Json;

namespace Delivery.Models.DTO
{
    public class UpdateUserModel : UserModel
    {
        [JsonIgnore]
        public int Id { get; set; }
    }
}
