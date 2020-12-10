﻿using System;
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
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            InitializeComponent();
            
            Loaded += SecondWindow_Loaded ;
        }

        private void SecondWindow_Loaded(object sender, RoutedEventArgs e)
        {
            FillContacts();
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
            string ConString = ConfigurationManager.ConnectionStrings["ContactsConnectionString"].ConnectionString;

            string CmdString = string.Empty;

            using (SqlConnection con = new SqlConnection(ConString))

            {

               CmdString = $"update [dbo].[Contacts] set FName=@FName LName=@LName where ContactID= " + id;



            }
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

                CmdString = "SELECT FName, LName FROM Contacts WHERE ContactID = "+ id;

                SqlCommand cmd = new SqlCommand(CmdString, con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable("Contacts");

                sda.Fill(dt);
                lvDataBinding.ItemsSource = dt.DefaultView;


            }

        }

    }
}
