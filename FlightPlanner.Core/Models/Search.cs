using System.ComponentModel.DataAnnotations;

namespace Flight_planner.Models
{
    public class Search
    {
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        [Required]
        public string DepartureDate { get; set; }
    }
}