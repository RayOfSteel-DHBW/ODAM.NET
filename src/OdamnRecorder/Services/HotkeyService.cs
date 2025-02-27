using System;
using System.Windows.Input;

namespace OdamnRecorder.Services
{
    public class HotkeyService
    {
        private readonly RecordingOrchestrator _orchestrator;

        public HotkeyService(RecordingOrchestrator orchestrator)
        {
            _orchestrator = orchestrator;
            StartListening();
        }

        private void StartListening()
        {
            // Implementation for listening to global hotkeys
            // For example, using a library like GlobalHotKey
        }

        private void OnHotkeyPressed(object sender, HotkeyEventArgs e)
        {
            if (e.Hotkey == Hotkey.CtrlAltR) // Example hotkey
            {
                _orchestrator.ProcessAudio();
            }
        }
    }
}