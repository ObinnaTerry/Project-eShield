using eShield_API.DataService;
using eShield_API.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eShield_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NetworkInfoController : ControllerBase
    {
        private readonly NetworkInfoDataService _networkInfoDataService;

        public NetworkInfoController(NetworkInfoDataService networkInfoDataService)
        {
            _networkInfoDataService = networkInfoDataService;
        }

        // POST api/<NetworkInfoController>
        [HttpPost]
        public IActionResult Post([FromBody] NetworkInfoDTO networkInfoDTO)
        {
            bool? result = _networkInfoDataService.Create(networkInfoDTO);

            if(result == null)
            {
                return BadRequest(400);
            }

            return Ok();
        }

    }
}
