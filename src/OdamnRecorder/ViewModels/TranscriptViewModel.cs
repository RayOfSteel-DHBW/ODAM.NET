using System.ComponentModel;

namespace OdamnRecorder.ViewModels
{
    public class TranscriptViewModel : INotifyPropertyChanged
    {
        private string _transcript;

        public string Transcript
        {
            get => _transcript;
            set
            {
                if (_transcript != value)
                {
                    _transcript = value;
                    OnPropertyChanged(nameof(Transcript));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}