using Flight_planner.Models;
using FlightPlanner.Core.Models;
using FlightPlanner.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flight_planner.Controllers
{
    [Route("testing-api")]
    [ApiController]
    public class CleanupApiController : ControllerBase
    {
        private readonly ICleanupService _cleanupService;
        
        public CleanupApiController(ICleanupService cleanupService)
        {
            _cleanupService = cleanupService;
        }

        [Route("clear")]
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult Clear()
        {
            _cleanupService.CleanDatabase();
            return Ok("Flight storage cleared");
        }
    }
}