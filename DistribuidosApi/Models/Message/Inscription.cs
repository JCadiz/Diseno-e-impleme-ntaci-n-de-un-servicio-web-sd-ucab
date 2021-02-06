using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace DistribuidosApi.Models.Message
{
    public class Inscription : Entity
    {
        public int id_section { get; set; }
        public int id_person { get; set; }
        public string type { get; set; }
        public string message { get; set; }

        public Inscription(int id_section, int id_person, string type, string message) : base(id_section)
        {
            this.id_section = id_section;
            this.id_person = id_person;
            this.type = type;
            this.message = message;

        }

    }
}