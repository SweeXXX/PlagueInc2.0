using System;
using System.Media;
using System.Threading;
using NAudio.Wave;

namespace Plague_Inc
{
    public class MusicPlayer
    {
        private WaveOutEvent waveOut;
        private Thread playbackThread;

        public void Start()
        {
            // Initialize the WaveOutEvent and AudioFileReader
            waveOut = new WaveOutEvent();
            var audioFileReader = new AudioFileReader(@"C:\Users\Никита\Desktop\fakk\Plague Inc.2.0\Resources\Plague Inc. OST - Plague Blossom_(audiohunter.ru).mp3");

            // Set the DesiredLatency for smoother playback
            waveOut.DesiredLatency = 100;

            // Hook up the AudioFileReader to the WaveOutEvent
            waveOut.Init(audioFileReader);

            // Create a new thread to handle the playback
            playbackThread = new Thread(PlaybackThread);
            playbackThread.IsBackground = true;
            playbackThread.Start();
        }

        private void PlaybackThread()
        {
            // Start the playback
            waveOut.Play();

            // Wait until the playback completes or is stopped
            while (waveOut.PlaybackState == PlaybackState.Playing)
            {
                Thread.Sleep(100);
            }

            // Cleanup resources
            waveOut.Stop();
            waveOut.Dispose();
        }

        public void Stop()
        {
            // Stop the playback
            waveOut.Stop();
        }

    }
}