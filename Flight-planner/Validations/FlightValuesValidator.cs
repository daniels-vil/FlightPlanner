using FlightPlanner.Core.Interfaces;
using FlightPlanner.Core.Models;

namespace Flight_planner.Validations
{
    public class FlightValuesValidator : IValidate
    {
        public bool IsValid(Flight flight)
        {
            return !string.IsNullOrEmpty(flight?.ArrivalTime) &&
                   !string.IsNullOrEmpty(flight?.DepartureTime) &&
                   !string.IsNullOrWhiteSpace(flight?.Carrier) &&
                   flight?.To != null &&
                   flight?.From != null;
        }
    }
}