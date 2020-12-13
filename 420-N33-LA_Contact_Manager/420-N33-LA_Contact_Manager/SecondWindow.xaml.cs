using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace _420_N33_LA_Contact_Manager
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        DbUtil dbContext = new DbUtil();
        public SecondWindow(User user)
        {
            InitializeComponent();
            Id.Text = user.Id.ToString();
            txtFName.Text = user.FName;
            txtLName.Text = user.LName;
            txtEmail.Text = user.Email;
            txtPhone.Text = user.Phone.ToString();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            string Fname = txtFName.Text;
            string Lname = txtLName.Text;
            string email = txtEmail.Text;
            string phoneNumber = txtPhone.Text;
            int recordId = Convert.ToInt32(Id.Text);

            if (string.IsNullOrEmpty(Fname) || string.IsNullOrEmpty(Lname)
                || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Please fill all fields.!");
                return;
            }
            Regex phone = new Regex(@"[a-zA-Z]");
            if (phone.IsMatch(txtPhone.Text))
            {
                MessageBox.Show("Phone number cannot include letters, try again");
                return;
            }
            dbContext.Update(recordId, Fname, Lname, email, phoneNumber);
        }

        private void Update_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Hide();
        }
    }
}

