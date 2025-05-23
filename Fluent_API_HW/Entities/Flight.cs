﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluent_API_HW.Entities
{
    public class Flight
    {
        public int Id { get; set; }
        public string Number { get; set; }

        public int AirplaneId { get; set; }
        public Airplane Airplane { get; set; }

        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        public string DepartureLocation { get; set; }
        public string ArrivalLocation { get; set; }

        public ICollection<Client> Clients { get; set; }
    }
}
