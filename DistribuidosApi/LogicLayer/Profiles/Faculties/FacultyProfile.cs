using AutoMapper;
using DistribuidosApi.LogicLayer.DTO.Faculties;
using DistribuidosApi.Models.Faculties;

namespace DistribuidosApi.LogicLayer.Profiles.Faculties
{
    public class FacultyProfile : Profile
    {
        public FacultyProfile()
        {
            //Source -> Target
            CreateMap<Faculty, FacultyReadDTO>();
            CreateMap<FacultyCreateDTO, Faculty>();
            CreateMap<FacultyUpdateDTO, Faculty>();
            CreateMap<Faculty, FacultyUpdateDTO>();
        }
    }
}