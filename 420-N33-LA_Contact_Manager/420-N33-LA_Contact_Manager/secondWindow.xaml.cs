using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace _420_N33_LA_Contact_Manager
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            InitializeComponent();

            Loaded += SecondWindow_Loaded;

        }

        private void SecondWindow_Loaded(object sender, RoutedEventArgs e)
        {
            FillContacts();
        }
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        private void goBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {

            Update();
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

                CmdString = "SELECT FName, LName, Phone, Email FROM Contacts WHERE ID = " + id;

                SqlCommand cmd = new SqlCommand(CmdString, con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable("ContactDB");

                sda.Fill(dt);
                lvDataBinding.ItemsSource = dt.DefaultView;


            }

        }

        private void Update()
        {
            string ConString = ConfigurationManager.ConnectionStrings["ContactsConnectionString"].ConnectionString;

            string CmdString = string.Empty;

            using (SqlConnection con = new SqlConnection(ConString))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE ContactDB SET FName=@FName, LName=@LName, Phone=@Phone, Email=@Email" + "WHERE ID=@ID", con))
                {

                    cmd.Parameters.AddWithValue("@FName", txtFName);
                    cmd.Parameters.AddWithValue("@LName", txtLName);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone);
                    cmd.Parameters.AddWithValue("@Email", txtEmail);
                    int rows = cmd.ExecuteNonQuery();
                    con.Close();
                }







            }
        }

    }
}
