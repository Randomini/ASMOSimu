using ASMOSimu.Classes;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;



namespace ASMOSimu
{
    /// <summary>
    /// Interaction logic for CreateSituation.xaml
    /// </summary>
    public partial class CreateSituation : Page
    {
        public static List<Situation> lst_situ = new List<Situation>();
        public static Situation situationcurrent = new Situation();
        public static Output outputcurrent = new Output();
        public enum Status { neutral, good, bad };
        public static Input inputcurrent = new Input();

        public CreateSituation()
        {
            InitializeComponent();
        }

        private void Btn_SaveSitu_Click(object sender, RoutedEventArgs e)
        {

            Save.Savedata(lst_situ, "Situationen.xml");

            LstVw_Name.Items.Refresh();
        }

        private void Btn_CreateSitu_Click(object sender, RoutedEventArgs e)
        {
            Situation situation = new Situation(txtBx_SituName.Text, TxtBx_SituInfo.Text);
            lst_situ.Add(situation);
            situationcurrent = situation;
            LstVw_Name.Items.Refresh();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            FileInfo myFile = new FileInfo("Situationen.xml");
            if (myFile.Exists)
            {
                LoadSitu.Loadsitu(lst_situ, "Situationen.xml");
            }

            LstVw_Name.ItemsSource = lst_situ;
            
        }

        private void Btn_AddOut_Click(object sender, RoutedEventArgs e)
        {
            Output output = new Output(TxtBx_Output.Text);
           // output.OutputText = TxtBx_Output.Text;
            
            situationcurrent.lst_outputs.Add(output);
            LstVw_Output.ItemsSource = situationcurrent.lst_outputs;

            LstVw_Output.Items.Refresh();
            outputcurrent = output;
            
        }

 
        private void LstVw_Name_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            situationcurrent = (Situation)LstVw_Name.SelectedItem;
            LstVw_Output.ItemsSource = situationcurrent.lst_outputs;
            LstVw_Output.Items.Refresh();

        }

        private void LstVw_Output_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            outputcurrent = (Output)LstVw_Output.SelectedItem;

            if (outputcurrent != null)
            { 
            LstVw_Input.ItemsSource = outputcurrent.lst_inputs;
            LstVw_Input.Items.Refresh();
            }
        }

        private void Btn_AddIn_Click(object sender, RoutedEventArgs e)
        {
            Input input = new Input();
            input.InputText = TxtBx_Input.Text;
            input.Next_Situation = TxtBx_NxtSitu.Text;
            if(RdBtn_neut.IsChecked == true)
            {
                input.Istatus = (int)Status.neutral;
            }
            else if(RdBtn_good.IsChecked == true)
            {
                input.Istatus = (int)Status.good;
            }
            else if(RdBtn_bad.IsChecked == true)
            {
                input.Istatus = (int)Status.bad;
            }
            if(outputcurrent != null)
            {
                 LstVw_Input.ItemsSource = outputcurrent.lst_inputs;
                 outputcurrent.lst_inputs.Add(input);
                 LstVw_Input.Items.Refresh();

            }
        }

       
    }
}
