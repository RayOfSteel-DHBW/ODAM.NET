using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdamnRecorder.Services;

namespace OdamnRecorder.Tests.Services
{
    [TestClass]
    public class AudioCaptureServiceTests
    {
        private AudioCaptureService _audioCaptureService;

        [TestInitialize]
        public void Setup()
        {
            _audioCaptureService = new AudioCaptureService();
        }

        [TestMethod]
        public void StartRecording_ShouldBeginRecording()
        {
            // Arrange
            // Act
            _audioCaptureService.StartRecording();

            // Assert
            // Verify that recording has started (implementation-specific)
        }

        [TestMethod]
        public void StopRecording_ShouldStopRecording()
        {
            // Arrange
            _audioCaptureService.StartRecording();

            // Act
            _audioCaptureService.StopRecording();

            // Assert
            // Verify that recording has stopped (implementation-specific)
        }

        [TestMethod]
        public void GetBufferContent_ShouldReturnRecordedAudio()
        {
            // Arrange
            _audioCaptureService.StartRecording();
            // Simulate some recording time
            System.Threading.Thread.Sleep(1000);
            _audioCaptureService.StopRecording();

            // Act
            var audioData = _audioCaptureService.GetBufferContent();

            // Assert
            Assert.IsNotNull(audioData);
            Assert.IsTrue(audioData.Length > 0);
        }
    }
}