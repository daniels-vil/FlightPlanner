using Flight_planner.Models;
using FlightPlanner.Core.Interfaces;

namespace Flight_planner.Validations
{
    public class SearchAirportsValidator : ISearchValidate
    {
        public bool IsValid(Search search)
        {
            return search?.From?.ToLower().Trim() != search?.To?.ToLower().Trim();
        }
    }
}