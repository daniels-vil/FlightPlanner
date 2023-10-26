using FlightPlanner.Core.Interfaces;
using FlightPlanner.Core.Models;

namespace Flight_planner.Validations
{
    public class SameAirportValidator : IValidate
    {
        public bool IsValid(Flight flight)
        {
            return flight?.To?.AirportCode?.Trim()?.ToLower() !=
                   flight?.From?.AirportCode?.Trim()?.ToLower();
        }
    }
}