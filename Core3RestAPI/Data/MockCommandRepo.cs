using Core3RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3RestAPI.Data
{
    public class MockCommandRepo : ICommanderRepo
    {
        public void DeleteCommand(Command command)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAppCommands()
        {
            var commands = new List<Command>
            {
                new Command { Id = 0, HowTo = "Cozinhar um ovo", Line = "Ferver agua", Platform = "Panela" },
                new Command { Id = 1, HowTo = "Cozinhar uma batata", Line = "Ferver agua", Platform = "Panela" },
                new Command { Id = 2, HowTo = "Cozinhar uma cenoura", Line = "Ferver agua", Platform = "Panela" }
            };
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, HowTo = "Cozinhar um ovo", Line = "Ferver agua", Platform = "Panela" };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command command)
        {
            throw new NotImplementedException();
        }

        int ICommanderRepo.CreateCommand(Command command)
        {
            throw new NotImplementedException();
        }
    }
}

