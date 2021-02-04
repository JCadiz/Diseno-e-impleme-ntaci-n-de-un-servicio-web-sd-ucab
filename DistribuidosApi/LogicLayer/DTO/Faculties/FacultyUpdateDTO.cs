using System;

namespace DistribuidosApi.LogicLayer.DTO.Faculties
{
    public class FacultyUpdateDTO : DTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        
    }
}