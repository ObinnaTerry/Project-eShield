using eShield_API.DataService;
using eShield_API.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eShield_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly ProfessorDataService _professorDataService;

        public ProfessorController(ProfessorDataService professorDataService)
        {
            _professorDataService = professorDataService;
        }

        // GET: api/<ProfessorController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_professorDataService.ReadAll());
        }

        // GET api/<ProfessorController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ProfessorDTOOut? professorDTOOut = await _professorDataService.ReadByIdAync(id);

            if (professorDTOOut == null)
            {
                return NotFound();
            }

            return Ok(professorDTOOut);
        }

        // POST api/<ProfessorController>
        [HttpPost]
        public IActionResult Post([FromBody] ProfessorDTOIn professorDTOIn)
        {
            ProfessorDTOOut professorDTOOut = _professorDataService.Create(professorDTOIn);

            return Ok(professorDTOOut);
        }

        // PUT api/<ProfessorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProfessorDTOIn professorDTOIn)
        {
            _professorDataService.Update(id, professorDTOIn);

            return Ok();
        }

        // DELETE api/<ProfessorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _professorDataService.Delete(id);
        }
    }
}
