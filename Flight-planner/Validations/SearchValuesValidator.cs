using Flight_planner.Models;
using FlightPlanner.Core.Interfaces;

namespace Flight_planner.Validations
{
    public class SearchValuesValidator : ISearchValidate
    {
        public bool IsValid(Search search)
        {
            return search != null &&
                   !string.IsNullOrEmpty(search.To) &&
                   !string.IsNullOrEmpty(search.From) &&
                   !string.IsNullOrEmpty(search.DepartureDate);
        }
    }
}