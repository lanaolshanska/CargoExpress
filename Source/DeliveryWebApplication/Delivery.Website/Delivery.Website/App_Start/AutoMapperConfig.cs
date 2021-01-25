using AutoMapper;
using Delivery.Website.Areas.Public.Profiles;

namespace Delivery.Website.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(config => {
                config.AddProfile<ContactProfile>();
                config.AddProfile<GeoProfile>();
            });
        }
    }
}