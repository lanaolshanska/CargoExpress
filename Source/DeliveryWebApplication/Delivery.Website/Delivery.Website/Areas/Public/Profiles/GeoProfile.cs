using AutoMapper;
using Delivery.Models;
using Delivery.Website.Areas.Public.Models;

namespace Delivery.Website.Areas.Public.Profiles
{
    public class GeoProfile:Profile
    {
        public GeoProfile()
        {
            CreateMap<Warehouse, StateModel>()
                .ForMember(model => model.Id, opt => opt.MapFrom(t => t.Id))
                .ForMember(model => model.Name, opt => opt.MapFrom(t => t.State));

            CreateMap<Warehouse, CityModel>()
                .ForMember(model => model.Id, opt => opt.MapFrom(t => t.Id))
                .ForMember(model => model.Name, opt => opt.MapFrom(t => t.City));
        }
    }
}