using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Delivery.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Role
    {
        Public = 1,
        Driver,
        Admin
    }
}
