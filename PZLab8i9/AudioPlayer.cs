using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace PZLab8i9
{
    public static class AudioPlayer
    {
        // Główne tło muzyczne
        private static MediaPlayer muzykaTlo = new MediaPlayer();

        // Lista przechowująca odtwarzacze efektów, aby zapobiec ich wyczyszczeniu z pamięci RAM w trakcie grania
        private static List<MediaPlayer> sfxPlayers = new List<MediaPlayer>();

        // Dynamiczna ścieżka do folderu z grą
        private static string sciezkaBazowa = AppDomain.CurrentDomain.BaseDirectory + "Audio\\";

        public static void GrajMuzykeWTle(string nazwaPliku, double glosnosc = 0.3)
        {
            try
            {
                muzykaTlo.Open(new Uri(sciezkaBazowa + nazwaPliku));
                muzykaTlo.Volume = glosnosc;
                // Zapętlanie
                muzykaTlo.MediaEnded += (s, e) => muzykaTlo.Position = TimeSpan.Zero;
                muzykaTlo.Play();
            }
            catch { } // Zabezpieczenie na wypadek błędnej nazwy pliku
        }

        public static void ZatrzymajMuzyke()
        {
            muzykaTlo.Stop();
        }

        public static void GrajEfekt(string nazwaPliku, double glosnosc = 0.8)
        {
            try
            {
                MediaPlayer sfx = new MediaPlayer();
                sfx.Open(new Uri(sciezkaBazowa + nazwaPliku));
                sfx.Volume = glosnosc;

                // Kiedy dźwięk się skończy, wyrzucamy go z listy, żeby zwolnić pamięć
                sfx.MediaEnded += (s, e) => sfxPlayers.Remove(sfx);

                sfxPlayers.Add(sfx); // Trzymamy odtwarzacz przy życiu
                sfx.Play();
            }
            catch { }
        }
    }
}