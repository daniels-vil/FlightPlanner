using System.Text.Json.Serialization;

namespace Flight_planner.Models
{
    public class AirportRequest
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Airport { get; set; }
    }
}