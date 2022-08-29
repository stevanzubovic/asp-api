using Application;
using Application.Commands.Reviews;
using Application.DTOs.Reviews;
using Application.Queries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly UseCaseExecutor executor;
        private readonly IApplicationActor actor;

        public ReviewController(UseCaseExecutor executor, IApplicationActor actor)
        {
            this.executor = executor;
            this.actor = actor;
        }

        // GET: api/<ReviewController>
        [HttpGet]
        public IActionResult Get([FromQuery] ReviewSearchDTO dto, [FromServices] IGetReviewsQuery query)
        {
            return Ok(executor.ExecuteQuery(query, dto));
        }

        // GET api/<ReviewController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneReviewQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST api/<ReviewController>
        [HttpPost]
        public IActionResult Post([FromBody] ReviewDTO dto, [FromServices] ICreateReviewCommand command)
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<ReviewController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ReviewUpdateDTO reviewDTO, [FromServices] IUpdateReviewCommand command)
        {
            reviewDTO.Id = id;
            executor.ExecuteCommand(command, reviewDTO);
            return NoContent();
        }

        // DELETE api/<ReviewController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteReviewCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
