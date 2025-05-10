using CodeFirstHW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstHW
{
    internal class Initialize
    {
        public static void Initializer(MusicContext context)
        {
            context.Database.EnsureCreated();

            if (context.Artists.Any()) return;

            var artist = new Artist { FirstName = "John", LastName = "Doe", Country = "USA" };
            var album = new Album { Name = "Best Hits", Year = 2020, Genre = "Pop", Artist = artist };
            var track1 = new Track { Name = "Hit One", Duration = TimeSpan.FromMinutes(3), Album = album };
            var track2 = new Track { Name = "Hit Two", Duration = TimeSpan.FromMinutes(4), Album = album };

            var playlist = new Playlist { Name = "Top Playlist", Category = "Favorites", Tracks = new List<Track> { track1, track2 } };

            context.Artists.Add(artist);
            context.Albums.Add(album);
            context.Tracks.AddRange(track1, track2);
            context.Playlists.Add(playlist);

            context.SaveChanges();
        }
    }
}
