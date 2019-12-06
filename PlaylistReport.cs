using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MusicPlaylistAnalyzer
{
    public class PlaylistReport
    {
        public static string GenerateText(List<Playlist> playlistList)
        {
            string report = "Music Playlist Analyzer\n\n";

            if (playlistList.Count() < 1)
            {
                report += "No data is available.\n";

                return report;
            }


            /**************** LINQ statements ****************/


            /*** 1st LINQ ***/
            
            Console.WriteLine("\nSongs that received 200 or more plays:\n");
            var songsWith200Plays = from Playlist in playlistList where Playlist.Plays >= 200 select playlistList;
            foreach (List<Playlist> playlist in songsWith200Plays)
                {
                    report += playlist + "\n";
                }

            /*** 2nd LINQ ***/

            Console.WriteLine("\nNumber of Alternative songs:\n");
            var songsInGenreAlternative = from Playlist in playlistList where Playlist.Genre == "Alternative" select playlistList.Count;
            foreach (List<Playlist> playlist in songsInGenreAlternative)
                {
                    report += playlist + "\n";
                }

            /*** 3rd LINQ ***/

            Console.WriteLine("\nNumber of Hip-Hop / Rap songs:\n");
            var songsInGenreHipHopRap = from Playlist in playlistList where Playlist.Genre == "Hip - Hop / Rap" select playlistList.Count;
            foreach (List<Playlist> playlist in songsInGenreHipHopRap)
                {
                    report += playlist + "\n";
                }

            /*** 4th LINQ ***/

            Console.WriteLine("\nSongs that are from the album \"Welcome to the Fishbowl\":");
            var songsFromAlbumWelcomeFishbowl = from Playlist in playlistList where Playlist.Album == "Welcome to the Fishbowl" select playlistList;
            foreach (List<Playlist> playlist in songsFromAlbumWelcomeFishbowl)
                {
                    report += playlist + "\n";
                }

            /*** 5th LINQ ***/

            Console.WriteLine("\nSongs from before 1970:");
            var songsFromBefore1970 = from Playlist in playlistList where Playlist.Year < 1970 select playlistList;
            foreach (List<Playlist> playlist in songsFromBefore1970)
                {
                    report += playlist + "\n";
                }

            /*** 6th LINQ ***/

            Console.WriteLine("\nSongs with names that are more than 85 characters long:");
            var songNamesMoreThan85 = from Playlist in playlistList where Playlist.Name.Length > 85 select playlistList;
            foreach (List<Playlist> Name in songNamesMoreThan85)
            {
                report += Name + "\n";
            }

            /*** 7th LINQ ***/
            
            Console.WriteLine("\nThe longest song:\n");
            var longestSong = from Playlist in playlistList where Playlist.Time.Max() select playlistList;
            foreach (List<Playlist> playlist in longestSong)
            {
                report += playlist + "\n";
            }
            
        } // end GenerateText
    } // end class
} // end namespace
