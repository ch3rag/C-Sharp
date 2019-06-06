// Lazy Object Instantiation

// System.Lazy<T> class allows you to define data that will not be created unless your codebase actually uses it. As this is a generic class, 
// you must specify the type of item to be created on first use, which can be any type with the .NET base class libraries or a custom type 
// you have authored yourself.


using System;

namespace Experiment {

    public class Song {
        public string Artist { get; set; }
        public string TrackName { get; set; }
        public double TrackLength { get; set; }
    }

    public class AllTracks {
        private Song[] allSongs = new Song[10000];

        public AllTracks() {
            // FILL UP ARRAY
            Console.WriteLine("Filling Up The Songs...");
        }

        public AllTracks(string artist) {
            // FILL UP ARRAY WITH PASSED ARTIST'S SONGS
            Console.WriteLine("Filling Up The {0}'s Songs...", artist);
        }
    }

    public class MediaPlayer {
        public void Play() {
            Console.WriteLine("Playing");
        }

        public void Pause() {
            Console.WriteLine("Pausing");
        }

        public void Stop() {
            Console.WriteLine("Stopping");
        }

        private Lazy<AllTracks> tracks = new Lazy<AllTracks>(() => {
            Console.WriteLine("Call Constructor");
            return new AllTracks();
        });

        public AllTracks GetAllTracks() {
            return tracks.Value;
        }
    }
    public class Program {
        public static void Main(string[] args) {
            // ALLTRACKS DO NOT GET INITIALIZED UNTIL WE USE IT
            MediaPlayer player = new MediaPlayer();
            player.Play();

            Console.WriteLine();

            MediaPlayer player2 = new MediaPlayer();
            AllTracks tracks = player2.GetAllTracks();
            player.Play();

            Console.ReadKey();
        }
    }
}