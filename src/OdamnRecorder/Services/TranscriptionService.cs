using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OdamnRecorder.Services
{
    public class TranscriptionService
    {
        private static readonly HttpClient client = new HttpClient();
        private const string ApiUrl = "https://api.openai.com/v1/audio/transcriptions";

        public async Task<string> TranscribeAsync(byte[] audioData, string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentException("API key is required.", nameof(apiKey));
            }

            using (var content = new ByteArrayContent(audioData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("audio/wav");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                using (var response = await client.PostAsync(ApiUrl, content))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception($"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                    }

                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    dynamic result = JsonConvert.DeserializeObject(jsonResponse);
                    return result?.text;
                }
            }
        }
    }
}