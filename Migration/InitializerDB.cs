using Microsoft.EntityFrameworkCore;
using MigrationComp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migration
{
    public static class InitializerDB
    {
        public static void SeedCountries(this ModelBuilder modelBuilder) // - розширення класу modelBuilder
        {
            modelBuilder.Entity<Country>().HasData(new Country[]
            {
                new Country() {Id = 1, Name = "Ukraine"},
                new Country() {Id = 2, Name = "Poland"},
                new Country() {Id = 3, Name = "USA"}
            }
            );
        }
        public static void SeedDepartmens(this ModelBuilder modelBuilder) // - розширення класу modelBuilder
        {
            modelBuilder.Entity<Department>().HasData(new Department[]
            {
                new Department() {Id = 1, Name = "Managment", Phone = "45-85-96"},
                new Department() {Id = 2, Name = "Programing", Phone = "45-85-05"},
                new Department() {Id = 3, Name = "Design", Phone = "45-79-35"},
            }
            );
        }
        public static void SeedProjects(this ModelBuilder modelBuilder) // - розширення класу modelBuilder
        {
            modelBuilder.Entity<Project>().HasData(new Project[]
            {
                new Project() {Id = 1, Name = "Tetris", LaunchDate = new DateTime (1992, 12, 12)},
                new Project() {Id = 2, Name = "CS", LaunchDate = new DateTime (2000, 5, 23)},
                new Project() {Id = 3, Name = "PacMan", LaunchDate = new DateTime (1999, 3, 13)},

            }
            );
        }
        public static void SeedWorkers(this ModelBuilder modelBuilder) // - розширення класу modelBuilder
        {
            modelBuilder.Entity<Worker>().HasData(new Worker[]
            {
                new Worker()
                {
                    Id = 1,
                    Name = "Bill",
                    Surname = "Gates",
                    Salary = 2700,
                    Birthday = new DateTime(2003, 2, 2),
                    DepartmentID = 1,
                    CountryId = 1
                },
                new Worker()
                {
                    Id = 2,
                    Name = "Tomm",
                    Surname = "Page",
                    Salary = 4300,
                    Birthday = new DateTime(2002, 3, 12),
                    DepartmentID = 2,
                    CountryId = 2
                },
                new Worker()
                {
                    Id = 3,
                    Name = "Emma",
                    Surname = "Miller",
                    Salary = 5500,
                    Birthday = new DateTime(2000, 12, 12),
                    DepartmentID = 1,
                    CountryId = 2
                },
                new Worker()
                {
                    Id = 4,
                    Name = "Oleg",
                    Surname = "King",
                    Salary = 3300,
                    Birthday = new DateTime(2003, 11, 24),
                    DepartmentID = 3,
                    CountryId = 3
                }
            });
        }
    }
}
