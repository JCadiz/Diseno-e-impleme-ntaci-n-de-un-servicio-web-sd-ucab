using AutoMapper;
using DistribuidosApi.LogicLayer.DTO.Sections;
using DistribuidosApi.Models.Sections;

namespace DistribuidosApi.LogicLayer.Profiles.Sections
{
    public class SectionProfile : Profile
    {
        public SectionProfile()
        {
            //Source -> Target
            CreateMap<Section, SectionReadDTO>();
            CreateMap<SectionCreateDTO, Section>();
            CreateMap<SectionUpdateDTO, Section>();
            CreateMap<Section, SectionUpdateDTO>();
        }
    }
}