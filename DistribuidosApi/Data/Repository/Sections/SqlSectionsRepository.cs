using System.Linq;
using System.Collections.Generic;
using System;
using DistribuidosApi.Models.Sections;

namespace DistribuidosApi.Data.Repository.Sections
{
    public class SqlSectionsRepository
    {
        private readonly GeneralContext _context;
        public SqlSectionsRepository(GeneralContext context)
        {
            _context = context;
        }

        public static List<Section> SectionRegister(int u, int semes, double ht, double hp, double hl,
        string nomb, string des, string ty, int fk)
        {
            var SectionsList = new List<Section>();

            var table = GeneralContext.Instance.ExecuteFunction("RegisterSection(@u, @semes, @ht, @hp, @hl, @nomb, @descri, @ty, @fk)",
            u, semes, ht, hp, hl, nomb, des, ty, fk);

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

        public static List<Section> SectionUpdate(int ida, int u, int semes, double ht, double hp, double hl,
        string nomb, string des, string ty, int fk)
        {
            var SectionsList = new List<Section>();

            var table = GeneralContext.Instance.ExecuteFunction("UpdateSection(@id_section, @u, @semes, @ht, @hp, @hl, @nomb, @descri, @ty, @fk)",
            ida, nomb, des);

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
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }


    }
}