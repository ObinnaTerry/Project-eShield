using eShield_API.DataService;
using eShield_API.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eShield_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly ExamDataService _examDataService;

        public ExamController(ExamDataService examDataService)
        {
            _examDataService = examDataService;
        }

        // GET: api/<ExamController>
        //[HttpGet]
        //public IActionResult Get(int id)
        //{
        //    return Ok(_examDataService.ReadAll(id));
        //}

        // GET api/<ExamController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _examDataService.ReadById(id));
        }

        // POST api/<ExamController>
        [HttpPost]
        public IActionResult Post([FromBody] ExamDTO examDTO)
        {
            return Ok(_examDataService.Create(examDTO));
        }

        // PUT api/<ExamController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ExamDTO examDTO)
        {
            return Ok(_examDataService.Update(id, examDTO));
        }

        // DELETE api/<ExamController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _examDataService.Delete(id);

            return Ok();
        }
    }
}
