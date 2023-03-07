using Populate_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Populate_Data.DTO
{
    public class FlightRoute
    {
        public string route_id { get; set; }
        public string departureDestination { get; set; }
        public string arrivalDestination { get; set; }
        public List<Itinerary> itineraries { get; set; }
    }
}
