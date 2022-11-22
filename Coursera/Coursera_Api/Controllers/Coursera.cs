using Coursera_Service.Interfaces;
using Coursera_ViewModel.Responses;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Coursera_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Coursera : ControllerBase
    {
        private readonly ICourseraService _coursera;

        public Coursera(ICourseraService coursera)
        {
            _coursera = coursera;
        }
        // GET: api/<Coursera>
        [HttpGet]
        public async Task<List<CourseraResponse>> Get()
        {
            var response = await _coursera.ReturnReport(0, new DateOnly(), new DateOnly(), "test", "");
            return response;
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
