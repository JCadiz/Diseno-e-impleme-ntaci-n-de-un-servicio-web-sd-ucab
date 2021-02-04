using System;

namespace DistribuidosApi.LogicLayer.DTO.Persons
{
    public class PersonCreateDTO : DTO
    {
        public string dni { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

    }
}