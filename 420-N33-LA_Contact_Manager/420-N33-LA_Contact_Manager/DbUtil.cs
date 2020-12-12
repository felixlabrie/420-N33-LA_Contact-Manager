using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace _420_N33_LA_Contact_Manager
{
    class DbUtil
    {
        //DbUtil() { }

        //private static readonly Lazy<DbUtil> onlyinstance = new Lazy<DbUtil>(() => new DbUtil());

        //private static DbUtil Instance => onlyinstance.Value;

        // Retrieve all contacts in the Db
        public static void ViewRecords()
        {
            // Create connection
            var con = new SqlConnection(@"data source=localhost\SQLEXPRESS;database = ContactDB;Trusted_Connection=True");
            con.Open();
            
            // Code stack to list all items
            SqlCommand listall = new SqlCommand("SELECT Id, FName, LName, Email, Phone FROM Contacts", con);
            SqlDataReader sdrListAll = listall.ExecuteReader();

            while (sdrListAll.Read())
            {
                // Display Record(s)
                Console.WriteLine(sdrListAll["Id"] + " " + sdrListAll["FName"] + " " + sdrListAll["LName"] + " " + sdrListAll["Email"] + " " + sdrListAll["Phone"]);
            }
            con.Close();
        }

        // Edit record
        public static void EditRecords(int id, string FName, string LName, string Email, string Phone)
        {
            // Create connection
            var con = new SqlConnection(@"data source=localhost\SQLEXPRESS;database = ContactDB;Trusted_Connection=True");
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
        public static void DeleteRecords(int id)
        {
            // Create connection
            var con = new SqlConnection(@"data source=localhost\SQLEXPRESS;database = ContactDB;Trusted_Connection=True");
            con.Open();

            // Code stack to list all items
            SqlCommand listall = new SqlCommand("DELETE FROM Contacts WHERE id = @ID;", con);

            // Set all parameters
            listall.Parameters.AddWithValue("@ID", id);

            listall.ExecuteNonQuery();

            con.Close();
        }
        
        // Create new record in Database
        public static void CreateRecords(string FName, string LName, string Email, string Phone)
        {
            // Create connection
            var con = new SqlConnection(@"data source=localhost\SQLEXPRESS;database = ContactDB;Trusted_Connection=True");
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
            // Create connection
            var con = new SqlConnection(@"data source=localhost\SQLEXPRESS;database = ContactDB;Trusted_Connection=True");
            con.Open();

            // Query
            SqlCommand list = new SqlCommand("SELECT Id, FName, LName FROM Contacts", con);

            SqlDataReader reader = list.ExecuteReader();

            List<User> users = new List<User>();

            while (reader.Read())
            {
                users.Add(new User() {Id = (int)reader["Id"], FName = (string)reader["FName"], LName = (string)reader["LName"] });
            }

          
            con.Close();

            return users;

        }

    }
}
