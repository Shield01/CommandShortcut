using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data_Acces_Layer.Abstractions;
using WebApi.Models;

namespace WebApi.Data_Acces_Layer.Concrete_Implementations
{
    public class CommandRepository : ICommandRepository
    {
        private readonly ApplicationDbContext _db;
        public CommandRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Command AddCommand(Command newCommand)
        {
            _db.Add(newCommand);
            _db.SaveChanges();
            return newCommand;
        }

        public Command DeleteCommand(int id)
        {
            var result = _db.Commands.FirstOrDefault(x => x.Id == id);
            _db.Remove(result);
            _db.SaveChanges();
            return null;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _db.Commands;
        }

        public Command GetCommand(int id)
        {
            var result = _db.Commands.FirstOrDefault(x => x.Id == id);
            return result;

        }

        public Command UpdateCommand(Command updatedCommand)
        {
            var result = _db.Commands.FirstOrDefault(x => x.Id == updatedCommand.Id);
            result.Id = updatedCommand.Id;
            result.HowTo = updatedCommand.HowTo;
            result.Line = updatedCommand.Line;
            result.Platform = updatedCommand.Platform;
            _db.SaveChanges();
            return result;
        }
    }
}
