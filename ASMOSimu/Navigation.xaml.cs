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

namespace ASMOSimu
{
    /// <summary>
    /// Interaction logic for Navigation.xaml
    /// </summary>
    public partial class Navigation : Page
    {
        public Navigation()
        {
            InitializeComponent();
        }

        private void Btn_CreateSitu_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("CreateSituation.xaml", UriKind.Relative));
        }

        private void Btn_Dialog_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Dialog.xaml", UriKind.Relative));
        }

        private void Btn_PersInf_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("PersonInfo.xaml", UriKind.Relative));
        }

        private void Btn_Speech_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("SpeechSimu.xaml", UriKind.Relative));

        }
    }
}
