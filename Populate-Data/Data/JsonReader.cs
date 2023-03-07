using Newtonsoft.Json;
using Populate_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Populate_Data.Data
{
   public class JsonReader
    {
        public class RouteResults
        {
            public List<FlightRoutes> Results { get; set; }
        }

        //Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public static List<FlightRoutes> GetFlightData(string path)
        {
            var json = File.ReadAllText(path);
            var jsonFileFormat = JsonConvert.DeserializeObject<RouteResults>(json);
            return jsonFileFormat.Results;
        }
    }
}
