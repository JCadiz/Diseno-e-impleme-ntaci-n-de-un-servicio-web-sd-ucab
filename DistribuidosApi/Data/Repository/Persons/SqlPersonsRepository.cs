using System.Linq;
using System.Collections.Generic;
using System;
using DistribuidosApi.Models.Persons;

namespace DistribuidosApi.Data.Repository.Persons
{
    public class SqlPersonsRepository
    {
        //private readonly CommerceContext _context;
        private readonly GeneralContext _context;
        public SqlPersonsRepository(GeneralContext context)
        {
            _context = context;
        }

        public static List<Person> PersonRegister(string dn, string nomb, string apell)
        {
            var PersonsList = new List<Person>();

            var table = GeneralContext.Instance.ExecuteFunction("RegisterPerson(@dnii ,@nomb, @ape)",
            dn, nomb, apell);

            for (var i = 0; i < table.Rows.Count; i++)
            {
                var id = Convert.ToInt32(table.Rows[i][0]);
                var cd = table.Rows[i][1].ToString();
                var nombre = table.Rows[i][2].ToString();
                var ape = table.Rows[i][3].ToString();
                var estatus = table.Rows[i][4].ToString();
                var creado = Convert.ToDateTime(table.Rows[i][5]);

                var person = new Person(id, cd, nombre, ape, estatus, creado);
                PersonsList.Add(person);
            };


            return PersonsList;
        }

        public static List<Person> PersonUpdate(int ida, string dni, string nomb, string apell)
        {
            var PersonsList = new List<Person>();

            var table = GeneralContext.Instance.ExecuteFunction("UpdatePerson(@id_person, @dnii ,@nomb, @ape)",
            ida, dni, nomb, apell);

            for (var i = 0; i < table.Rows.Count; i++)
            {
                var id = Convert.ToInt32(table.Rows[i][0]);
                var cd = table.Rows[i][1].ToString();
                var nombre = table.Rows[i][2].ToString();
                var ape = table.Rows[i][3].ToString();
                var estatus = table.Rows[i][4].ToString();
                var creado = Convert.ToDateTime(table.Rows[i][5]);

                var person = new Person(id, cd, nombre, ape, estatus, creado);
                PersonsList.Add(person);
            };

            return PersonsList;
        }

        public static List<Person> PersonDelete(int ida)
        {
            var PersonsList = new List<Person>();

            var table = GeneralContext.Instance.ExecuteFunction("DeletePerson(@id_faculty)",
            ida);

            for (var i = 0; i < table.Rows.Count; i++)
            {
                var id = Convert.ToInt32(table.Rows[i][0]);
                var cd = table.Rows[i][1].ToString();
                var nombre = table.Rows[i][2].ToString();
                var ape = table.Rows[i][3].ToString();
                var estatus = table.Rows[i][4].ToString();
                var creado = Convert.ToDateTime(table.Rows[i][5]);

                var person = new Person(id, cd, nombre, ape, estatus, creado);
                PersonsList.Add(person);
            };

            return PersonsList;
        }

        public static List<Person> GetAllPersons()
        {

            var PersonsList = new List<Person>();
            var table = GeneralContext.Instance.ExecuteFunction("GetAllPersons()");

            for (var i = 0; i < table.Rows.Count; i++)
            {
                var id = Convert.ToInt32(table.Rows[i][0]);
                var cd = table.Rows[i][1].ToString();
                var nombre = table.Rows[i][2].ToString();
                var ape = table.Rows[i][3].ToString();
                var estatus = table.Rows[i][4].ToString();
                var creado = Convert.ToDateTime(table.Rows[i][5]);

                var person = new Person(id, cd, nombre, ape, estatus, creado);
                PersonsList.Add(person);
            };

            return PersonsList;
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }


    }
}