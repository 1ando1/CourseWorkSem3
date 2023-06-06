using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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

namespace Lesson_10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Contact> contacts = null;
        public MainWindow()
        {
            InitializeComponent();

            contacts = new ObservableCollection<Contact>();
            {

            };

            ListBox.ItemsSource = contacts;
            ListBox.DisplayMemberPath = nameof(Contact.Info);

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            contacts.Add(new Contact() { Name = Name.Text, Surname = Surname.Text, PhoneNumber = Phone.Text, Country = Country.Text, IsImportant = Important.IsChecked.Value });
        }

        private void Remvoe_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox.SelectedItem != null)
                contacts.Remove(ListBox.SelectedItem as Contact);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox.SelectedItem != null)
            {
                Contact c = ListBox.SelectedItem as Contact;
                c.Name = Name.Text;
                c.Surname = Surname.Text;
                c.PhoneNumber = Phone.Text;
                c.Country = Country.Text;
                c.IsImportant = Important.IsChecked.Value;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "(.txt)|*.txt";
            if (save.ShowDialog() == true)
            {
                Contact cont = ListBox.SelectedItem as Contact;
                File.WriteAllText(save.FileName, cont.Info);
            }
        }

        private void SortName_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox.Items != null)
            {
                ListBox.ItemsSource = contacts.OrderBy(o => o.Name).ToList();
                ListBox.Items.Refresh();
            }
        }

        private void SortSurname_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox.Items != null)
            {
                ListBox.ItemsSource = contacts.OrderBy(o => o.Surname).ToList();
                ListBox.Items.Refresh();
            }
        }

        private void SortCountry_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox.Items != null)
            {
                ListBox.ItemsSource = contacts.OrderBy(o => o.Country).ToList();
                ListBox.Items.Refresh();
            }
        }
    }
}
