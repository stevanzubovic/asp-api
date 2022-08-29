using Application;
using Application.DTOs;
using Application.Queries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly UseCaseExecutor executor;

        public LogController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/<LogController>
        [HttpGet]
        public IActionResult Get([FromQuery] LogSearchDTO search, [FromServices] IGetLogsQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search)); 
           
        }

        // GET api/<LogController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
