using Microsoft.EntityFrameworkCore;

namespace Fluent_API_HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AviationDB context = new AviationDB();

            Console.WriteLine("Clients:");
            foreach (var client in context.Clients
                .Include(c => c.Account))
            {
                Console.WriteLine($"{client.FirstName} {client.LastName} | Email: {client.Email} | Login: {client.Account.Login}");
            }

            Console.WriteLine("\nFlights:");
            foreach (var flight in context.Flights
                .Include(f => f.Airplane))
            {
                Console.WriteLine($"Flight #{flight.Number}: {flight.DepartureLocation} -> {flight.ArrivalLocation} | Airplane: {flight.Airplane.Model}");
            }
        }
    }
}
