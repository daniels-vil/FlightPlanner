using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using FlightPlanner.Core.Models;

namespace Flight_planner.Models
{
    public class FlightRequest
    {
        public int Id { get; set; }
        [Required]
        public AirportRequest From { get; set; }
        [Required]
        public AirportRequest To { get; set; }
        [Required]
        public string Carrier { get; set; }
        [Required]
        public string DepartureTime { get; set; }
        [Required]
        public string ArrivalTime { get; set; }
    }
}