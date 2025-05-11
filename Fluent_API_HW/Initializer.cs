using Fluent_API_HW.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluent_API_HW
{
    public static class Initializer
    {
        public static void SeedAirplanes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airplane>().HasData(new Airplane[]
            {
            new Airplane { Id = 1, Model = "Boeing 737", Type = "Passenger", MaxPassengers = 180, Country = "USA" },
            new Airplane { Id = 2, Model = "Airbus A320", Type = "Passenger", MaxPassengers = 170, Country = "France" },
            new Airplane { Id = 3, Model = "Antonov An-225", Type = "Cargo", MaxPassengers = 0, Country = "Ukraine" }
            });
        }

        public static void SeedAccounts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(new Account[]
            {
            new Account { Id = 1, Login = "ivan123", Password = "pass1" },
            new Account { Id = 2, Login = "olena321", Password = "pass2" }
            });
        }

        public static void SeedClients(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(new Client[]
            {
            new Client
            {
                Id = 1,
                FirstName = "Ivan",
                LastName = "Petrenko",
                Email = "ivan@example.com",
                Gender = "Male",
                AccountId = 1
            },
            new Client
            {
                Id = 2,
                FirstName = "Olena",
                LastName = "Kovalenko",
                Email = "olena@example.com",
                Gender = "Female",
                AccountId = 2
            }
            });
        }

        public static void SeedFlights(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>().HasData(new Flight[]
            {
            new Flight
            {
                Id = 1,
                Number = "FL1001",
                AirplaneId = 1,
                DepartureTime = new DateTime(2025, 6, 1, 10, 0, 0),
                ArrivalTime = new DateTime(2025, 6, 1, 13, 0, 0),
                DepartureLocation = "Kyiv",
                ArrivalLocation = "Warsaw"
            },
            new Flight
            {
                Id = 2,
                Number = "FL1002",
                AirplaneId = 2,
                DepartureTime = new DateTime(2025, 6, 2, 12, 0, 0),
                ArrivalTime = new DateTime(2025, 6, 2, 15, 0, 0),
                DepartureLocation = "Lviv",
                ArrivalLocation = "Berlin"
            }
            });
        }

        public static void SeedFlightClients(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientFlight>().HasData(
                new ClientFlight { ClientId = 1, FlightId = 1 },
                new ClientFlight { ClientId = 2, FlightId = 2 }
            );
        }

    }

}
