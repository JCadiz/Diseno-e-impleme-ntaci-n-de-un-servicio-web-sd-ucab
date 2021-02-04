using System;

namespace DistribuidosApi.LogicLayer.DTO.Faculties
{
    public class FacultyUpdateDTO : DTO
    {
        public string name { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public DateTime created_date { get; set; }
        public DateTime deleted_date { get; set; }

    }
}