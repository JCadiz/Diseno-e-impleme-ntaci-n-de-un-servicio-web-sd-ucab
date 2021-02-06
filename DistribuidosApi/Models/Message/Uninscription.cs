using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace DistribuidosApi.Models.Message
{
    public class Uninscription : Entity
    {
        private object type1;
        private string v;

        public int id { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public DateTime created_date { get; set; }
        public DateTime? deleted_date { get; set; }
        public int id_section { get; set; }
        public int id_person { get; set; }

        public Uninscription(int id, string status, string type, DateTime created_date, DateTime deleted_date, int id_section, int id_person) : base(id)
        {
            this.id = id;
            this.status = status;
            this.type = type;
            this.created_date = created_date;
            this.deleted_date = deleted_date;
            this.id_person = id_person;
            this.id_section = id_section;

        }

        public Uninscription(int id, int id_person, object type1, string v) : base(id)
        {
            this.id_person = id_person;
            this.type1 = type1;
            this.v = v;
        }
    }
}