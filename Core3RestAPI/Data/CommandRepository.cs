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

        public void DeleteCommand(Command command)
        {
            string sql = "DELETE FROM Command WHERE id=@Id";

            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Execute(sql, command);
            }
        }

        public IEnumerable<Command> GetAppCommands()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                return connection.Query<Command>("SELECT * FROM Command");
            }
        }

        public Command GetCommandById(int id)
        {
            // Sintaxe using c# 8
            using var connection = new SQLiteConnection(_connectionString);
            string sql = "SELECT * FROM Command WHERE id=@Id";

            try
            {
                return connection.Query<Command>(sql, new { Id = id }).First();
            }
            catch (Exception)
            {
                return null;
            }
            
            // Ou converter IEnumerable para objeto Command
        }

        public bool SaveChanges()
        {
            // método de commit para entity framework
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command command)
        {
            string sql = "UPDATE command SET HowTo=@HowTo, Line=@Line, Platform=@Platform WHERE id=@Id";
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Execute(sql, command);
            }
        }
    }
}
