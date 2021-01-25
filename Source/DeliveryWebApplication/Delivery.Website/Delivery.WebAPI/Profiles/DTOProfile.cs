using AutoMapper;
using Delivery.Models;
using Delivery.Models.DTO;

namespace Delivery.WebAPI.Profiles
{
    public class DTOProfile : Profile
    {
        public DTOProfile()
        {
            CreateMap<WarehouseModel, Warehouse>()
                .ForMember(model => model.State, opt => opt.MapFrom(t => t.State))
                .ForMember(model => model.City, opt => opt.MapFrom(t => t.City))
                .ForMember(model => model.Postcode, opt => opt.MapFrom(t => t.Postcode))
                .ForMember(model => model.Phone, opt => opt.MapFrom(t => t.Phone));

            CreateMap<ContactModel, Contact>()
                .ForMember(model => model.FirstName, opt => opt.MapFrom(t => t.FirstName))
                .ForMember(model => model.LastName, opt => opt.MapFrom(t => t.LastName))
                .ForMember(model => model.CellPhone, opt => opt.MapFrom(t => t.Phone))
                .ForMember(model => model.Address, opt => opt.MapFrom(t => t.Address))
                .ForMember(model => model.Email, opt => opt.MapFrom(t => t.Email));

            CreateMap<CargoModel, Cargo>()
                .ForMember(model => model.Weight, opt => opt.MapFrom(t => t.Weight))
                .ForMember(model => model.Volume, opt => opt.MapFrom(t => t.Volume))
                .ForMember(model => model.SenderContactId, opt => opt.MapFrom(t => t.SenderContactId))
                .ForMember(model => model.RecipientContactId, opt => opt.MapFrom(t => t.RecipientContactId));

            CreateMap<UserModel, User>()
                .ForMember(model => model.Username, opt => opt.MapFrom(t => t.Username))
                .ForMember(model => model.Password, opt => opt.MapFrom(t => t.Password))
                .ForMember(model => model.Email, opt => opt.MapFrom(t => t.Email))
                .ForMember(model => model.Role, opt => opt.MapFrom(t => t.Role));

            CreateMap<DriverModel, Driver>()
                .ForMember(model => model.FirstName, opt => opt.MapFrom(t => t.FirstName))
                .ForMember(model => model.LastName, opt => opt.MapFrom(t => t.LastName))
                .ForMember(model => model.Birthdate, opt => opt.MapFrom(t => t.Birthdate))
                .ForMember(model => model.Address, opt => opt.MapFrom(t => t.Address))
                .ForMember(model => model.StartedDrivingYear, opt => opt.MapFrom(t => t.StartedDrivingYear))
                .ForMember(model => model.HasCriminalRecord, opt => opt.MapFrom(t => t.HasCriminalRecord));
        }
    }
}