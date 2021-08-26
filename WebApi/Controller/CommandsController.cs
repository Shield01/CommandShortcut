using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data_Acces_Layer.Abstractions;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepository _commandRepo;
        public CommandsController(ICommandRepository commandRepository)
        {
            _commandRepo = commandRepository;
        }
        // GET: api/<CommandsController>
        [HttpGet]
        public IEnumerable<Command> Get()
        {
            return _commandRepo.GetAllCommands();
        }

        // GET api/<CommandsController>/5
        [HttpGet("{id}")]
        public Command Get(int id)
        {
            return _commandRepo.GetCommand(id);
        }

        // POST api/<CommandsController>
        [HttpPost]
        public void Post([FromBody] Command newCommand)
        {
            _commandRepo.AddCommand(newCommand);
        }

        // PUT api/<CommandsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Command updatedCommand)
        {
            _commandRepo.UpdateCommand(updatedCommand);
        }

        // DELETE api/<CommandsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _commandRepo.DeleteCommand(id);
        }
    }
}
