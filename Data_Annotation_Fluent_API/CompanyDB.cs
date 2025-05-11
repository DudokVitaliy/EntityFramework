using Data_Annotation_Fluent_API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Annotation_Fluent_API
{
    public class CompanyDB : DbContext
    {
        public CompanyDB()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API cofiguration
            modelBuilder.Entity<Department>().ToTable("Position");
            modelBuilder.Entity<Department>()
                .Property(e => e.Name)
                .IsRequired() // not null
                .HasMaxLength(50)
                .IsUnicode(true);
            modelBuilder.Entity<Department>()
                .Property(p => p.Phone)
                .IsRequired(true)
                .HasMaxLength(50)
                .IsFixedLength()
                .IsUnicode(false);
            modelBuilder.Entity<Worker>().HasKey(e => e.Number);
            modelBuilder.Entity<Worker>()
                .Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired();
            // 1 to many
            modelBuilder.Entity<Worker>()
                .HasOne(c => c.Country)
                .WithMany(c => c.Workers)
                .HasForeignKey(c => c.CountryId);
            modelBuilder.Entity<Worker>()
                .HasOne(c => c.Department)
                .WithMany(c => c.Workers)
                .HasForeignKey(c => c.DepartmentID);
            // many to many
            modelBuilder.Entity<Project>()
                .HasMany(e => e.Workers)
                .WithMany(e => e.Projects);
            modelBuilder.SeedCountries();
            modelBuilder.SeedDepartmens();
            modelBuilder.SeedProjects();
            modelBuilder.SeedWorkers();


        }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
