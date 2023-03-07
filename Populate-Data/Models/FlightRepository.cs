using Populate_Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Populate_Data.Models
{
    public class FlightRepository: IFlightRepository
    {
        private readonly FlightFinderDBContext _context;

        public FlightRepository(FlightFinderDBContext context)  => _context = context;

        public void Create(FlightRoutes routes)
        {
            _context.Add(routes); 
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
