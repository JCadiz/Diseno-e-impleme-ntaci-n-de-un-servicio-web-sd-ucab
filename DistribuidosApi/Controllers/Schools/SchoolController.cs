using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;
using DistribuidosApi.Exceptions;
using DistribuidosApi.LogicLayer.DTO.Schools;
using DistribuidosApi.Models.Schools;
using DistribuidosApi.Data.Repository.Schools;

namespace DistribuidosApi.Controllers.Schools
{

    [Route("api/schools")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {

        private readonly IMapper _mapper;

        public SchoolsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        //GET api/schools
        [HttpGet]
        public ActionResult<IEnumerable<School>> GetAllSchools()
        {
            try
            {
                
                return Ok(SqlSchoolsRepository.GetAllSchools());
            }
            catch (DatabaseException)
            {
                return StatusCode(500);
            }
        }

        //POST api/schools
        [HttpPost]
        public ActionResult<SchoolCreateDTO> SchoolRegister(SchoolCreateDTO escuela )
        {
            try
            {
                //var schoolModel = _mapper.Map<School>(facu);
                
                return Ok(SqlSchoolsRepository.SchoolRegister(escuela.name, escuela.description, escuela.fk_faculty));
            }
            catch (DatabaseException)
            {
                return StatusCode(500);
            }

        }

        //PUT api/schools
        [HttpPut]
        public ActionResult<SchoolUpdateDTO> SchoolUpdate(SchoolUpdateDTO escu)
        {
            try
            {
                return Ok(SqlSchoolsRepository.SchoolUpdate(escu.id, escu.name, escu.description, escu.fk_faculty));
            }
            catch (DatabaseException)
            {
                return StatusCode(500);
            }
        }

        //PUT api/schools
        [HttpDelete]
        public ActionResult<SchoolCreateDTO> SchoolDelete(SchoolUpdateDTO escu)
        {
            try
            {
                return Ok(SqlSchoolsRepository.SchoolDelete(escu.id));
            }
            catch (DatabaseException)
            {
                return StatusCode(500);
            }

        }

    }
}