using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.Repository
{
    public class UserRepository
    {
        string connectionString;
        SqlConnection sqlConnection;
        private string commandString;
        private SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;

        public UserRepository()
        {
            connectionString = @"Server=LAPTOP-BASHAROV\SQLEXPRESS; Database=StockManagementSystemDB; Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
        }

        public int LogIn(User user)
        {
            int count = 0;

            commandString = "SELECT * FROM [dbo].[User] WHERE UserName = '" + user.Username + "' and Password = '" + user.Password + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            sqlCommand.ExecuteNonQuery();

            dataTable = new DataTable();
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);

            count = Convert.ToInt32(dataTable.Rows.Count.ToString());

            sqlConnection.Close();
            
            return count;
        }
    }
}
