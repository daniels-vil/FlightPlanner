using Flight_planner.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FlightPlanner.Core.Interfaces;
using FlightPlanner.Core.Models;
using FlightPlanner.Core.Services;

namespace Flight_planner.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomerApiController : ControllerBase
    {
        private readonly IFlightService _flightService;
        private readonly IAirportService _airportService;
        private readonly IMapper _mapper;
        private readonly IEnumerable<ISearchValidate> _validators;
        private readonly object _lock = new object();
        
        public CustomerApiController(
            IFlightService flightService,
            IAirportService airportService,
            IMapper mapper,
            IEnumerable<ISearchValidate> validators)
        {
            _flightService = flightService;
            _airportService = airportService;
            _mapper = mapper;
            _validators = validators;
        }

        [Route("airports")]
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult SearchAirports(string search)
        {
            Airport airport = _airportService.SearchAirports(search);
            if (airport == null) return NotFound();

            var request = _mapper.Map<AirportRequest>(airport);

            return Ok(new []{request});
        }

        [Route("flights/{id}")]
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult FindFlightById(int id)
        {
            lock (_lock)
            {
                var flight = _flightService.GetFullFlightById(id);
                if (flight != null) return Ok(_mapper.Map<FlightRequest>(flight));

                return NotFound();
            }
        }

        [Route("flights/search")]
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult SearchFlights(Search search)
        {
            if (!_validators.All(v => v.IsValid(search))) return BadRequest();

            var searchResult = _flightService.SearchFlights(search);

            return Ok(searchResult);
        }
    }
}