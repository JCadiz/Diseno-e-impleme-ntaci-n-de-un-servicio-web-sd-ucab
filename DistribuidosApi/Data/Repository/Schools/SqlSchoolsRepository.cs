using System.Linq;
using System.Collections.Generic;
using System;
using DistribuidosApi.Models.Schools;

namespace DistribuidosApi.Data.Repository.Schools
{
    public class SqlSchoolsRepository
    {
        //private readonly CommerceContext _context;
        private readonly GeneralContext _context;
        public SqlSchoolsRepository(GeneralContext context)
        {
            _context = context;
        }

        public static List<School> SchoolRegister(string nomb, string des, int fk_faculty)
        {
            var SchoolsList = new List<School>();

            var table = GeneralContext.Instance.ExecuteFunction("RegisterSchool(@nomb, @descri, @fk_faculty)",
            nomb, des, fk_faculty);

            for (var i = 0; i < table.Rows.Count; i++)
            {
                var id = Convert.ToInt32(table.Rows[i][0]);
                var nombre = table.Rows[i][1].ToString();
                var descripcion = table.Rows[i][2].ToString();
                var estatus = table.Rows[i][3].ToString();
                var creado = Convert.ToDateTime(table.Rows[i][4]);
                var facultad = Convert.ToInt32(table.Rows[i][6]);


                var escuela = new School(id, nombre, descripcion, estatus, creado, facultad);
                SchoolsList.Add(escuela);
            };


            return SchoolsList;
        }

        public void DeleteSchool(School bash)
        {
            if (bash == null)
            {
                throw new ArgumentNullException(nameof(bash));
            }
            // _context.school.Remove(bash);
        }
        
        public static List<School> GetAllSchools()
        {
           
            var SchoolsList = new List<School>();
            var table = GeneralContext.Instance.ExecuteFunction("GetAllSchools()");

            for (var i = 0; i < table.Rows.Count; i++)
            {
                var id = Convert.ToInt32(table.Rows[i][0]);
                var nombre = table.Rows[i][1].ToString();
                var descripcion = table.Rows[i][2].ToString();
                var estatus = table.Rows[i][3].ToString();
                var creado = Convert.ToDateTime(table.Rows[i][4]);
                var facultad = Convert.ToInt32(table.Rows[i][6]);
            
                var escuela = new School(id, nombre, descripcion, estatus, creado, facultad);
                SchoolsList.Add(escuela);
            };

            return SchoolsList;
        }

        public static List<School> SchoolUpdate(int id_school, string nomb, string des, int fk_faculty)
        {
            var SchoolsList = new List<School>();

            var table = GeneralContext.Instance.ExecuteFunction("UpdateSchool(@id_school, @nomb, @descri, @fk_faculty)",
            id_school, nomb, des, fk_faculty);

            for (var i = 0; i < table.Rows.Count; i++)
            {
                var id = Convert.ToInt32(table.Rows[i][0]);
                var nombre = table.Rows[i][1].ToString();
                var descripcion = table.Rows[i][2].ToString();
                var estatus = table.Rows[i][3].ToString();
                var creado = Convert.ToDateTime(table.Rows[i][4]);
                var facultad = Convert.ToInt32(table.Rows[i][6]);


                var escuela = new School(id, nombre, descripcion, estatus, creado, facultad);
                SchoolsList.Add(escuela);
            };

            return SchoolsList;
        }

        public static List<School> SchoolDelete(int id_school)
        {
            var SchoolsList = new List<School>();

            var table = GeneralContext.Instance.ExecuteFunction("DeleteSchool(@id_school)",
            id_school);

            for (var i = 0; i < table.Rows.Count; i++)
            {
                var id = Convert.ToInt32(table.Rows[i][0]);
                var nombre = table.Rows[i][1].ToString();
                var descripcion = table.Rows[i][2].ToString();
                var estatus = table.Rows[i][3].ToString();
                var creado = Convert.ToDateTime(table.Rows[i][4]);
                var facultad = Convert.ToInt32(table.Rows[i][6]);


                var escuela = new School(id, nombre, descripcion, estatus, creado, facultad);
                SchoolsList.Add(escuela);
            };

            return SchoolsList;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateSchool(School bash)
        {

        }
    }
}