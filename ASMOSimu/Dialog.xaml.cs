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



namespace ASMOSimu
{
    /// <summary>
    /// Interaction logic for Dialog.xaml
    /// </summary>
    public partial class Dialog : Page
    {
       
        public Dialog()
        {
            InitializeComponent();

        }

        private void Btn_StartSimu_Click(object sender, RoutedEventArgs e)
        {
            LstVw_Situation.Items.Refresh();

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSitu.Loadsitu(CreateSituation.lst_situ, "Situationen.xml");
            LstVw_Situation.ItemsSource = CreateSituation.lst_situ;
            LstVw_Situation.Items.Refresh();

        }
    }
}
