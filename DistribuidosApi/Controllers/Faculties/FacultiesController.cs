using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;
using DistribuidosApi.Exceptions;
using DistribuidosApi.LogicLayer.DTO.Faculties;
using DistribuidosApi.Models.Faculties;
using DistribuidosApi.Data.Repository.Faculties;

namespace DistribuidosApi.Controllers.Faculties
{

    [Route("api/faculties")]
    [ApiController]
    public class FacultiesController : ControllerBase
    {

        private readonly IMapper _mapper;

        public FacultiesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        //GET api/faculties
        [HttpGet]
        public ActionResult<IEnumerable<Faculty>> GetAllFaculties()
        {
            try
            {
                
                return Ok(SqlFacultiesRepository.GetAllFaculties());
            }
            catch (DatabaseException)
            {
                return StatusCode(500);
            }
        }

        //POST api/faculties
        [HttpPost]
        public ActionResult<FacultyCreateDTO> FacultyRegister(FacultyCreateDTO facu )
        {
            try
            {
                //var facultyModel = _mapper.Map<Faculty>(facu);
                
                return Ok(SqlFacultiesRepository.FacultyRegister(facu.name, facu.description));
            }
            catch (DatabaseException)
            {
                return StatusCode(500);
            }

        }

        /*
        //PUT api/faculties/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateFaculty(int id, FacultyUpdateDTO facultyUpdateDTO)
        {
            try
            {
                var facultyModelFromRepo = _repo.GetFacultyById(id);
                if (facultyModelFromRepo == null)
                {
                    return NotFound();
                }

                _mapper.Map(facultyUpdateDTO, facultyModelFromRepo);

                _repo.UpdateFaculty(facultyModelFromRepo);

                _repo.SaveChanges();

                return NoContent();
            }
            catch (DatabaseException)
            {
                return StatusCode(500);
            }
        }

        //DELETE api/faculties/{id}
        [HttpDelete("{id}")]
        public ActionResult FacultyDelete(int id)
        {
            try
            {
                var facultyModelFromRepo = _repo.GetFacultyById(id);
                if (facultyModelFromRepo == null)
                {
                    return NotFound();
                }

                _repo.DeleteFaculty(facultyModelFromRepo);
                _repo.SaveChanges();

                return NoContent();
            }
            catch (DatabaseException)
            {
                return StatusCode(500);
            }

        } */


    }
}