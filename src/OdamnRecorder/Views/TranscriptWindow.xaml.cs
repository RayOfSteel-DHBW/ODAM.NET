using System.Windows;

namespace OdamnRecorder.Views
{
    public partial class TranscriptWindow : Window
    {
        public TranscriptWindow(string content)
        {
            InitializeComponent();
            TranscriptTextBlock.Text = content;
        }

        public void ShowTranscript()
        {
            this.Show();
        }
    }
}