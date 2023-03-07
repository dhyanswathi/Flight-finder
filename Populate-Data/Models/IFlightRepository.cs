using Populate_Data.DTO;
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
        void Create(FlightRoutes routes);
        
    }
}
