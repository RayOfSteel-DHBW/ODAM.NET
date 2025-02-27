using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using NAudio.Wave;

namespace OdamnRecorder.Services
{
    public class AudioCaptureService
    {
        private WaveInEvent waveSource;
        private MemoryStream audioBuffer;
        private bool isRecording;

        public AudioCaptureService()
        {
            audioBuffer = new MemoryStream();
        }

        public void StartRecording()
        {
            if (isRecording) return;

            isRecording = true;
            waveSource = new WaveInEvent
            {
                WaveFormat = new WaveFormat(44100, 16, 2)
            };
            waveSource.DataAvailable += OnDataAvailable;
            waveSource.StartRecording();
        }

        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            if (isRecording)
            {
                audioBuffer.Write(e.Buffer, 0, e.BytesRecorded);
            }
        }

        public byte[] GetBufferContent()
        {
            return audioBuffer.ToArray();
        }

        public void StopRecording()
        {
            if (!isRecording) return;

            isRecording = false;
            waveSource.StopRecording();
            waveSource.Dispose();
        }
    }
}