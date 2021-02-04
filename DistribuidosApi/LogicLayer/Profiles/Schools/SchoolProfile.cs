using AutoMapper;
using DistribuidosApi.LogicLayer.DTO.Schools;
using DistribuidosApi.Models.Schools;

namespace DistribuidosApi.LogicLayer.Profiles.Schools
{
    public class SchoolProfile : Profile
    {
        public SchoolProfile()
        {
            //Source -> Target
            CreateMap<School, SchoolReadDTO>();
            CreateMap<SchoolCreateDTO, School>();
            CreateMap<SchoolUpdateDTO, School>();
            CreateMap<School, SchoolUpdateDTO>();
        }
    }
}