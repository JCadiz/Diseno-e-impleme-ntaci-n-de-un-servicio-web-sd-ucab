using System;

namespace DistribuidosApi.LogicLayer.DTO.Schools
{
    public class SchoolReadDTO : DTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public DateTime created_date { get; set; }
        public DateTime deleted_date { get; set; }
        public int fk_faculty { get; set; }
    }
}