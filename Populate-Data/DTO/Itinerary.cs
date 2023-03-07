using Populate_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Populate_Data.DTO
{
    public class Itinerary
    {
        public string flight_id { get; set; }
        public DateTime departureAt { get; set; }
        public DateTime arrivalAt { get; set; }
        public int availableSeats { get; set; }
        public Prices prices { get; set; }
    }
}
