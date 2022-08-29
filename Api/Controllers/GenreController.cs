using Application;
using Application.Commands.Genres;
using Application.DTOs;
using Application.Queries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {

        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

        public GenreController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }

        // GET: api/<GenreController>
        [HttpGet]
        public IActionResult Get([FromQuery] string searchTerm, [FromServices] IGetGenresQuery query)
        {
            return Ok(executor.ExecuteQuery(query, searchTerm));
        }

        // GET api/<GenreController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneGenreQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST api/<GenreController>
        [HttpPost]
        public IActionResult Post([FromBody] GenreDTO genre, [FromServices] ICreateGenreCommand command)
        {
            executor.ExecuteCommand(command, genre);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<GenreController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] GenreDTO genre, [FromServices] IUpdateGenreCommand command)
        {
            genre.Id = id;
            executor.ExecuteCommand(command, genre);
            return NoContent();
        }

        // DELETE api/<GenreController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteGenreCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
