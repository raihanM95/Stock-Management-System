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
    class SearchAndViewRepository
    {
        string connectionString = @"Server=LAPTOP-BASHAROV\SQLEXPRESS; Database=StockManagementSystemDB; Integrated Security=True";
        SqlConnection sqlConnection;

        private string commandString;
        SqlCommand sqlCommand;
        SqlDataAdapter dataAdapter;
        DataTable dataTable;

        public DataTable LoadCompany()
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT * FROM Companys";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            dataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            sqlConnection.Close();

            return dataTable;
        }

        public DataTable LoadCategory()
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT * FROM Categorys";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            dataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            sqlConnection.Close();

            return dataTable;
        }

        public DataTable Search(SearchAndViewModel searchAndViewModel)
        {
            commandString = "";
            if (!String.IsNullOrEmpty(searchAndViewModel.Category))
            {
                commandString = "SELECT I.ItemName, Com.Name As ComapanyName, Cat.Name As CategoryName, S.Quantity,I.ReorderLevel FROM ((( Items As I LEFT OUTER JOIN Companys As Com ON I.CompanyID = Com.ID) LEFT OUTER JOIN Categorys As Cat ON I.CategoryID = Cat.ID) LEFT OUTER JOIN Stocks As S ON I.ID = S.ItemID) WHERE Cat.Name = '"+searchAndViewModel.Category+"' ";
            }
            if (!String.IsNullOrEmpty(searchAndViewModel.Company))
            {
                commandString = "SELECT I.ItemName, Com.Name As ComapanyName, Cat.Name As CategoryName, S.Quantity,I.ReorderLevel FROM ((( Items As I LEFT OUTER JOIN Companys As Com ON I.CompanyID = Com.ID) LEFT OUTER JOIN Categorys As Cat ON I.CategoryID = Cat.ID) LEFT OUTER JOIN Stocks As S ON I.ID = S.ItemID) WHERE Com.Name = '"+searchAndViewModel.Company+"' ";
            }
            if (!String.IsNullOrEmpty(searchAndViewModel.Category) && !String.IsNullOrEmpty(searchAndViewModel.Company))
            {
                commandString = "SELECT I.ItemName, Com.Name As ComapanyName, Cat.Name As CategoryName, S.Quantity,I.ReorderLevel FROM ((( Items As I LEFT OUTER JOIN Companys As Com ON I.CompanyID = Com.ID) LEFT OUTER JOIN Categorys As Cat ON I.CategoryID = Cat.ID) LEFT OUTER JOIN Stocks As S ON I.ID = S.ItemID) WHERE Cat.Name = '"+searchAndViewModel.Category+"' AND Com.Name = '" + searchAndViewModel.Company + "' ";
            }

            if (!String.IsNullOrEmpty(commandString))
            {
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                dataAdapter = new SqlDataAdapter(sqlCommand);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                sqlConnection.Close();
                return dataTable;
            }
            else
            {
                return null;
            }
        }
    }
}
