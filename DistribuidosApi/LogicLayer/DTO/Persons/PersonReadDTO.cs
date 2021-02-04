using System;

namespace DistribuidosApi.LogicLayer.DTO.Persons
{
    public class PersonReadDTO : DTO
    {
        public int id { get; set; }

        public string dni { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string status { get; set; }

        public DateTime created_date { get; set; }

        public DateTime deleted_date { get; set; }

    }
}