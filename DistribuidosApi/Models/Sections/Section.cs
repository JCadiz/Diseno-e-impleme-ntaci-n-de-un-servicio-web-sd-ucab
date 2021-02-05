using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace DistribuidosApi.Models.Sections
{
    // definicion de la data a usar en Personas basa en la BD
    public class Section : Entity
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int uc { get; set; }

        [Required]
        public int semester { get; set; }

        [Required]
        public double ht { get; set; }

        [Required]
        public double hp { get; set; }

        [Required]
        public double hl { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string status { get; set; }

        public string type { get; set; }

        public int fk_school { get; set; }

        public DateTime created_date { get; set; }

        public DateTime? deleted_date { get; set; }

        public Section(int id, int uc, int semes, double ht, double hp, double hl, string nombre,
            string des, string estatus, string tipo, int fk, DateTime created) : base(id)
        {
            this.id = id;
            this.uc = uc;
            this.semester = semes;
            this.ht = ht;
            this.hp = hp;
            this.hl = hl;
            this.name = nombre;
            this.description = this.description;
            this.status = estatus;
            this.type = tipo;
            this.fk_school = fk;
            this.created_date = created;
            this.deleted_date = null;
        }

    }
}