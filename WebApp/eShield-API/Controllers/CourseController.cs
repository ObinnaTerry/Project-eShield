using eShield_API.DataService;
using eShield_API.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eShield_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase

    {
        private readonly CourseDataService _courseDataService;
        public CourseController(CourseDataService courseDataService)
        {
            _courseDataService = courseDataService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_courseDataService.ReadAll());
        }


        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var courseDTO = _courseDataService.ReadId(id);

            if (courseDTO == null)
            {
                return NotFound();
            }

            return Ok(courseDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CourseDTO courseDTO)
        {
            _courseDataService.Update(id, courseDTO);

            return Ok();
        }

        // DELETE api/<ExamController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _courseDataService.Delete(id);

            return Ok();
        }

    }
}