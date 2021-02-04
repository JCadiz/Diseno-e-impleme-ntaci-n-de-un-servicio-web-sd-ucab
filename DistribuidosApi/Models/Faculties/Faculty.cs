using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace DistribuidosApi.Models.Faculties
{
    // definicion de la data a usar en facultades basa en la BD
    public class Faculty: Entity
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string description { get; set; }

        public string status { get; set; }

        public DateTime created_date { get; set; }


        public DateTime? deleted_date { get; set; }

        public Faculty(int id, string name, string des, string estatus, DateTime created) : base(id)
        {
            this.id = id;
            this.name = name;
            this.description = des;
            this.status = estatus;
            this.created_date = created;
            this.deleted_date = null;
        }

    }
}