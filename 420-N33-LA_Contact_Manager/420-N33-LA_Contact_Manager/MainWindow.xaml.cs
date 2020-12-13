using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
        DbUtil dbContext = new DbUtil();
        public MainWindow()
        {
            InitializeComponent();
            UpdateGrid();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            AddWindow add = new AddWindow();
            add.Show();
            this.Close();
        }
        private void UpdateGrid()
        {
            var ds = DbUtil.ViewRecords();
            dgContacts.ItemsSource = ds.Tables["Contacts"].DefaultView;
        }
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (dgContacts.SelectedItem == null)
            {
                MessageBox.Show("Please select a row.!");
                return;
            }
            else
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    var row = (DataRowView)dgContacts.SelectedItem;
                    var id = Convert.ToInt32(row["Id"]);

                    DbUtil.DeleteRecord(id);
                    MessageBox.Show("Record Deleted Successfully..!");
                    UpdateGrid();
                }
            }
        }
        //when clicking on any contact, it opens a new window with the contacts information
        private void edit_Click(object sender, RoutedEventArgs e)
        {
            User record = new User();
            if (dgContacts.SelectedItem == null)
            {
                MessageBox.Show("Please select a row.!");
                return;
            }
            else
            {
                var row = (DataRowView)dgContacts.SelectedItem;
                record.Id = Convert.ToInt32(row["Id"]);
                record.FName = row["FName"].ToString();
                record.LName = row["LName"].ToString();
                record.Email = row["Email"].ToString();
                record.Phone = Convert.ToInt32(row["Phone"]);
            }
            SecondWindow second = new SecondWindow(record);
            second.Show();
            this.Close();
        }

        //export contact to csv file
        private void export_Click(object sender, RoutedEventArgs e)
        {
            ContactToCSV();

        }

        //import contact from cvs file
        private void import_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            List<int> list = new List<int>();
            openFileDialog.DefaultExt = ".csv";
            if (openFileDialog.ShowDialog() == true)
            {
                string path = openFileDialog.FileName;
                var dataRows = File.ReadAllLines(path);

                for (int i = 0; i < dataRows.Length; i++)
                {
                    var columns = dataRows[i].Split(',');

                    try
                    {
                        string fname = columns[0];
                        string Lname = columns[1];
                        string Phone = columns[2];
                        string email = columns[3];
                        bool result = dbContext.Add(fname, Lname, email, Phone);
                        if (!result)
                            list.Add(i + 1);

                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                }
                if (list.Count > 0)
                {
                    string text = "System could not import following rows ";
                    foreach (var item in list)
                    {
                        text += item + " ";
                    }
                    MessageBox.Show(text);
                }
                else
                {
                    MessageBox.Show("Import Successfully..!");
                }
                UpdateGrid();
            }
        }


        public void ContactToCSV()
        {
            try
            {
                this.dgContacts.SelectAllCells();
                this.dgContacts.ClipboardCopyMode = DataGridClipboardCopyMode.ExcludeHeader;
                ApplicationCommands.Copy.Execute(null, this.dgContacts);
                this.dgContacts.UnselectAllCells();
                String result = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
                Clipboard.Clear();
                StreamWriter sw = new StreamWriter("contacts.csv");
                sw.WriteLine(result);
                sw.Close();
                Process.Start("contacts.csv");

                MessageBox.Show("Data Exported Successfully..!");
            }
            catch (Exception ex)
            { }
        }

    }
}
