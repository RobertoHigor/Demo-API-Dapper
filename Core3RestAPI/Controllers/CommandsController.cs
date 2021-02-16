using AutoMapper;
using Core3RestAPI.Data;
using Core3RestAPI.Dtos;
using Core3RestAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Core3RestAPI.Controllers
{
    /*
     * Por ser uma API, o controller herda de ControllerBase.
     * Seguindo as recomendações de RESTful, o nome é do recurso no plural
     */
    [Route("api/[controller]")]
    [ApiController] // Provém algumas funcionalidades para o controller
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper; // AutoMapper do DTO
        }        
        
        // GET: api/<Commands>
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAppCommands();
            return Ok(commandItems);
            /* Falhas:
             * 400 Bad Request
             * 404 Not Found
             */
        }

        // GET api/<Commands>/5
        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult<CommandReadDTO> GetCommandById(int id)
        {
            Command commandItem = _repository.GetCommandById(id);
            if (commandItem != null)
            {
                //return Ok(_mapper.Map<IEnumerable<CommandReadDTO>>(commandItem));
                return Ok(_mapper.Map<CommandReadDTO>(commandItem));
            }
            return NotFound();
            

            /* Falhas:
             * 400 Bad Request
             * 404 Not Found
             */
        }

        // POST api/<Commands>
        [HttpPost]
        public ActionResult<CommandReadDTO> CreateCommand([FromBody] CommandCreateDTO commandCreateDTO)
        {
            // Convertando DTO para Entidade
            var commandModel = _mapper.Map<Command>(commandCreateDTO);
            try
            {
                int idCommandCriado = _repository.CreateCommand(commandModel);

                // Convertendo entidade para DTO
                var commandReadDTO = _mapper.Map<CommandReadDTO>(commandModel);
                commandReadDTO.Id = idCommandCriado;

                // Retornar 201 com a rota do recurso
                // Nesse caso, está utilizando o método get para retornar o objeto
                // criado (usando o id) junto com a rota       
                return CreatedAtRoute(
                    routeName: nameof(GetCommandById),
                    routeValues: new {id = commandReadDTO.Id },
                    value: commandReadDTO);
                // return CreatedAtRoute(nameof(GetCommandVyID), new {id = commandReadDTO.Id}, commandReadDTO); // jeito resumido
            }
            catch (Exception ex)
            {
                throw;
            }

            // Sucesso: 201 Created

            /* Falhas:
             * 400 Bad Request
             * 405 Not Allowed
             */
        }

        // PUT api/<Commands>/5
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, [FromBody] CommandUpdateDTO commandUpdateDTO)
        {
            Command commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            
            // commandModel e commandUpdate ambos possuem dados
            // map Update -> Model
            _mapper.Map(commandUpdateDTO, commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);

            return NoContent();
            

            // Sucesso: 204 No Content
        }

        // DELETE api/<Commands>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // Sucesso: 200 Ok
            // Falha: 204 No Content
        }
    }
}
