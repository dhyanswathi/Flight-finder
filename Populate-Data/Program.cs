// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Hosting;
using Populate_Data.Data;
using Populate_Data.Models;

IHost host = Host.CreateDefaultBuilder(args)
.ConfigureServices((context, services) =>
{
    var cns = "Data Source=LAPTOP-AC42D6SP\\MSSQLSERVER01;Initial Catalog=MilkDB;Integrated Security=True;encrypt=false";
    services.AddDbContext<MilkDBContext>(options => options.UseSqlServer(cns));
    services.AddTransient<MilkRepository>();
})
.Build();
var cns = "Data Source=LAPTOP-AC42D6SP\\MSSQLSERVER01;Initial Catalog=FlightFinderDB;Integrated Security=True";
//var path = $"{Environment.CurrentDirectory}..\\..\\..\\..\\..\\data\\Flights.json";
var path = "C:\\Users\\Mintu\\swathistudy\\pgp\\codeTest\\Flight-finder\\Populate-Data\\Data\\Flights.json";

var items = JsonReader.GetFlightData(path);

