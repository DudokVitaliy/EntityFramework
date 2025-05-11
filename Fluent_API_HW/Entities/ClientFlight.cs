using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluent_API_HW.Entities
{
    public class ClientFlight
    {
        public int ClientId { get; set; }
        public int FlightId { get; set; }

        public Client Client { get; set; }
        public Flight Flight { get; set; }
    }

}
