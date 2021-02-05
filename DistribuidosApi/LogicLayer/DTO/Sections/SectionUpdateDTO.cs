namespace DistribuidosApi.LogicLayer.DTO.Sections
{
    // definicion de la data a usar en Sections basa en la BD
    public class SectionUpdateDTO : DTO
    {
        public int id { get; set; }
        
        public int uc { get; set; }

        public int semester { get; set; }

        public double ht { get; set; }

        public double hp { get; set; }

        public double hl { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string type { get; set; }

        public int fk_school { get; set; }

    }
}