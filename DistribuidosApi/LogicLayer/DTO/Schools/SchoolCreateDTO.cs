using System;

namespace DistribuidosApi.LogicLayer.DTO.Schools
{
    public class SchoolCreateDTO : DTO
    {
        public string name { get; set; }
        public string description { get; set; }

        public int fk_faculty { get; set; }

    }
}