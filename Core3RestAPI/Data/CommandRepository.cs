using Core3RestAPI.Models;
using System;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Core3RestAPI.Data
{
    public class CommandRepository : ICommanderRepo
    {
        // Interface para acessar as configurações
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public CommandRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
       
        public int CreateCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            // ou utilizar OUTPUT inserted.id
            string sql = "INSERT INTO Command (HowTo, Line, Platform) VALUES (@HowTo, @Line, @Platform);" +
                "SELECT last_insert_rowid();";

            using (var connection = new SQLiteConnection(_connectionString))
            {
                // retorna linhas afetadas.
                //connection.Execute(sql, command);   
                var id = connection.Query<int>(sql, command).Single();
                return id;
            }
        }

        public IEnumerable<Command> GetAppCommands()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                return connection.Query<Command>("SELECT * FROM Command");
            }
        }

        public IEnumerable<Command> GetCommandById(int id)
        {
            // Sintaxe using c# 8
            using var connection = new SQLiteConnection(_connectionString);
            return connection.Query<Command>("SELECT * FROM Command WHERE id=@Id", new { Id = id });
            // Ou converter IEnumerable para objeto Command
        }

        public bool SaveChanges()
        {
            // método de commit para entity framework
            throw new NotImplementedException();
        }
    }
}
