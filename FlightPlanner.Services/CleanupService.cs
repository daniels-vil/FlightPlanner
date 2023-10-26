using FlightPlanner.Core.Services;
using FlightPlanner.Data;

namespace FlightPlanner.Services
{
    public class CleanupService : DbService, ICleanupService
    {
        public CleanupService(IFlightPlannerDbContext dbContext) : base(dbContext)
        {
        }

        public void CleanDatabase()
        {
            _dbContext.Airports.RemoveRange(_dbContext.Airports);
            _dbContext.Flights.RemoveRange(_dbContext.Flights);
            _dbContext.SaveChanges();
        }
    }
}
