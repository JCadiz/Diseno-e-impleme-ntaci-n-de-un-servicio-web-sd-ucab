using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace DistribuidosApi.Models.Persons
{
    // definicion de la data a usar en Personas basa en la BD
    public class Person : Entity
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string dni { get; set; }

        [Required]
        public string first_name { get; set; }

        [Required]
        public string last_name { get; set; }

        public string status { get; set; }

        public DateTime created_date { get; set; }


        public DateTime? deleted_date { get; set; }

        public Person(int id, string cd, string name, string ape, string estatus, DateTime created) : base(id)
        {
            this.id = id;
            this.dni = cd;
            this.first_name = name;
            this.last_name = ape;
            this.status = estatus;
            this.created_date = created;
            this.deleted_date = null;
        }

    }
}