// See https://aka.ms/new-console-template for more information

using Populate_Data.Data;
using Populate_Data.Models;


var cns = "Data Source=LAPTOP-AC42D6SP\\MSSQLSERVER01;Initial Catalog=FlightFinderDB;Integrated Security=True";
//var path = $"{Environment.CurrentDirectory}..\\..\\..\\..\\..\\data\\Flights.json";
var path = "C:\\Users\\Mintu\\swathistudy\\pgp\\codeTest\\Flight-finder\\Populate-Data\\Data\\Flights.json";

var items = JsonReader.GetFlightData(path);
foreach (var item in items)
{
    Console.WriteLine(item.arrivalDestination);
    Console.ReadLine();
}
