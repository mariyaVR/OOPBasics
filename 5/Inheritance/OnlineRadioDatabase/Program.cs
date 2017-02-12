using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineRadioDatabase.Exceptions;

namespace OnlineRadioDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());
            List<Song> allSongs = new List<Song>();

            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                
                try
                {
                    string artistName = input[0];
                    string songName = input[1];
                    long[] songLength = input[2]
                            .Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(long.Parse)
                            .ToArray();
                    long minutes = songLength[0];
                    long seconds = songLength[1];

                    SongLength minsAndSecs = new SongLength(minutes, seconds);
                    Song song = new Song(artistName, songName, minsAndSecs);
                    allSongs.Add(song);
                    Console.WriteLine("Song added.");
                }
                catch (InvalidSongException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine(InvalidSongLengthException.Message);
                }               
            }

            long playListLength = 0;
            foreach (var song in allSongs)
            {
                song.Length.CalculateTime();
                playListLength += song.Length.FullSongLengthInSeconds;
            }

            Console.WriteLine($"Songs added: {allSongs.Count}");

            long finalMinutes = playListLength / 60;
            long finalSeconds = playListLength % 60;
            long finalHours = playListLength / 3600;
            finalMinutes %= 60; //!

            Console.WriteLine("Playlist length: {0}h {1}m {2}s",
              finalHours, finalMinutes, finalSeconds);
        }
    }
}