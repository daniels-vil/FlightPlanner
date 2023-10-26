using Flight_planner.Models;
using FlightPlanner.Core.Models;
using FlightPlanner.Core.Services;
using FlightPlanner.Data;
using Microsoft.EntityFrameworkCore;

namespace FlightPlanner.Services
{
    public class FlightService : EntityService<Flight>, IFlightService
    {
        private readonly object _lock = new object();
        public FlightService(IFlightPlannerDbContext dbContext) : base(dbContext)
        {
        }

        public Flight? GetFullFlightById(int id)
        {
            return _dbContext.Flights
                .Include(f => f.To)
                .Include(f => f.From)
                .SingleOrDefault(f => f.Id.Equals(id));
        }

        public bool Exists(Flight flight)
        {
            lock (_lock)
            {
                return _dbContext.Flights.Any(f => f.ArrivalTime == flight.ArrivalTime
                                                 && f.DepartureTime == flight.DepartureTime
                                                 && f.Carrier == flight.Carrier
                                                 && f.From.AirportCode == flight.From.AirportCode
                                                 && f.To.AirportCode == flight.To.AirportCode); 
            }
        }

        public PageResult? SearchFlights(Search search)
        {
            if (search.To == search.From)
            {
                return null;
            }

            var result = new PageResult();
            foreach (var flight in _dbContext.Flights.Include(
                         flight => flight.To).Include(
                         flight => flight.From))
            {
                var dateFromFlight = DateTime.Parse(flight.DepartureTime);
                var dateFromSearch = DateTime.Parse(search.DepartureDate);

                if (flight.To.AirportCode == search.To
                    && flight.From.AirportCode == search.From
                    && dateFromFlight.Date == dateFromSearch.Date)
                {
                    result.totalItems++;
                    result.items.Add(flight);
                    if (result.totalItems > 9)
                    {
                        result.page++;
                    }
                }
            }

            return result;
        }
    }
}
