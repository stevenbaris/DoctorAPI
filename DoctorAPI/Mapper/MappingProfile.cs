using AutoMapper;
using DoctorAPI.DTO;
using DoctorAPI.Model;
using DoctorAPI.DTO;
using DoctorAPI.Models;

namespace DoctorAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Doctor, DoctorDTO>().ReverseMap();

            CreateMap<ApplicationUser, SignUpDTO>().ReverseMap()
                .ForMember(x => x.UserName, y => y.MapFrom(z => z.Email));
        }
    }
}
