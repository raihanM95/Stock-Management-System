using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace StockManagementSystem
{
    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string connectionString = @"Server=DESKTOP-ON380RK\SQLEXPRESS; Database=StockManagementSystemDB; Integrated Security=True";

        public string Message = "";

        public int LogIn()
        {
            int count = 0;

            try
            {
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = connectionString;

                SqlCommand sqlCommand = new SqlCommand();
                string commandString = "SELECT * FROM [dbo].[User] WHERE UserName = '" + Username + "' and Password = '" + Password + "'";
                sqlCommand.CommandText = commandString;
                sqlCommand.Connection = sqlConnection;

                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();

                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                dataAdapter.Fill(dataTable);
                count = Convert.ToInt32(dataTable.Rows.Count.ToString());

                sqlConnection.Close();

                if (count == 0)
                {
                    Message = "Username or password doesn't match";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return count;
        }
    }
}
