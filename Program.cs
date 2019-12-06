using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace MusicPlaylistAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("*** Music Playlist Analyzer ***");

            if (args.Length != 2)       // checks if the correct # of files were entered into the command line
            {
                Console.WriteLine("\nMusicPlaylistAnalyzer <music_playlist_file_path> <report_file_path>\n");
                Console.WriteLine("Supply a music file path and report file path as command line arguments in the syntax seen above.\n");
                System.Environment.Exit(0);
            } // end if statement

            else
            {
                if (!File.Exists(args[0]))      // checks if the 1st arg exists
                {
                    Console.Write("\nThe provided music playlist file path cannot be found.\n");
                    //System.Environment.Exit(0);
                }
                else if (!File.Exists(args[1]))      // checks if the 2nd arg exists
                {
                    Console.Write("\nThe provided report file path cannot be found.\n");
                    //System.Environment.Exit(0);
                }
                else
                { }
                
            } // end else statement

            string musicPlaylistFilePath = args[0];
            string reportFilePath = args[1];

            List<Playlist> playlistList = null;
            try
            {
                playlistList = PlaylistLoader.Load(musicPlaylistFilePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(1);
            }

            var report = PlaylistReport.GenerateText(playlistList);

            try
            {
                System.IO.File.WriteAllText(reportFilePath, report);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(2);
            } // end catch

                  /**************************************************/

                // LINQ statements
                /*
                Console.WriteLine("\nSongs that received 200 or more plays:\n");
                var songsWith200Plays = from song in songs where Playlist.plays >= 200 select song;
                foreach (var song in songsWith200Plays)
                {
                    Console.WriteLine(song.ToString());
                }

                Console.WriteLine("\nNumber of Alternative songs:\n");
                var songsInGenreAlternative = from song in songs where Playlist.genre == "Alternative" select song.Count;
                foreach (var song in songsInGenreAlternative)
                {
                    Console.WriteLine(song.ToString());
                }

                Console.WriteLine("\nNumber of Hip-Hop / Rap songs:\n");
                var songsInGenreHipHopRap = from song in songs where Playlist.genre == "Hip - Hop / Rap" select song.Count;
                foreach (var song in songsInGenreHipHopRap)
                {
                    Console.WriteLine(song.ToString());
                }

                Console.WriteLine("\nSongs that are from the album \"Welcome to the Fishbowl?:\"");
                var songsFromAlbumWelcomeFishbowl = from song in songs where Playlist.album == "Welcome to the Fishbowl?" select song;
                foreach (var song in songsFromAlbumWelcomeFishbowl)
                {
                    Console.WriteLine(song.ToString());
                }

                Console.WriteLine("\nSongs from before 1970:");
                var songsFromBefore1970 = from song in songs where Playlist.year < 1970 select song;
                foreach (var song in songsFromBefore1970)
                {
                    Console.WriteLine(song.ToString());
                }

                Console.WriteLine("\nSongs with names that are more than 85 characters long:");
                var songNamesMoreThan85 = from song in songs where Playlist.name.Length > 85 select song;
                foreach (var song in songNamesMoreThan85)
                {
                    Console.WriteLine(song.ToString());
                }

                Console.WriteLine("\nThe longest song:\n");
                var longestSong = from song in songsFromAlbumWelcomeFishbowl where Playlist.time.Max select song;
                foreach (var song in longestSong)
                {
                    Console.WriteLine(song.ToString());
                }
                */


        } // end Main
    } // end class
} // end namespace

