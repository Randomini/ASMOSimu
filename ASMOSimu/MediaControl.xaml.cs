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

namespace ASMOSimu
{
    /// <summary>
    /// Interaction logic for MediaControl.xaml
    /// </summary>
    public partial class MediaControl : Page
    {
        public static List<Musiker> lst_media = new List<Musiker>();
        public Musiker musikerCurrent = new Musiker();
        
        public MediaControl()
        {
            InitializeComponent();
        }

        private void Btn_Künstler_Click(object sender, RoutedEventArgs e)
        {
            Musiker musiker = new Musiker(TxtBx_Künstler.Text);
            //musikerCurrent.MusikerName = TxtBx_Künstler.Text;
            musikerCurrent = musiker;
            TxtBx_Künstler.Text = "";
            lst_media.Add(musiker);
            LstVw_Künstler.Items.Refresh();
        }

        private void Btn_Add_Link_Click(object sender, RoutedEventArgs e)
        {
            musikerCurrent = (Musiker)LstVw_Künstler.SelectedItem;
            musikerCurrent.ytLinks.Add(TxtBx_Links.Text);
           // lst_media.Add(musikerCurrent);
            TxtBx_Links.Text = "";
            LstVw_Links.Items.Refresh();
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            Save.Savedata(lst_media, "Media.xml");
            LstVw_Künstler.Items.Refresh();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            FileInfo myFile = new FileInfo("Media.xml");
            if (myFile.Exists)
            {
               LoadMedia.LoadMedi(lst_media, "Media.xml");
            }
            LstVw_Künstler.ItemsSource = lst_media;
            LstVw_Künstler.Items.Refresh();
        }

        private void Btn_browserstart_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=sahlA0XWF5w");
        }

        private void LstVw_Künstler_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            musikerCurrent = (Musiker)LstVw_Künstler.SelectedItem;
            LstVw_Links.ItemsSource = musikerCurrent.ytLinks;
            LstVw_Links.Items.Refresh();
        }

       
    }
}
