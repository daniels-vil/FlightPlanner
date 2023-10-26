using FlightPlanner.Core.Models;

namespace Flight_planner.Models
{
    public class PageResult
    {
        public int page { get; set; }
        public int totalItems { get; set; }
        public List<Flight> items { get; set; }

        public PageResult()
        {
            items = new List<Flight>();
            page = 0;
            totalItems = 0;
        }
    }
}