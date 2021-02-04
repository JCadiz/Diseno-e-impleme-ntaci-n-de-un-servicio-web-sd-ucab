using System;

namespace DistribuidosApi.LogicLayer.DTO.Faculties
{
    public class FacultyReadDTO : DTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public DateTime created_date { get; set; }
        public DateTime deleted_date { get; set; }

    }
}