using System.Linq;
using System.Collections.Generic;
using System;
using DistribuidosApi.Models.Faculties;

namespace DistribuidosApi.Data.Repository.Faculties
{
    public class SqlFacultiesRepository
    {
        //private readonly CommerceContext _context;
        private readonly GeneralContext _context;
        public SqlFacultiesRepository(GeneralContext context)
        {
            _context = context;
        }

        public static List<Faculty> FacultyRegister(string nomb, string des)
        {
            var FacultiesList = new List<Faculty>();

            var table = GeneralContext.Instance.ExecuteFunction("RegisterFaculty(@nomb, @descri)",
            nomb, des);

            for (var i = 0; i < table.Rows.Count; i++)
            {
                var id = Convert.ToInt32(table.Rows[i][0]);
                var nombre = table.Rows[i][1].ToString();
                var descripcion = table.Rows[i][2].ToString();
                var estatus = table.Rows[i][3].ToString();
                var creado = Convert.ToDateTime(table.Rows[i][4]);

                var facultad = new Faculty(id, nombre, descripcion, estatus, creado);
                FacultiesList.Add(facultad);
            };


            return FacultiesList;
        }

        public void DeleteFaculty(Faculty bash)
        {
            if (bash == null)
            {
                throw new ArgumentNullException(nameof(bash));
            }
            _context.faculty.Remove(bash);
        }
        
        public static List<Faculty> GetAllFaculties()
        {
           
            var FacultiesList = new List<Faculty>();
            var table = GeneralContext.Instance.ExecuteFunction("GetAllFaculties()");

            for (var i = 0; i < table.Rows.Count; i++)
            {
                var id = Convert.ToInt32(table.Rows[i][0]);
                var nombre = table.Rows[i][1].ToString();
                var descripcion = table.Rows[i][2].ToString();
                var estatus = table.Rows[i][3].ToString();
                var creado = Convert.ToDateTime(table.Rows[i][4]);
            
                var facultad = new Faculty(id, nombre, descripcion, estatus, creado);
                FacultiesList.Add(facultad);
            };

            return FacultiesList;
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateFaculty(Faculty bash)
        {

        }
    }
}