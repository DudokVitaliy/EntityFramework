using Fluent_API_HW.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Fluent_API_HW
{
    public class AviationDB : DbContext
    {
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<ClientFlight> ClientFlights { get; set; }

        public AviationDB()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-RGQD9R5\SQLEXPRESS;
                                        Initial Catalog = Aviation;
                                        Integrated Security = True;
                                        Connect Timeout = 2;
                                        Encrypt = False;
                                        Trust Server Certificate = False;
                                        Application Intent = ReadWrite;
                                        Multi Subnet Failover = False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //
            modelBuilder.Entity<Airplane>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Airplane>()
                .Property(a => a.Model).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<Airplane>()
                .Property(a => a.Type).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Airplane>()
                .Property(a => a.Country).HasMaxLength(100);

            //
            modelBuilder.Entity<Flight>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<Flight>()
                .Property(f => f.Number).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Flight>()
                .HasOne(f => f.Airplane)
                .WithMany(a => a.Flights)
                .HasForeignKey(f => f.AirplaneId);

            modelBuilder.Entity<Flight>()
                .Property(f => f.DepartureLocation).HasMaxLength(100);
            modelBuilder.Entity<Flight>()
                .Property(f => f.ArrivalLocation).HasMaxLength(100);

            // 
            modelBuilder.Entity<Client>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Client>()
                .Property(c => c.FirstName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Client>()
                .Property(c => c.LastName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Client>()
                .Property(c => c.Email).IsRequired();
            modelBuilder.Entity<Client>()
                .Property(c => c.Gender).HasMaxLength(10);

            //
            modelBuilder.Entity<Account>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Account>()
                .Property(a => a.Login).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Account>()
                .Property(a => a.Password).IsRequired().HasMaxLength(100);

            //
            modelBuilder.Entity<Client>()
                .HasOne(c => c.Account)
                .WithOne(a => a.Client)
                .HasForeignKey<Client>(c => c.AccountId);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Flights)
                .WithMany(f => f.Clients)
                .UsingEntity<ClientFlight>(
                    j => j.HasOne(cf => cf.Flight).WithMany().HasForeignKey(cf => cf.FlightId),
                    j => j.HasOne(cf => cf.Client).WithMany().HasForeignKey(cf => cf.ClientId)
                    );


            modelBuilder.SeedAirplanes();
            modelBuilder.SeedClients();
            modelBuilder.SeedAccounts();
            modelBuilder.SeedFlights();
            modelBuilder.SeedFlightClients();
        }
    }
}
