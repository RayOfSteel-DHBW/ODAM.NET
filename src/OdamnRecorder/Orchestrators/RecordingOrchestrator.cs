using System;
using System.Timers;

namespace OdamnRecorder.Orchestrators
{
    public class RecordingOrchestrator
    {
        private readonly AudioCaptureService _audioCaptureService;
        private readonly TranscriptionService _transcriptionService;
        private readonly int _maxAttempts;
        private bool _isRecording;
        private Timer _timer;

        public RecordingOrchestrator(AudioCaptureService audioCaptureService, TranscriptionService transcriptionService, int maxAttempts)
        {
            _audioCaptureService = audioCaptureService;
            _transcriptionService = transcriptionService;
            _maxAttempts = maxAttempts;
        }

        public void StartRecording(int maxSeconds = int.MaxValue)
        {
            if (!_isRecording)
            {
                _audioCaptureService.StartRecording();
                _isRecording = true;
                Console.WriteLine("Recording started.");
                ScheduleAutomaticProcessing(maxSeconds);
            }
        }

        public void StopRecording()
        {
            if (_isRecording)
            {
                _audioCaptureService.StopRecording();
                _isRecording = false;
                Console.WriteLine("Recording stopped.");
            }
        }

        private void ScheduleAutomaticProcessing(int maxSeconds)
        {
            _timer = new Timer(maxSeconds * 1000);
            _timer.Elapsed += (sender, e) => ProcessAudio(null);
            _timer.AutoReset = false;
            _timer.Start();
        }

        public void ProcessAudio(string overrideFilePath)
        {
            if (!_isRecording && overrideFilePath == null)
                return;

            byte[] audioData = null;
            if (overrideFilePath == null)
            {
                audioData = _audioCaptureService.GetBufferContent();
            }

            string transcript;
            try
            {
                if (overrideFilePath != null || (audioData != null && audioData.Length > 0))
                {
                    transcript = _transcriptionService.Transcribe(audioData, overrideFilePath);
                    var transcriptWindow = new TranscriptWindow(transcript);
                    transcriptWindow.Show();
                    Console.WriteLine("Transcription complete: " + transcript);
                }
            }
            catch (Exception e)
            {
                transcript = "[Error: Failed to transcribe audio]";
                Console.Error.WriteLine("Transcription failed: " + e.Message);
            }
        }
    }
}