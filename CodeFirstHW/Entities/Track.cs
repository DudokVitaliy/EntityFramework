using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstHW.Entities
{
    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
        public ICollection<Playlist> Playlists { get; set; }
        public double Rating { get; set; }
        public int ListenCount { get; set; }
        public string? Lyrics { get; set; }
    }

}
