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
using System.Speech.Synthesis;
using System.Speech.Recognition;
using ASMOSimu.Classes;
using System.Linq;



namespace ASMOSimu
{
    /// <summary>
    /// Interaction logic for SpeechSimu.xaml
    /// </summary>
    public partial class SpeechSimu : Page
    {
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();

        public Random random = new Random();
        public static Situation currentsit = new Situation();
        public static Output currentout = new Output();
        SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
        public SpeechSimu()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSitu.Loadsitu(CreateSituation.lst_situ, "Situationen.xml");
            LstVw_Situation.ItemsSource = CreateSituation.lst_situ;
            LstVw_Situation.Items.Refresh();
            recEngine.SetInputToDefaultAudioDevice();

        }





        private void LstVw_Situation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentsit = (Situation)LstVw_Situation.SelectedItem;
        }

        private void RdBtn_On_Click(object sender, RoutedEventArgs e)
        {


            while (RdBtn_On.IsChecked == true)
            { 
            currentout = currentsit.lst_outputs.ElementAt(random.Next(0, currentsit.lst_outputs.Count));
            TxtBl_Output.Text = currentout.OutputText;
            speechSynthesizer.SpeakAsync(currentout.OutputText);
                //Input für Grammatik einspeisen
                Choices commands = new Choices();

                foreach (Input x in currentout.lst_inputs)
                {
                    commands.Add(x.InputText);
                }
                GrammarBuilder gBuilder = new GrammarBuilder();
                gBuilder.Append(commands);
                Grammar grammar = new Grammar(gBuilder);

                recEngine.LoadGrammar(grammar);
                recEngine.SpeechRecognized += RecEngine_SpeechRecognized;
                recEngine.Recognize(TimeSpan.FromSeconds(5));
            }
        }

        private void RecEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            foreach(Input x in currentout.lst_inputs)
            {
                if(e.Result.Text == x.InputText)
                {
                    TxtBl_Input.Text = x.InputText;
                    foreach (Situation y in CreateSituation.lst_situ)
                    {
                        if (y.Sit_Name.Equals(x.Next_Situation))
                        {
                            LstVw_Situation.SelectedItem = y;
                            currentsit = y;
                            currentout = currentsit.lst_outputs.ElementAt(random.Next(0, currentsit.lst_outputs.Count));
                            LstVw_Situation.Items.Refresh();
                        }
                    }
                }
            }
        }
    }
}
