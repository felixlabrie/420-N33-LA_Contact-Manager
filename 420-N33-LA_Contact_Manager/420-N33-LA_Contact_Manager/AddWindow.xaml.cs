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
using System.Windows.Shapes;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace _420_N33_LA_Contact_Manager
{
    /// <summary>
    /// Interaction logic for secondWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();

            Loaded += AddWindow_Loaded;
        }

        private void AddWindow_Loaded(object sender, RoutedEventArgs e)
        {
            FillContacts();
        }
        private int id;
        public int ContactID
        {
            get { return id; }
            set { id = value; }
        }
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            Add();
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void FillContacts()

        {

            string ConString = ConfigurationManager.ConnectionStrings["ContactsConnectionString"].ConnectionString;

            string CmdString = string.Empty;

            using (SqlConnection con = new SqlConnection(ConString))

            {

                CmdString = "SELECT FName, LName FROM Contacts WHERE ID = " + id;

                SqlCommand cmd = new SqlCommand(CmdString, con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable("Contacts");




            }

        }
        private void Add()
        {
            string ConString = ConfigurationManager.ConnectionStrings["ContactsConnectionString"].ConnectionString;

            string CmdString = string.Empty;

            using (SqlConnection con = new SqlConnection(ConString))

            {
                con.Open();
      
                using (SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Contacts](FName, LName, Phone, Email) VALUES (@FName, @LName, @Phone, @Email)", con))
                {

                    cmd.Parameters.AddWithValue("@FName", txtFName.Text);
                    cmd.Parameters.AddWithValue("@LName", txtLName.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();

                }







            }
        }

    }
}
