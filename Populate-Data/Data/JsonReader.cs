using Newtonsoft.Json;
using Populate_Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Populate_Data.Data
{
    public class RouteResults
    {
        public List<FlightRoute>? FlightRoutes { get; set; }
    }
    public class JsonReader
    {
        //Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public static List<FlightRoute> GetFlightData(string path)
        {
            var json = File.ReadAllText(path);
            var jsonFileFormat = JsonConvert.DeserializeObject<RouteResults>(json);
            return jsonFileFormat.FlightRoutes;
        }
    }
}
