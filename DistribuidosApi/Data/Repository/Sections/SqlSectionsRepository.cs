using System.Linq;
using System.Collections.Generic;
using System;
using DistribuidosApi.Models.Sections;
using DistribuidosApi.Models.Persons;
using DistribuidosApi.Models.Message;
using DistribuidosApi.LogicLayer.DTO.Sections;

namespace DistribuidosApi.Data.Repository.Sections
{
    public class SqlSectionsRepository
    {
        private readonly GeneralContext _context;
        public SqlSectionsRepository(GeneralContext context)
        {
            _context = context;
        }

        public static List<Section> SectionRegister(int u, int semes, float ht, float hp, float hl,
        string nomb, string des, string ty, int fk)
        {
            var SectionsList = new List<Section>();

            var table = GeneralContext.Instance.ExecuteFunction("RegisterSection(@u, @semes, @htt, @hpp, @hll, @nomb, @descri, @ty, @fk)",
            u, semes, Convert.ToDouble(ht), Convert.ToDouble(hp), Convert.ToDouble(hl), nomb, des, ty, fk);

            for (var i = 0; i < table.Rows.Count; i++)
            {
                var id = Convert.ToInt32(table.Rows[i][0]);
                var ucc = Convert.ToInt32(table.Rows[i][1]);
                var semestre = Convert.ToInt32(table.Rows[i][2]);
                var htt = Convert.ToDouble(table.Rows[i][3]);
                var hpp = Convert.ToDouble(table.Rows[i][4]);
                var hll = Convert.ToDouble(table.Rows[i][5]);
                var nombre = table.Rows[i][6].ToString();
                var descripcion = table.Rows[i][7].ToString();
                var estatus = table.Rows[i][8].ToString();
                var tipo = table.Rows[i][9].ToString();
                var creado = Convert.ToDateTime(table.Rows[i][10]);
                var fk_s = Convert.ToInt32(table.Rows[i][12]);

                var Section = new Section(id, ucc, semestre, htt, hpp, hll,
                    nombre, descripcion, estatus, tipo, fk_s, creado);
                SectionsList.Add(Section);
            };

            return SectionsList;
        }

        public static List<Section> SectionUpdate(int ida, int u, int semes, float ht, float hp, float hl,
        string nomb, string des, string ty, int fk)
        {
            var SectionsList = new List<Section>();

            var table = GeneralContext.Instance.ExecuteFunction("UpdateSection(@id_section, @uc2, @semes2, @ht2, @hp2, @hl2, @nomb2, @descri2, @ty2, @fk2)",
            ida, u, semes, Convert.ToDouble(ht), Convert.ToDouble(hp), Convert.ToDouble(hl), nomb, des, ty, fk);

            for (var i = 0; i < table.Rows.Count; i++)
            {
                var id = Convert.ToInt32(table.Rows[i][0]);
                var ucc = Convert.ToInt32(table.Rows[i][1]);
                var semestre = Convert.ToInt32(table.Rows[i][2]);
                var htt = Convert.ToDouble(table.Rows[i][3]);
                var hpp = Convert.ToDouble(table.Rows[i][4]);
                var hll = Convert.ToDouble(table.Rows[i][5]);
                var nombre = table.Rows[i][6].ToString();
                var descripcion = table.Rows[i][7].ToString();
                var estatus = table.Rows[i][8].ToString();
                var tipo = table.Rows[i][9].ToString();
                var creado = Convert.ToDateTime(table.Rows[i][10]);
                var fk_s = Convert.ToInt32(table.Rows[i][12]);

                var Section = new Section(id, ucc, semestre, htt, hpp, hll,
                    nombre, descripcion, estatus, tipo, fk_s, creado);
                SectionsList.Add(Section);
            };

            return SectionsList;
        }

        public static List<Section> SectionDelete(int ida)
        {
            var SectionsList = new List<Section>();

            var table = GeneralContext.Instance.ExecuteFunction("DeleteSection(@id_section)",
            ida);

            for (var i = 0; i < table.Rows.Count; i++)
            {
                var id = Convert.ToInt32(table.Rows[i][0]);
                var ucc = Convert.ToInt32(table.Rows[i][1]);
                var semestre = Convert.ToInt32(table.Rows[i][2]);
                var htt = Convert.ToDouble(table.Rows[i][3]);
                var hpp = Convert.ToDouble(table.Rows[i][4]);
                var hll = Convert.ToDouble(table.Rows[i][5]);
                var nombre = table.Rows[i][6].ToString();
                var descripcion = table.Rows[i][7].ToString();
                var estatus = table.Rows[i][8].ToString();
                var tipo = table.Rows[i][9].ToString();
                var creado = Convert.ToDateTime(table.Rows[i][10]);
                var fk_s = Convert.ToInt32(table.Rows[i][12]);

                var Section = new Section(id, ucc, semestre, htt, hpp, hll,
                    nombre, descripcion, estatus, tipo, fk_s, creado);
                SectionsList.Add(Section);
            };


            return SectionsList;
        }

        public static List<Section> GetAllSections()
        {

            var SectionsList = new List<Section>();
            var table = GeneralContext.Instance.ExecuteFunction("GetAllSections()");

            for (var i = 0; i < table.Rows.Count; i++)
            {
                var id = Convert.ToInt32(table.Rows[i][0]);
                var ucc = Convert.ToInt32(table.Rows[i][1]);
                var semestre = Convert.ToInt32(table.Rows[i][2]);
                var htt = Convert.ToDouble(table.Rows[i][3]);
                var hpp = Convert.ToDouble(table.Rows[i][4]);
                var hll = Convert.ToDouble(table.Rows[i][5]);
                var nombre = table.Rows[i][6].ToString();
                var descripcion = table.Rows[i][7].ToString();
                var estatus = table.Rows[i][8].ToString();
                var tipo = table.Rows[i][9].ToString();
                var creado = Convert.ToDateTime(table.Rows[i][10]);
                var fk_s = Convert.ToInt32(table.Rows[i][12]);

                var Section = new Section(id, ucc, semestre, htt, hpp, hll,
                    nombre, descripcion, estatus, tipo, fk_s, creado);
                SectionsList.Add(Section);
            };

            return SectionsList;
        }

        public static List<Person> GetAllTeachers(int id_section)
        {
            var PersonsList = new List<Person>();

            var table = GeneralContext.Instance.ExecuteFunction("GetAllTeachersFromSection(@id_section)", id_section);

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

        public static List<Person> GetAllStudents(int id_section)
        {
            var PersonsList = new List<Person>();

            var table = GeneralContext.Instance.ExecuteFunction("GetAllStudentsFromSection(@id_section)", id_section);

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

        public static List<Inscription> SectionInscription(int id_section, int id_person, String type)
        {
            var inscriptionList = new List<Inscription>();

            var table = GeneralContext.Instance.ExecuteFunction("Inscription(@id_section, @id_person, @type)", id_section, id_person, type);
            
            for (var i = 0; i < table.Rows.Count; i++)
            {
                var result = Convert.ToBoolean(table.Rows[i][0]);

                if(result == true){
                    var iscription = new Inscription(id_section, id_person, type, "Usuario inscrito");
                    inscriptionList.Add(iscription);
                }else{
                    var iscription = new Inscription(id_section, id_person, type, "Operacion fallida, el usuario ya se encuentra inscrito");
                    inscriptionList.Add(iscription);
                }

            };

            return inscriptionList;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }


    }
}