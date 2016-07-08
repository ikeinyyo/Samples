using System;
using System.Linq;
using Windows.Media.SpeechRecognition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Maktub82.Sample.Speech
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            SpeechListeningChanged(false, SpeechListening, SpeechLoading);
            SpeechListeningChanged(false, UISpeechListening, UISpeechLoading);
        }

        private async void SpeechListeningClick(object sender, RoutedEventArgs e)
        {
            SpeechListeningChanged(true, SpeechListening, SpeechLoading);

            var speechRecognizer = new SpeechRecognizer();
            speechRecognizer.HypothesisGenerated += SpeechRecognizer_HypothesisGenerated;
            await speechRecognizer.CompileConstraintsAsync();

            SpeechRecognitionResult speechRecognitionResult = await speechRecognizer.RecognizeAsync();

            SpeechText.Text = speechRecognitionResult.Text;
            SpeechListeningChanged(false, SpeechListening, SpeechLoading);
        }

        private async void SpeechRecognizer_HypothesisGenerated(SpeechRecognizer sender, SpeechRecognitionHypothesisGeneratedEventArgs args)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                SpeechText.Text = args.Hypothesis.Text;
            });
        }

        private async void UISpeechListeningClick(object sender, RoutedEventArgs e)
        {
            SpeechListeningChanged(true, UISpeechListening, UISpeechLoading);

            var speechRecognizer = new SpeechRecognizer();
            speechRecognizer.HypothesisGenerated += UISpeechRecognizer_HypothesisGenerated;
            speechRecognizer.UIOptions.IsReadBackEnabled = false;
            speechRecognizer.UIOptions.ShowConfirmation = false;
            await speechRecognizer.CompileConstraintsAsync();

            SpeechRecognitionResult speechRecognitionResult = await speechRecognizer.RecognizeWithUIAsync();

            UISpeechText.Text = speechRecognitionResult.Text;
            SpeechListeningChanged(false, UISpeechListening, UISpeechLoading);
        }

        private async void UISpeechRecognizer_HypothesisGenerated(SpeechRecognizer sender, SpeechRecognitionHypothesisGeneratedEventArgs args)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                UISpeechText.Text = args.Hypothesis.Text;
            });
        }

        private void SpeechListeningChanged(bool isListening, Button button, ProgressRing loading)
        {
            button.IsEnabled = !isListening;
            loading.Visibility = isListening ? Visibility.Visible : Visibility.Collapsed;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var textCommand = e.Parameter as TextCommand;

            if (textCommand != null)
            {
                switch (textCommand.Type)
                {
                    case TextCommandType.Lower:
                        CortanaText.Text = textCommand.Sentence.ToLowerInvariant();
                        break;
                    case TextCommandType.Reverse:
                        CortanaText.Text = string.Join("", textCommand.Sentence.Reverse());
                        break;
                    default:
                        CortanaText.Text = textCommand.Sentence.ToUpperInvariant();
                        break;
                }
                SamplePivot.SelectedIndex = 1;
            }
        }
    }
}
