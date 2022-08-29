using Application;
using Application.Commands.Books;
using Application.DTOs;
using Application.Queries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly UseCaseExecutor executor;
        private readonly IApplicationActor actor;

        public BookController(UseCaseExecutor executor, IApplicationActor actor)
        {
            this.executor = executor;
            this.actor = actor;
        }

        // GET: api/<BookController>
        [HttpGet]
        public IActionResult Get([FromQuery] BookSearchDTO searchParams, [FromServices] IGetBooksQuery query)
        {
            return Ok(executor.ExecuteQuery(query, searchParams));
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneBookQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST api/<BookController>
        [HttpPost]
        public IActionResult Post([FromBody] BookDTO book, [FromServices] ICreateBookCommand command)
        {
            executor.ExecuteCommand(command, book);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BookDTO book, [FromServices] IUpdateBookCommand command)
        {
            book.Id = id;
            executor.ExecuteCommand(command, book);
            return NoContent();
        } 

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteBookCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
