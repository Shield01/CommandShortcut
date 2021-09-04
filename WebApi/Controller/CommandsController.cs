using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data_Acces_Layer.Abstractions;
using WebApi.DTOs;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepository _commandRepo;

        private readonly IMapper _mapper;
        public CommandsController(ICommandRepository commandRepository, IMapper mapper)
        {
            _commandRepo = commandRepository;

            _mapper = mapper;
        }
        // GET: api/<CommandsController>
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDTO>> GetAllCommands()
        {
            var result = _commandRepo.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDTO>>(result));
        }

        // GET api/<CommandsController>/5
        [HttpGet("{id}", Name = "GetCommand")]
    
        public ActionResult<CommandReadDTO> GetCommand(int id)
        {
            var result = _commandRepo.GetCommand(id);

            if(result != null)
            {
                return Ok(_mapper.Map<CommandReadDTO>(result));
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/<CommandsController>
        [HttpPost]
        public ActionResult<CommandReadDTO> CreateCommand(CommandCreateDTO createdCommand)
        {
            var result = _mapper.Map<Command>(createdCommand);

            _commandRepo.AddCommand(result);

            var createdCommandDTO = _mapper.Map<CommandReadDTO>(result);

            return CreatedAtRoute(nameof(GetCommand), new { Id = createdCommand.Id }, createdCommandDTO);
        }

        // PUT api/<CommandsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CommandUpdateDTO updatedCommand)
        {
           var result = _commandRepo.GetCommand(id);

            if(result == null)
            {
               
            }
            else
            {
                 _mapper.Map(updatedCommand, result);
                _commandRepo.UpdateCommand(result);
            }
           
        }

        //PATCH api/<commandscontroller>{id}
        [HttpPatch("{id}")]
        public ActionResult Patch(int id, JsonPatchDocument<CommandUpdateDTO> patchDoc)
        {
            var result = _commandRepo.GetCommand(id);

            if (result == null)
            {

            }
            else
            {
                var commandToPatch = _mapper.Map<CommandUpdateDTO>(result);

                patchDoc.ApplyTo(commandToPatch, ModelState);

                if (!TryValidateModel(commandToPatch))
                {
                    return ValidationProblem(ModelState);
                }

                _mapper.Map(commandToPatch, result);

                _commandRepo.UpdateCommand(result);

                

                //if (!TryValidateModel(commandToPatch))
                //{
                //    return ValidationProblem(ModelState);
                //}
            }

            return NoContent();

        }

        // DELETE api/<CommandsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _commandRepo.DeleteCommand(id);
        }
    }
}
