// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Populate_Data.Data;
using Populate_Data.Models;

IHost host = Host.CreateDefaultBuilder(args)
.ConfigureServices((context, services) =>
{
    var cns = "Data Source=LAPTOP-AC42D6SP\\MSSQLSERVER01;Initial Catalog=FlightFinderDB;Integrated Security=True;encrypt=false";
    services.AddDbContext<FlightFinderDBContext>(options => options.UseSqlServer(cns));
    services.AddTransient<FlightRepository>();
})
.Build();

var path = "C:\\Users\\Mintu\\swathistudy\\pgp\\codeTest\\Flight-finder\\Populate-Data\\Data\\Flights.json";

var items = JsonReader.GetFlightData(path);

var flightRepository = host.Services.GetRequiredService<FlightRepository>();
//items.ForEach(x => flightRepository.Create(x.route_id, x.departureDestination, x.arrivalDestination));
foreach (var item in items)
{
    FlightRoutes flightRoutes = new FlightRoutes();
    flightRoutes.RouteId = item.route_id;
    flightRoutes.DepartureDestination = item.departureDestination;
    flightRoutes.ArrivalDestination = item.arrivalDestination;

    List<Itineraries> itineraries = new List<Itineraries>();
    foreach (var itenary in item.itineraries)
    {
        itineraries.Add(new Itineraries
        {
            FlightId = itenary.flight_id,
            DepartureAt = itenary.departureAt,
            ArrivalAt = itenary.arrivalAt,
            AvailableSeats = itenary.availableSeats,
            Currency = itenary.prices.currency,
            AdultPrice = itenary.prices.adult,
            ChildPrice = itenary.prices.child

        });

    }
    flightRoutes.Itineraries = itineraries;
    flightRepository.Create(flightRoutes);
}


host.Run();

