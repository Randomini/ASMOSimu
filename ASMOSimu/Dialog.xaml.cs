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



namespace ASMOSimu
{
    /// <summary>
    /// Interaction logic for Dialog.xaml
    /// </summary>
    public partial class Dialog : Page
    {
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
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSitu.Loadsitu(CreateSituation.lst_situ, "Situationen.xml");
            LstVw_Situation.ItemsSource = CreateSituation.lst_situ;
            LstVw_Situation.Items.Refresh();

        }

        private void LstVw_Situation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentsit = (Situation)LstVw_Situation.SelectedItem;
        }

        private void Btn_InputSent_Click(object sender, RoutedEventArgs e)
        {
            foreach(Input x in currentout.lst_inputs)
            {
                if (TxtBx_Input.Text.Contains(x.InputText))
                {
                    foreach(Situation y in CreateSituation.lst_situ)
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
    }
}
