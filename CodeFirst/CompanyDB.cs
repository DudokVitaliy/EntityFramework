using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class CompanyDB : DbContext
    {
        public CompanyDB()
        {
            this.Database.EnsureCreated();
            //this.Database.EnsureDeleted();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-RGQD9R5\SQLEXPRESS;
                                        Initial Catalog = Company;
                                        Integrated Security = True;
                                        Connect Timeout = 2;
                                        Encrypt = False;
                                        Trust Server Certificate = False;
                                        Application Intent = ReadWrite;
                                        Multi Subnet Failover = False");
        }
        public DbSet <Worker> Workers { get; set; }
        public DbSet <Project> Projects { get; set; }
        public DbSet <Country> Countries { get; set; }
        public DbSet <Department> Departments { get; set; }
    }
}
