using CodeFirstHW.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstHW
{
    public class MusicContext : DbContext
    {

        public MusicContext()
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Playlist> Playlists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-RGQD9R5\SQLEXPRESS;
                                        Initial Catalog = MusicDB;
                                        Integrated Security = True;
                                        Connect Timeout = 2;
                                        Encrypt = False;
                                        Trust Server Certificate = False;
                                        Application Intent = ReadWrite;
                                        Multi Subnet Failover = False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Track>()
                .HasMany(t => t.Playlists)
                .WithMany(p => p.Tracks);
        }
    }

}
