using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace _420_N33_LA_Contact_Manager
{
    class DbUtil
    {
        // Create connection
        private static SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=ContactDB;Integrated Security=True");
        private static DataSet ds = new DataSet();
        private static SqlDataAdapter adapter;
        public DbUtil()
        {

        }

        // Retrieve all contacts in the Db
        public static DataSet ViewRecords()
        {

            con.Open();
            // Code stack to list all items
            adapter = new SqlDataAdapter("SELECT Id, FName, LName, Email, Phone FROM Contacts", con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Contacts");

            con.Close();
            return ds;
        }

        // Edit record
        public static void EditRecords(int id, string FName, string LName, string Email, string Phone)
        {
            con.Open();

            // Code stack to update the record
            SqlCommand listall = new SqlCommand("UPDATE Contacts SET FName = @FName, LName = @LName, Email = @Email, Phone = @Phone WHERE id = @ID;", con);

            // Set all parameters
            listall.Parameters.AddWithValue("@ID", id);
            listall.Parameters.AddWithValue("@FName", FName);
            listall.Parameters.AddWithValue("@LName", LName);
            listall.Parameters.AddWithValue("@Email", Email);
            listall.Parameters.AddWithValue("@Phone", Phone);

            listall.ExecuteNonQuery();

            con.Close();
        }

        // Delete the record(s)
        public static void DeleteRecord(int id)
        {
            con.Open();
            try
            {
                // Code stack to list all items
                SqlCommand listall = new SqlCommand("DELETE FROM Contacts WHERE id = @ID;", con);

                // Set all parameters
                listall.Parameters.AddWithValue("@ID", id);

                listall.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not Delete the contact");
            }
            finally
            {
                con.Close();
            }
        }

        // Create new record in Database
        public static void CreateRecords(string FName, string LName, string Email, string Phone)
        {
            con.Open();

            // Code stack to create item
            SqlCommand listall = new SqlCommand("INSERT INTO Contacts(FName, LName, Email, Phone) VALUES(@FName, @LName, @Email, @Phone);", con);

            // Set all parameters
            listall.Parameters.AddWithValue("@FName", FName);
            listall.Parameters.AddWithValue("@LName", LName);
            listall.Parameters.AddWithValue("@Email", Email);
            listall.Parameters.AddWithValue("@Phone", Phone);

            listall.ExecuteNonQuery();

            con.Close();
        }

        // Populate ListBox
        public static List<User> FillData()
        {
            con.Open();

            // Query
            SqlCommand list = new SqlCommand("SELECT Id, FName, LName FROM Contacts", con);

            SqlDataReader reader = list.ExecuteReader();

            List<User> users = new List<User>();

            while (reader.Read())
            {
                users.Add(new User() { Id = (int)reader["Id"], FName = (string)reader["FName"], LName = (string)reader["LName"] });
            }


            con.Close();

            return users;

        }

        public bool Add(string FName, string LName, string email, string Phone)
        {
            try
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO Contacts(FName, LName, Phone, Email) VALUES (@FName, @LName, @Phone, @Email)", con))
                {
                    cmd.Parameters.AddWithValue("@FName", FName);
                    cmd.Parameters.AddWithValue("@LName", LName);
                    cmd.Parameters.AddWithValue("@Phone", Phone);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not add contact");
                con.Close();
                return false;
            }
        }

        public void Update(int Id, string FName, string LName, string email, string Phone)
        {
            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Contacts SET FName=@FName, LName=@LName, Phone=@Phone, Email=@Email WHERE Id = " + Id, con))
                {

                    cmd.Parameters.AddWithValue("@FName", FName);
                    cmd.Parameters.AddWithValue("@LName", LName);
                    cmd.Parameters.AddWithValue("@Phone", Phone);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Updated Successfully..!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not Update contact");
            }
            finally
            {
                con.Close();
            }

        }
    }
}

