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

namespace _420_N33_LA_Contact_Manager
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void save_Click(object sender, RoutedEventArgs e)
        {

        }
        


        //when clicking on any contact, it opens a new window with the contacts information
        private void edit_Click(object sender, RoutedEventArgs e)
        {
            SecondWindow second = new SecondWindow();
            second.ContactID = 1;
            second.Show();
            this.Close();
        }

        //export contact to csv file
        private void export_Click(object sender, RoutedEventArgs e)
        {
           // ContactToCSV();

        }

        //import contact from cvs file
        private void import_Click(object sender, RoutedEventArgs e)
        {
            string path = @"contacts.csv";
            string st = File.ReadAllText(path);
        }

        
        public static void ContactToCSV(String name, string lastName, int phoneNumber, string email, string filepath)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filepath, true))
                {
                    file.WriteLine(name + ", " + lastName + ", " + phoneNumber + ", " + email);
                    MessageBox.Show("Data has been sucessfully exported to CSV file", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            } catch(Exception ex)
            {
                throw new ApplicationException("Error", ex);
            }
        }
        

    }
}
