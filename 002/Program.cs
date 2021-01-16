using System;

namespace _002 {
    class Program {
        static void Main(string[] args) {
            var songs = new Song[2];
            songs[0] = new Song("a", "hoge", 200);
            songs[1] = new Song("b", "foo", 120);

            foreach (var song in songs) {
                var ts = new TimeSpan(0, 0, song.Length);

                Console.WriteLine("title={0}, artist={1}, length={2:00}:{3:00}", song.Title, song.ArtistName,
                    ts.Minutes, ts.Seconds);
            }
        }
    }
}
