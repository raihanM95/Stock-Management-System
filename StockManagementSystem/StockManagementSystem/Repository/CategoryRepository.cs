using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Models;

namespace StockManagementSystem.Repository
{
    public class CategoryRepository
    {
        string connectionString;
        SqlConnection sqlConnection;
        private string commandString;
        private SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;

        public CategoryRepository()
        {
            connectionString = @"Server=LAPTOP-BASHAROV\SQLEXPRESS; Database=StockManagementSystemDB; Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
        }

        public DataTable LoadCategoryDataGridView()
        {
            commandString = @"SELECT * FROM Categorys";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            
            sqlConnection.Open();

            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            sqlConnection.Close();

            return dataTable;
        }

        public bool ValidationCheck(Category category)
        {
            commandString = @"SELECT * FROM Categorys WHERE Name = '" + category.Name + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            bool isExist = false;
            if (dataTable.Rows.Count > 0)
            {
                isExist = true;
            }

            sqlConnection.Close();

            return isExist;
        }

        public int InsertCategory(Category category)
        {
            commandString = @"INSERT INTO Categorys (Name) VALUES ('" + category.Name + "')";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            int isExecuted = 0;

            isExecuted = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return isExecuted;
        }

        public int UpdateCategory(Category category)
        {
            commandString = "UPDATE Categorys SET Name = '" + category.Name + "' WHERE ID = " + category.ID + "";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            int isExecuted = 0;

            isExecuted = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return isExecuted;
        }
    }
}
