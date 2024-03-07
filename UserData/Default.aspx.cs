using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserData
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {            
            string connectionString = "server=localhost;database=guestbook;user=root;password=Vivek@7859;";
           
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "CREATE TABLE IF NOT EXISTS UserInfo (\r\n    Id INT AUTO_INCREMENT PRIMARY KEY,\r\n    Name VARCHAR(255) NOT NULL,\r\n    Age INT\r\n);" +
                 "INSERT INTO UserInfo (Name, Age) VALUES (@Name, @Age);";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", txtName.Text);
                    command.Parameters.AddWithValue("@Age", Convert.ToInt32(txtAge.Text));

                    command.ExecuteNonQuery();
                }
            }

            Response.Write("Data saved successfully!");
        }
    }
}