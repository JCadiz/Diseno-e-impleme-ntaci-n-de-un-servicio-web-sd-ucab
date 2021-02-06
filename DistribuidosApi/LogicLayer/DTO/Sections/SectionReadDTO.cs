using System;

namespace DistribuidosApi.LogicLayer.DTO.Sections
{
    // definicion de la data a usar en Personas basa en la BD
    public class SectionReadDTO : DTO
    {
        public int id { get; set; }

        public int uc { get; set; }

        public int semester { get; set; }

        public float ht { get; set; }

        public float hp { get; set; }

        public float hl { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string status { get; set; }

        public string type { get; set; }

        public int fk_school { get; set; }

        public DateTime created_date { get; set; }

        public DateTime? deleted_date { get; set; }

    }
}