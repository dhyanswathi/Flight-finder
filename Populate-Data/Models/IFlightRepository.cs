using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Populate_Data.Models
{
    public interface IFlightRepository
    {
        void Save();
        void CreateFlightRoute(string routeId, string depDestination, string arrDestination);
        void CreateItinerary(string flightId, DateTime departure, DateTime arrival, int seats, string routeId);
        void CreatePrices(string currency, double adult, double child, string flightId);
    }
}
