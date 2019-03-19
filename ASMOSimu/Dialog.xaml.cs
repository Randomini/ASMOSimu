using ASMOSimu.Classes;
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
using System.IO;
using System.Speech.Synthesis;
using System.Speech.Recognition;




namespace ASMOSimu
{
    /// <summary>
    /// Interaction logic for Dialog.xaml
    /// </summary>
    public partial class Dialog : Page
    {
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();

        public Random random = new Random();
        public static Situation currentsit = new Situation();
        public static Output currentout = new Output();
        SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
        public Dialog()
        {
            InitializeComponent();

        }

        private void Btn_StartSimu_Click(object sender, RoutedEventArgs e)
        {
            currentout = currentsit.lst_outputs.ElementAt(random.Next(0, currentsit.lst_outputs.Count));
            TxtBl_Output.Text = currentout.OutputText;
            speechSynthesizer.SpeakAsync(currentout.OutputText);
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSitu.Loadsitu(CreateSituation.lst_situ, "Situationen.xml");
            LstVw_Situation.ItemsSource = CreateSituation.lst_situ;
            LstVw_Situation.Items.Refresh();

            Choices commands = new Choices();
            commands.Add(new string[] { "say hello", "print my name" });
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
                    // txtB_output.Text = "Luca";
                    break;
            }
        }

        private void LstVw_Situation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentsit = (Situation)LstVw_Situation.SelectedItem;
        }

        private void Btn_InputSent_Click(object sender, RoutedEventArgs e)
        {
            foreach (Input x in currentout.lst_inputs)
            {
                if (TxtBx_Input.Text.Contains(x.InputText))
                {
                    foreach (Situation y in CreateSituation.lst_situ)
                    {
                        if (y.Sit_Name.Equals(x.Next_Situation))
                        {
                            LstVw_Situation.SelectedItem = y;
                            currentsit = y;
                            currentout = currentsit.lst_outputs.ElementAt(random.Next(0, currentsit.lst_outputs.Count));
                            TxtBl_Output.Text = currentout.OutputText;
                            speechSynthesizer.SpeakAsync(currentout.OutputText);
                        }
                    }
                }
            }
        }

        private void Btn_Stop_Click(object sender, RoutedEventArgs e)
        {
            recEngine.RecognizeAsyncStop();

        }
    }
}
