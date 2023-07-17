using eShield_API.DataService;
using eShield_API.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eShield_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProxyController : ControllerBase
    {
        private readonly ProxyDataService _proxyDataService;

        public ProxyController(ProxyDataService proxyDataService)
        {
            _proxyDataService = proxyDataService;
        }

        // GET: api/<ProxyController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new string[] { "value1", "value2" });
        }

        // GET api/<ProxyController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_proxyDataService.Get(id));
        }

        // POST api/<ProxyController>
        [HttpPost]
        public IActionResult Post([FromBody] VisitedSiteDTO visitedSite)
        {
            _proxyDataService.Post(visitedSite, IpAddress());

            return Ok();
        }

        private string? IpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}
