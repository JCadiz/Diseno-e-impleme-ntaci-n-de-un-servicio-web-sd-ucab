using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;
using DistribuidosApi.Exceptions;
using DistribuidosApi.Models.Persons;
using DistribuidosApi.Data.Repository.Persons;
using DistribuidosApi.LogicLayer.DTO.Persons;

namespace DistribuidosApi.Controllers.Persons
{

    [Route("api/persons")]
    [ApiController]
    public class PersonsController : ControllerBase
    {

        private readonly IMapper _mapper;

        public PersonsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        //GET api/persons
        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAllPersons()
        {
            try
            {

                return Ok(SqlPersonsRepository.GetAllPersons());
            }
            catch (DatabaseException)
            {
                return StatusCode(500);
            }
        }

        //POST api/persons
        [HttpPost]
        public ActionResult<PersonCreateDTO> PersonRegister(PersonCreateDTO facu)
        {
            try
            {
                //var facultyModel = _mapper.Map<Faculty>(facu);

                return Ok(SqlPersonsRepository.PersonRegister(facu.dni, facu.first_name, facu.last_name));
            }
            catch (DatabaseException)
            {
                return StatusCode(500);
            }

        }

        //PUT api/persons
        [HttpPut]
        public ActionResult<PersonUpdateDTO> PersonUpdate(PersonUpdateDTO facu)
        {
            try
            {
                return Ok(SqlPersonsRepository.PersonUpdate(facu.id, facu.dni, facu.first_name, facu.last_name));
            }
            catch (DatabaseException)
            {
                return StatusCode(500);
            }

        }

        //PUT api/persons
        [HttpDelete]
        public ActionResult<PersonCreateDTO> PersonDelete(PersonUpdateDTO facu)
        {
            try
            {
                return Ok(SqlPersonsRepository.PersonDelete(facu.id));
            }
            catch (DatabaseException)
            {
                return StatusCode(500);
            }

        }


    }
}