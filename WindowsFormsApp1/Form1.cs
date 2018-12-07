using Google.Apis.Auth.OAuth2;
using Google.Cloud.TextToSpeech.V1;
using Grpc.Auth;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static string settingsFileName = "settings.ini";

        string jsonTokenFile = "C:\\Users\\Nikola\\Temp\\My First Project-039858c06c3d.json";
        string outputFile = "C:\\Users\\Nikola\\Temp\\output.mp3";
        List<string> voices;
        GoogleCredential credential;
        Channel channel;
        TextToSpeechClient client;
        VoiceSelectionParams voiceSelection;
        SynthesisInput input;
        AudioConfig audioConfig;

        public Form1()
        {
            InitializeComponent();

            credential = GoogleCredential.FromFile(jsonTokenFile)
                .CreateScoped(TextToSpeechClient.DefaultScopes);
            channel = new Channel(TextToSpeechClient.DefaultEndpoint.ToString(), credential.ToChannelCredentials());
            client = TextToSpeechClient.Create(channel);

            if (File.Exists(settingsFileName))
            {
                using (StreamReader reader = new StreamReader(settingsFileName))
                {
                    for (int i = 0; i < 10; i++)
                    {

                    }
                }


            }
            else
            {

            }


        }

        private void LoadSettings()
        {

        }

        private void ConvertBtn_Click(object sender, EventArgs e)
        {
            

            // The input to be synthesized, can be provided as text or SSML.
            //var input = new SynthesisInput
            //{
            //    Text = textBox.Text
            //};

            // Build the voice request.
            //var voiceSelection = new VoiceSelectionParams
            //{
            //    LanguageCode = "en-US",
            //    Name = "en-US-Wavenet-A",
            //    SsmlGender = SsmlVoiceGender.Neutral
            //};

            // Specify the type of audio file.
            //var audioConfig = new AudioConfig
            //{
            //    AudioEncoding = AudioEncoding.Mp3
            //};

            // Perform the text-to-speech request.
            var response = client.SynthesizeSpeech(input, voiceSelection, audioConfig);

            // Write the response to the output file.
            using (var output = File.Create(outputFile))
            {
                response.AudioContent.WriteTo(output);
            }
        }

        private void PickTokenFileBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
