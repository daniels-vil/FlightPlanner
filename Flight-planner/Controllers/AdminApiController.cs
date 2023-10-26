using AutoMapper;
using Flight_planner.Models;
using Flight_planner.Validations;
using FlightPlanner.Core.Interfaces;
using FlightPlanner.Core.Models;
using FlightPlanner.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flight_planner.Controllers
{
    [Authorize]
    [Route("admin-api")]
    [ApiController]
    public class AdminApiController : ControllerBase
    {
        private readonly IFlightService _flightService;
        private readonly IMapper _mapper;
        private readonly object _lock = new object();
        private readonly IEnumerable<IValidate> _validators;

        public AdminApiController(
            IFlightService flightService,
            IMapper mapper,
            IEnumerable<IValidate> validators)
        {
            _flightService = flightService;
            _mapper = mapper;
            _validators = validators;
        }

        [Route("flights/{id}")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(FlightRequest))]
        [ProducesResponseType(404)]
        public IActionResult GetFlight(int id)
        {
            Flight flight = _flightService.GetFullFlightById(id);
            if(flight == null)
                return NotFound($"Flight {id} does not exist");

            return Ok(_mapper.Map<FlightRequest>(flight));
        }

        [Route("flights")]
        [HttpPut]
        [ProducesResponseType(201)]
        public IActionResult PutFlight(FlightRequest request)
        {
            lock (_lock)
            {
                var flight = _mapper.Map<Flight>(request);
                    if (!_validators.All(v => v.IsValid(flight)))
                    {
                        return BadRequest();
                    }

                    if (_flightService.Exists(flight))
                    {
                        return Conflict();
                    }

            
                _flightService.Create(flight);

                request = _mapper.Map<FlightRequest>(flight);

                return Created("", request);
            }
        }

        [Route("flights/{id}")]
        [HttpDelete]
        [ProducesResponseType(200)]
        public IActionResult DeleteFlight(int id)
        {
            lock (_lock)
            {
                Flight? flightToRemove = _flightService.GetById(id);
                if (flightToRemove == null) return Ok();
                _flightService.Delete(flightToRemove);

                return Ok();
            }
        }
    }
} 