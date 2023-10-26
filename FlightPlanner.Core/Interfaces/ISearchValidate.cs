using Flight_planner.Models;

namespace FlightPlanner.Core.Interfaces
{
    public interface ISearchValidate
    {
        bool IsValid(Search search);
    }
}