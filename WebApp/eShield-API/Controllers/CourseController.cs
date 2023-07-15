using eShield_API.DataService;
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


        // GET api/<CourseController>/5
        [HttpGet("{profid}")]
        public IActionResult Get(int profid)
        {
            var courseDTO = _courseDataService.ReadByProfId(profid);

            if (courseDTO == null)
            {
                return NotFound();
            }

            return Ok(courseDTO);
        }

    }
}