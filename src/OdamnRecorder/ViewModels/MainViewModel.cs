using System.Collections.ObjectModel;
using System.Windows.Input;

namespace OdamnRecorder.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _statusMessage;
        private ObservableCollection<string> _transcriptionResults;

        public MainViewModel()
        {
            TranscriptionResults = new ObservableCollection<string>();
            StartRecordingCommand = new RelayCommand(StartRecording);
            StopRecordingCommand = new RelayCommand(StopRecording);
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set => SetProperty(ref _statusMessage, value);
        }

        public ObservableCollection<string> TranscriptionResults
        {
            get => _transcriptionResults;
            set => SetProperty(ref _transcriptionResults, value);
        }

        public ICommand StartRecordingCommand { get; }
        public ICommand StopRecordingCommand { get; }

        private void StartRecording()
        {
            // Logic to start recording
            StatusMessage = "Recording started...";
        }

        private void StopRecording()
        {
            // Logic to stop recording and process transcription
            StatusMessage = "Recording stopped.";
        }
    }
}