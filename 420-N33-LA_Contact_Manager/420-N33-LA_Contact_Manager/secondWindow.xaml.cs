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
    public partial class secondWindow : Window
    {
        public secondWindow()
        {
            InitializeComponent();
        }

        private int id;
        public int ContactID
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
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void FillContacts()

        {
            
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

            string CmdString = string.Empty;

            using (SqlConnection con = new SqlConnection(ConString))

            {

                CmdString = "SELECT fname, lname, hire_date FROM Contacts WHERE contact_id = "+ id;

                SqlCommand cmd = new SqlCommand(CmdString, con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable("Contacts");

                sda.Fill(dt);

                

            }

        }

    }
}
