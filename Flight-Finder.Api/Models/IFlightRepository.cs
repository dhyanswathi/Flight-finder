namespace Flight_Finder.Api.Models
{
    public interface IFlightRepository
    {
        void Save();
        IEnumerable<FlightRoutes> GetAllRoutes();
        FlightRoutes GetById(string id);
    }
}
