using CodeFirstHW.Entities;
using Microsoft.EntityFrameworkCore;

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


