using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var songs = new List<Song>();

        for (int i = 0; i < n; i++)
        {
            try
            {
                var songArgs = Console.ReadLine()
                        .Split(";");

                if (songArgs.Length != 3)
                {
                    throw new InvalidSongException();
                }

                var artist = songArgs[0];
                var songName = songArgs[1];
                var lenght = songArgs[2];

                var currSong = new Song(artist, songName, lenght);

                songs.Add(currSong);
                Console.WriteLine("Song added.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine($"Songs added: {songs.Count}");

        var secondsTotal = CalculatePlaylistSeconds(songs);
        var timespan = TimeSpan.FromSeconds(secondsTotal);

        Console.WriteLine($"Playlist length: {timespan.Hours}h {timespan.Minutes}m {timespan.Seconds}s");
    }

    private static long CalculatePlaylistSeconds(List<Song> songs)
    {
        var seconds = 0L;

        foreach (var song in songs)
        {
            seconds += song.Seconds + (song.Minutes * 60);
        }

        return seconds;
    }
}
