using PrismExample.DependencyServices;
using PrismExample.ViewModels;
using System;
using Xamarin.Forms;

namespace PrismExample
{
    public partial class HomePage : ContentPage
    {
        public delegate ContentPage GetEditorInstance(string InitialEditorText);
        static public GetEditorInstance EditorFactory;
        static ISpeechToText speechRecognitionInstance;

        public HomePage()
        {
            InitializeComponent();

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    iOSLayout.IsVisible = true;
                    this.Content = iOSLayout;
                    speechRecognitionInstance = DependencyService.Get<ISpeechToText>();
                    speechRecognitionInstance.textChanged += OnTextChange;
                    break;

                case Device.Android:
                    androidLayout.IsVisible = true;
                    voiceButton.OnTextChanged += (s) =>
                    {
                        ((HomePageViewModel)BindingContext).Text = s; // Accessing binding context from view model
                        ((HomePageViewModel)BindingContext).GoToVoiceRecognisedPage();
                    };
                    break;
            }
        }

        public void OnStart(Object sender, EventArgs args)
        {
            speechRecognitionInstance.Start();
            nameButtonStart.IsEnabled = false;
            nameButtonStop.IsEnabled = true;
        }

        public void OnStop(Object sender, EventArgs args)
        {
            speechRecognitionInstance.Stop();
            nameButtonStart.IsEnabled = true;
            nameButtonStop.IsEnabled = false;
        }

        public void OnTextChange(object sender, EventArgsVoiceRecognition e)
        {
            ((HomePageViewModel)BindingContext).Text = e.Text;
            ((HomePageViewModel)BindingContext).GoToVoiceRecognisedPage();

            if (e.IsFinal)
            {
                nameButtonStart.IsEnabled = true;
            }
        }
    }
}
