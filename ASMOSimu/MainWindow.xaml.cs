using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace ASMOSimu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_enable_Click(object sender, RoutedEventArgs e)
        {
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void Btn_enable_Loaded(object sender, RoutedEventArgs e)
        {
            Choices commands = new Choices();
            commands.Add(new string[] {"say hello", "print my name" });
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            Grammar grammar = new Grammar(gBuilder);

            recEngine.LoadGrammarAsync(grammar);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.SpeechRecognized += RecEngine_SpeechRecognized;
        }

        private void RecEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "say hello":
                    MessageBox.Show("Hello Luca");
                    break;

                case "print my name":
                    txtB_output.Text = "Luca";
                    break;
            }
        }

        private void Btn_disable_Click(object sender, RoutedEventArgs e)
        {
            recEngine.RecognizeAsyncStop();
        }
    }
}
