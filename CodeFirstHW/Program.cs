using CodeFirstHW.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CodeFirstHW
{
    internal class Program
    {
        public static void AddTrackToPlaylist(MusicContext context, int playlistId, int trackId)
        {
            var playlist = context.Playlists.Include(p => p.Tracks).FirstOrDefault(p => p.Id == playlistId);
            var track = context.Tracks.Find(trackId);

            if (playlist != null && track != null && !playlist.Tracks.Contains(track))
            {
                playlist.Tracks.Add(track);
                context.SaveChanges();
            }
        }
        static void ShowPlaylists(MusicContext context)
        {
            var playlists = context.Playlists.Include(p => p.Tracks).ToList();
            foreach (var p in playlists)
            {
                Console.WriteLine($"\n {p.Name} ({p.Category})");
                foreach (var t in p.Tracks)
                    Console.WriteLine($"   {t.Name} ({t.Duration:mm\\:ss})");
            }
        }

        static void CreatePlaylist(MusicContext context)
        {
            Console.Write("Enter playlist name: ");
            string name = Console.ReadLine();
            Console.Write("Enter category: ");
            string category = Console.ReadLine();

            var playlist = new Playlist { Name = name, Category = category };
            context.Playlists.Add(playlist);
            context.SaveChanges();
            Console.WriteLine("Playlist created!");
        }
        static void AddTrackToPlaylist(MusicContext context)
        {
            ShowPlaylists(context);
            Console.Write("\nEnter Playlist ID: ");
            int pid = int.Parse(Console.ReadLine());
            ShowAllTracks(context);
            Console.Write("Enter Track ID: ");
            int tid = int.Parse(Console.ReadLine());

            var playlist = context.Playlists.Include(p => p.Tracks).FirstOrDefault(p => p.Id == pid);
            var track = context.Tracks.Find(tid);

            if (playlist != null && track != null)
            {
                if (!playlist.Tracks.Contains(track))
                {
                    playlist.Tracks.Add(track);
                    context.SaveChanges();
                    Console.WriteLine("Track added!");
                }
                else Console.WriteLine("Track already in playlist.");
            }
            else Console.WriteLine("Invalid playlist or track ID.");
        }
        static void ShowAllTracks(MusicContext context)
        {
            var tracks = context.Tracks.Include(t => t.Album).ToList();
            foreach (var t in tracks)
            {
                Console.WriteLine($"#{t.Id}: {t.Name} | Album: {t.Album.Name} | Duration: {t.Duration:mm\\:ss}");
            }
        }
        // =========================================================================================
        public static void ShowPopularTracksInAlbum(MusicContext context, int albumId)
        {
            var avgListens = context.Tracks
                .Where(t => t.AlbumId == albumId)
                .Average(t => t.ListenCount);

            var tracks = context.Tracks
                .Where(t => t.AlbumId == albumId && t.ListenCount > avgListens)
                .ToList();

            foreach (var track in tracks)
            {
                Console.WriteLine($"Track: {track.Name}, Listens: {track.ListenCount}");
            }
        }
        public static void ShowTop3TracksAndAlbums(MusicContext context, int artistId)
        {
            var topTracks = context.Tracks
                .Where(t => t.Album.ArtistId == artistId)
                .OrderByDescending(t => t.Rating)
                .Take(3)
                .ToList();

            var topAlbums = context.Albums
                .Where(a => a.ArtistId == artistId)
                .OrderByDescending(a => a.Rating)
                .Take(3)
                .ToList();

            Console.WriteLine("Top Tracks:");
            topTracks.ForEach(t => Console.WriteLine($"{t.Name} - Rating: {t.Rating}"));

            Console.WriteLine("Top Albums:");
            topAlbums.ForEach(a => Console.WriteLine($"{a.Name} - Rating: {a.Rating}"));
        }
        public static void SearchTrack(MusicContext context, string query)
        {
            var results = context.Tracks
                .Where(t => t.Name.Contains(query) || (t.Lyrics != null && t.Lyrics.Contains(query)))
                .ToList();

            foreach (var track in results)
            {
                Console.WriteLine($"Found: {track.Name}");
            }
        }

        static void Main(string[] args)
        {
            var context = new MusicContext();

            Initialize.Initializer(context);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\t\tMusic App");
                Console.WriteLine("\t1. Show Playlists");
                Console.WriteLine("\t2. Create Playlist");
                Console.WriteLine("\t3. Add Track to Playlist");
                Console.WriteLine("\t4. Show All Tracks");
                Console.WriteLine("\t5. Show Popular Tracks in Album");
                Console.WriteLine("\t6. Show Top 3 Tracks And Albums");
                Console.WriteLine("\t7. Search Track");
                Console.WriteLine("\t0. Exit");
                Console.Write("\t-> ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ShowPlaylists(context);
                        break;
                    case "2":
                        CreatePlaylist(context);
                        break;
                    case "3":
                        AddTrackToPlaylist(context);
                        break;
                    case "4":
                        ShowAllTracks(context);
                        break;
                    case "5":
                        Console.Write("Enter album ID: ");
                        if (int.TryParse(Console.ReadLine(), out int albumId))
                        {
                            ShowPopularTracksInAlbum(context, albumId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        break;

                    case "6":
                        Console.Write("Enter artist ID: ");
                        if (int.TryParse(Console.ReadLine(), out int artistId))
                        {
                            ShowTop3TracksAndAlbums(context, artistId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        break;

                    case "7":
                        Console.Write("Enter search text (part of name or lyrics): ");
                        string query = Console.ReadLine();
                        SearchTrack(context, query);
                        break;

                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press any key...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}


