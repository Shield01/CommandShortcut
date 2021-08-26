using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Data_Acces_Layer.Abstractions
{
    public interface ICommandRepository
    {
        IEnumerable<Command> GetAllCommands();

        Command GetCommand(int id);

        Command AddCommand(Command newCommand);
        Command UpdateCommand(Command updatedCommand);
        Command DeleteCommand(int id);
    }
}
