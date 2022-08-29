using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Application.Exceptions;
using Application;
using Application.Queries;
using Application.Commands.Authors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly UseCaseExecutor executor;
        private readonly IApplicationActor actor;

        public AuthorController(UseCaseExecutor executor, IApplicationActor actor)
        {
            this.executor = executor;
            this.actor = actor;
        }

        // GET: api/<AuthorController>
        [HttpGet]
        public IActionResult Get(string searchTerm, [FromServices] IGetAuthorsQuery query)
        {
            return Ok(executor.ExecuteQuery(query, searchTerm));
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneAuthorQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST api/<AuthorController>
        [HttpPost]
        public IActionResult Post([FromBody] AuthorDTO author, [FromServices] ICreateAuthorCommand command)
        {
            executor.ExecuteCommand(command, author);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AuthorDTO author, [FromServices] IUpdateAuthorCommand command)
        {
            author.Id = id;
            executor.ExecuteCommand(command, author);
            return NoContent();
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteAuthorCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
