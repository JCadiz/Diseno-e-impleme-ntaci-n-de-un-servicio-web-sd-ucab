using AutoMapper;
using DistribuidosApi.LogicLayer.DTO.Persons;
using DistribuidosApi.Models.Persons;

namespace DistribuidosApi.LogicLayer.Profiles.Persons
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            //Source -> Target
            CreateMap<Person, PersonReadDTO>();
            CreateMap<PersonCreateDTO, Person>();
            CreateMap<PersonUpdateDTO, Person>();
            CreateMap<Person, PersonUpdateDTO>();
        }
    }
}