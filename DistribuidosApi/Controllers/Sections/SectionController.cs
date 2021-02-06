using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;
using DistribuidosApi.Exceptions;
using DistribuidosApi.Models.Sections;
using DistribuidosApi.Data.Repository.Sections;
using DistribuidosApi.LogicLayer.DTO.Sections;

namespace DistribuidosApi.Controllers.Sections
{

    [Route("api/sections")]
    [ApiController]
    public class SectionsController : ControllerBase
    {

        private readonly IMapper _mapper;

        public SectionsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        //GET api/sections
        [HttpGet]
        public ActionResult<IEnumerable<Section>> GetAllSections()
        {
            try
            {

                return Ok(SqlSectionsRepository.GetAllSections());
            }
            catch (DatabaseException)
            {
                return StatusCode(500);
            }
        }

        //POST api/sections
        [HttpPost]
        public ActionResult<SectionCreateDTO> SectionRegister(SectionCreateDTO s)
        {
            try
            {
                return Ok(SqlSectionsRepository.SectionRegister(s.uc, s.semester, s.ht, s.hp, s.hl, s.name,
                    s.description,s.type,s.fk_school));
            }
            catch (DatabaseException)
            {
                return StatusCode(500);
            }

        }

        //PUT api/sections
        [HttpPut]
        public ActionResult<SectionUpdateDTO> SectionUpdate(SectionUpdateDTO s)
        {
            try
            {
                return Ok(SqlSectionsRepository.SectionUpdate(s.id, s.uc, s.semester, s.ht, s.hp, s.hl, s.name,
                    s.description, s.type, s.fk_school));
            }
            catch (DatabaseException)
            {
                return StatusCode(500);
            }

        }

        //PUT api/sections
        [HttpDelete]
        public ActionResult<SectionCreateDTO> SectionDelete(SectionUpdateDTO s)
        {
            try
            {
                return Ok(SqlSectionsRepository.SectionDelete(s.id));
            }
            catch (DatabaseException)
            {
                return StatusCode(500);
            }

        }

        //GET api/sections/1/teachers
        [HttpGet("{id_section}/teachers", Name = "SectionTeachers")]
        public ActionResult<SectionCreateDTO> SectionTeachers(int id_section)
        {
            try
            {
                return Ok(SqlSectionsRepository.GetAllTeachers(id_section));
            }
            catch (DatabaseException)
            {
                return StatusCode(500);
            }

        }

        //GET api/sections/1/students
        [HttpGet("{id_section}/students", Name = "SectionStudents")]
        public ActionResult<SectionCreateDTO> SectionStudents(int id_section)
        {
            try
            {
                return Ok(SqlSectionsRepository.GetAllStudents(id_section));
            }
            catch (DatabaseException)
            {
                return StatusCode(500);
            }
        }

        //POST api/sections/1/inscription
        [HttpPost("{id_section}/inscription", Name = "SectionInscription")]
        public ActionResult<InscriptionDTO> SectionInscription(int id_section, InscriptionDTO ins)
        {
            try
            {
                return Ok(SqlSectionsRepository.SectionInscription(id_section, ins.id_person, ins.type));
            }
            catch (DatabaseException)
            {
                return StatusCode(500);
            }
        }

        //POST api/sections/1/inscription
        [HttpDelete("{id_section}/inscription", Name = "SectionInscription")]
        public ActionResult<InscriptionDTO> SectionUninscription(int id_section, InscriptionDTO ins)
        {
            try
            {
                return Ok(SqlSectionsRepository.SectionUninscription(id_section, ins.id_person));
            }
            catch (DatabaseException)
            {
                return StatusCode(500);
            }
        }

    }
}