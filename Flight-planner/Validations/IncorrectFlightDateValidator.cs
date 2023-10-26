using FlightPlanner.Core.Interfaces;
using FlightPlanner.Core.Models;

namespace Flight_planner.Validations
{
    public class IncorrectFlightDateValidator : IValidate
    {
        public bool IsValid(Flight flight)
        {
            if (!DateTime.TryParse(flight.DepartureTime, out var departureTime) ||
                !DateTime.TryParse(flight.ArrivalTime, out var arrivalTime))
                return false;

            return arrivalTime > departureTime;
        }
    }
}