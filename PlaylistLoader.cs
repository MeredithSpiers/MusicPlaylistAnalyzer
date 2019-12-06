using System;
using System.Collections.Generic;
using System.IO;


namespace MusicPlaylistAnalyzer
{
    public class PlaylistLoader
    {
        private static int NumItemsInRow = 8;

        public static List<Playlist> Load(string musicPlaylistFilePath)
        {
            List<Playlist> playlistList = new List<Playlist>();

            try
            {
                //using (StreamReader reader = File.OpenText(musicPlaylistFilePath))
                using (var reader = new StreamReader(musicPlaylistFilePath))
                {
                    int lineNumber = 0;

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        lineNumber++;
                        if (lineNumber == 1) continue;
                        var values = line.Split('\t');
                        if (values.Length != NumItemsInRow)
                        {
                            throw new Exception($"Row {lineNumber} contains {values.Length} values. It should contain {NumItemsInRow}.");
                        }
                        
                        try
                        {
                            string name = values[0];
                            string artist = values[1];
                            string album = values[2];
                            string genre = values[3];
                            int size = Int32.Parse(values[4]);
                            int time = Int32.Parse(values[5]);
                            int year = Int32.Parse(values[6]);
                            int plays = Int32.Parse(values[7]);

                            Playlist playlist = new Playlist(name, artist, album, genre, size, time, year, plays);
                            playlistList.Add(playlist);
                            
                        } // end try statement

                        catch (FormatException e)
                        {
                            Console.WriteLine("The Playlist did not successfully convert to a string.");
                            throw new Exception($"Row {lineNumber} contains invalid data. ({e.Message})");
                        } // end catch statement
                    } // end while loop
                } // end StreamReader
            } // end try statement
            catch (Exception e)
            {
                throw new Exception($"Unable to open {musicPlaylistFilePath} ({e.Message}).");
            } // end catch statement

            return playlistList;
        } // end List Load
    } // end PlaylistLoader class
} // end namespace
