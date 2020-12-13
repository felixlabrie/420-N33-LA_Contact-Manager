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
using System.Text.RegularExpressions;

namespace _420_N33_LA_Contact_Manager
{
    /// <summary>
    /// Interaction logic for secondWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        DbUtil dbContext = new DbUtil();
        public AddWindow()
        {
            InitializeComponent();

        }
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            string Fname = txtFName.Text;
            string Lname = txtLName.Text;
            string email = txtEmail.Text;
            string phoneNumber = txtPhone.Text;

            if (string.IsNullOrEmpty(Fname) || string.IsNullOrEmpty(Lname)
                || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Please fill all fields");
                return;
            }
            Regex phone = new Regex(@"[a-zA-Z]");
            if (phone.IsMatch(phoneNumber))
            {
                MessageBox.Show("Phone number cannot include letters");
                return;
            }
            var res = dbContext.Add(Fname, Lname, email, phoneNumber);
            if (res)
                MessageBox.Show("Record Added Successfully");
            txtFName.Text = string.Empty;
            txtLName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;



            MainWindow main = new MainWindow();
            main.Show();
            this.Hide();
        }

        private void AddNew_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Hide();
        }
    }
}


