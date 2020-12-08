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
        private void contact_Click(object sender, RoutedEventArgs e)
        {
            SubWindow subWindow = new SubWindow();
            subWindow.Show();
        }

        //export contact to csv file
        private void export_Click(object sender, RoutedEventArgs e)
        {
            WriteToXls(DataTable2CSV(myDataGrid, ","));

        }

        //import contact from cvs file
        private void import_Clck(object sender, RoutedEventArgs e)
        {

        }

        public static string ContactToCSV(, string separator = ",")
        {

        }

        private string WriteToXls(string dataToWrite)
        {

        }

    }
}
