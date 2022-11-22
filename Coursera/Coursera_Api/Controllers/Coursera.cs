using Coursera_Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Coursera_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Coursera : ControllerBase
    {
        private readonly CourseraContext _dbContext;

        public Coursera(CourseraContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/<Coursera>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Coursera>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Coursera>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Coursera>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Coursera>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
