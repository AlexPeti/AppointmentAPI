using AppointmentAPI.DTO;
using AppointmentAPI.Models;
using AutoMapper;

namespace AppointmentAPI.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<AppointmentCreateDTO, Appointment>().ReverseMap();
            CreateMap<AppointmentUpdateDTO, Appointment>().ReverseMap();
            CreateMap<AppointmentReadOnlyDTO, Appointment>().ReverseMap();
        }
    }
}
