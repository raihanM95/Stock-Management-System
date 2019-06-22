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
        string connectionString = @"Server=LAPTOP-BASHAROV\SQLEXPRESS; Database=StockManagementSystemDB; Integrated Security=True";
        SqlConnection sqlConnection; 

        private string commandString;
        SqlCommand sqlCommand;

        public DataTable LoadCategoryDataGridView()
        {
            sqlConnection = new SqlConnection(connectionString);

            commandString = @"SELECT * FROM Categorys";
            sqlCommand = new SqlCommand(commandString,sqlConnection);
                

            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataTable dataTable = new DataTable();
            DataTable dataTableReturn = new DataTable();
            sqlDataAdapter.Fill(dataTable);


            if (dataTable.Rows.Count > 0)
            {
                dataTableReturn = dataTable;
            }



            sqlConnection.Close();

            return dataTableReturn;
           

        }

        public bool ValidationCheck(Category category)
        {


            if (!String.IsNullOrEmpty(category.Name))
            {
                commandString = @"SELECT * FROM Categorys WHERE Name = '" + category.Name + "'";
            }

            bool isExist = false;
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                isExist = true;
            }

                sqlConnection.Close();


            return isExist;
        }

        public int UpdateCategory(Category category)
        {
           
                commandString = "UPDATE Categorys SET Name =  '" + category.Name + "' WHERE ID = " + category.ID + "";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                int isExecuted = 0;

                isExecuted = sqlCommand.ExecuteNonQuery();

               

                sqlConnection.Close();

            return isExecuted;

        }

        public int InsertCategory(Category category)
        {
           
                commandString = @"INSERT INTO Categorys  ( Name ) VALUES ('" + category.Name + "')";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                int isExecuted = 0;

                isExecuted = sqlCommand.ExecuteNonQuery();
            
                sqlConnection.Close();

            return isExecuted;

        }
    }
}
