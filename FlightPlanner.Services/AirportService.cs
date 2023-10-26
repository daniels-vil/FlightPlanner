using FlightPlanner.Core.Models;
using FlightPlanner.Core.Services;
using FlightPlanner.Data;

namespace FlightPlanner.Services
{
    public class AirportService : EntityService<Airport>, IAirportService
    {
        public AirportService(IFlightPlannerDbContext dbContext) : base(dbContext)
        {
        }

        public Airport SearchAirports(string phrase)
        {
            phrase = phrase.ToLower().Trim();

            foreach (Airport a in _dbContext.Airports)
            {
                if (a.Country.ToLower().Trim().Contains(phrase) ||
                    a.City.ToLower().Trim().Contains(phrase) ||
                    a.AirportCode.ToLower().Trim().Contains(phrase))
                {
                    Airport airport = a;

                    return airport;
                }
            }
            return null;
        }
    }
}
