using System;

namespace DistribuidosApi.LogicLayer.DTO.Persons
{
    public class PersonUpdateDTO : DTO
    {
        public int id { get; set; }
        public string dni { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

    }
}