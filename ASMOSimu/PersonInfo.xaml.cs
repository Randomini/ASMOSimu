﻿using ASMOSimu.Classes;
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
    /// Interaction logic for PersonInfo.xaml
    /// </summary>
    public partial class PersonInfo : Page
    {
        public static List<Person> lst_Person = new List<Person>();
        public bool maleCheck = false ;
        public PersonInfo()
        {
            InitializeComponent();
        }

        private void DatePicker_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char character = Convert.ToChar(e.Text);
            if (char.IsNumber(character) || char.IsPunctuation(character))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Person person = new Person();
                if(maleCheck == false)
                {
                    person.geschlecht = false;
                } else
                {
                    person.geschlecht = true;
                }
                person.vorname = tBox_Vorname.Text;
                person.nachname = tBox_Nachname.Text;
                person.spitzname = tBox_Spitzname.Text;
                person.birthday = date_Birthday.SelectedDate.Value.Date;
                lst_Person.Add(person);
                Save.Savedata(lst_Person, "Bewohner" + ".xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            FileInfo myFile = new FileInfo("Bewohner.xml");
            if (myFile.Exists)
            {
                Load.Loaddata(lst_Person, "Bewohner.xml");
                
            }
            

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            maleCheck = true;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            maleCheck = false;
        }
    }
}