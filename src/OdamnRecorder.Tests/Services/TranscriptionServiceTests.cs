using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace OdamnRecorder.Tests.Services
{
    public class TranscriptionServiceTests
    {
        private readonly TranscriptionService _transcriptionService;

        public TranscriptionServiceTests()
        {
            _transcriptionService = new TranscriptionService();
        }

        [Fact]
        public async Task Transcribe_ValidAudio_ReturnsTranscription()
        {
            // Arrange
            var audioData = File.ReadAllBytes("path/to/test/audio.wav"); // Replace with a valid test audio file path

            // Act
            var result = await _transcriptionService.Transcribe(audioData, null);

            // Assert
            Assert.NotNull(result);
            Assert.Contains("expected transcription text", result); // Replace with expected text
        }

        [Fact]
        public async Task Transcribe_InvalidAudio_ThrowsException()
        {
            // Arrange
            byte[] invalidAudioData = new byte[0]; // Empty byte array to simulate invalid audio

            // Act & Assert
            await Assert.ThrowsAsync<IOException>(() => _transcriptionService.Transcribe(invalidAudioData, null));
        }

        [Fact]
        public async Task Transcribe_ValidFilePath_ReturnsTranscription()
        {
            // Arrange
            var filePath = "path/to/test/audio.mp4"; // Replace with a valid test audio file path

            // Act
            var result = await _transcriptionService.Transcribe(null, filePath);

            // Assert
            Assert.NotNull(result);
            Assert.Contains("expected transcription text", result); // Replace with expected text
        }
    }
}