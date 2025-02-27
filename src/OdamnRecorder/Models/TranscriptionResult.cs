using System.Collections.Generic;

namespace OdamnRecorder.Models
{
    public class TranscriptionResult
    {
        public string Transcript { get; set; }
        public List<string> Alternatives { get; set; }

        public TranscriptionResult()
        {
            Alternatives = new List<string>();
        }
    }
}