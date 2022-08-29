using Application;
using Application.Commands.Users;
using Application.DTOs;
using Application.Queries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UseCaseExecutor executor;
        private readonly IApplicationActor actor;

        public UserController(UseCaseExecutor executor, IApplicationActor actor)
        {
            this.executor = executor;
            this.actor = actor;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get([FromQuery] UserSearchDTO searchParams, [FromServices] IGetUsersQuery query)
        {
            return Ok(executor.ExecuteQuery(query, searchParams));
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneUserQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));

        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] UserDTO userDto, [FromServices] ICreateUserCommand command)
        {
            executor.ExecuteCommand(command, userDto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserDTO dto, [FromServices] IUpdateUserCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUserCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
