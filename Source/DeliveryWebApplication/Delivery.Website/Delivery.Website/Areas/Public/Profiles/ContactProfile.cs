using AutoMapper;
using Delivery.Models;
using Delivery.Website.Areas.Public.Models;

namespace Delivery.Website.Areas.Public.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        { 
            CreateMap<Contact, CargoContactModel>()
                .ForMember(model => model.Id, opt => opt.MapFrom(t => t.Id))
                .ForMember(model => model.FirstName, opt => opt.MapFrom(t => t.FirstName))
                .ForMember(model => model.LastName, opt => opt.MapFrom(t => t.LastName))
                .ForMember(model => model.Phone, opt => opt.MapFrom(t => t.CellPhone))
                .ForMember(model => model.Email, opt => opt.MapFrom(t => t.Email))
                .ForMember(model => model.Address, opt => opt.MapFrom(t => t.Address));

            CreateMap<CargoContactModel, Contact>()
                .ForMember(model => model.Id, opt => opt.MapFrom(t => t.Id))
                .ForMember(model => model.FirstName, opt => opt.MapFrom(t => t.FirstName))
                .ForMember(model => model.LastName, opt => opt.MapFrom(t => t.LastName))
                .ForMember(model => model.CellPhone, opt => opt.MapFrom(t => t.Phone))
                .ForMember(model => model.Email, opt => opt.MapFrom(t => t.Email))
                .ForMember(model => model.Address, opt => opt.MapFrom(t => t.Address));
        }
    }
}