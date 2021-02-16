using Core3RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3RestAPI.Data
{
    public interface ICommanderRepo
    {
        bool SaveChanges();

        IEnumerable<Command> GetAppCommands();
        IEnumerable<Command> GetCommandById(int id);
        int CreateCommand(Command command);
    }
}
