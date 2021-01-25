using AutoMapper;
using Delivery.WebAPI.Profiles;
using Delivery.Website.Areas.Public.Profiles;

namespace Delivery.WebAPI
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(config => {
                config.AddProfile<DTOProfile>();
                config.AddProfile<GeoProfile>();
            });
        }
    }
}
