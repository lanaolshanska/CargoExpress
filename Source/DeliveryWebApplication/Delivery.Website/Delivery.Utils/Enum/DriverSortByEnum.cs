using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Delivery.Utils.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DriverSortByEnum
    {
        FirstName,
        LastName,
        Status
    }
}
