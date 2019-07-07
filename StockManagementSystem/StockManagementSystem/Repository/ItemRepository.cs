using StockManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.Repository
{
    public class ItemRepository
    {
        string connectionString;
        SqlConnection sqlConnection;
        private string commandString;
        private SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;

        public ItemRepository()
        {
            connectionString = @"Server=DESKTOP-ON380RK\SQLEXPRESS; Database=StockManagementSystemDB; Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
        }

        public DataTable LoadCategory()
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

        public DataTable LoadCompany()
        {
            commandString = @"SELECT * FROM Companys";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            sqlConnection.Close();

            return dataTable;
        }

        public int ItemInsert(Item item)
        {
            int isExecuted = 0;

            commandString = @"INSERT INTO Items VALUES ('" + item.ItemName + "', " + item.CategoryID + " ," + item.CompanyID + ", " + item.ReorderLevel + ", 0)";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            isExecuted = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return isExecuted;
        }

        public bool IsDuplicate(Item item)
        {
            bool isDuplicate = false;

            commandString = @"SELECT ID FROM Items WHERE ItemName = '" + item.ItemName + "' AND CategoryID = " + item.CategoryID + " AND CompanyID = " + item.CompanyID;
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                isDuplicate = true;
            }

            sqlConnection.Close();

            return isDuplicate;
        }

        public DataTable Search(Item item)
        {
            commandString = "";
            if (String.IsNullOrEmpty(item.Category))
            {
                commandString = @"SELECT I.ItemName, I.ReorderLevel, I.AvailableQuantity, Com.Name As Company, Cat.Name As Category
                                  FROM ((Items As I
                                  LEFT OUTER JOIN Companys As Com ON I.CompanyID = Com.ID)
                                  LEFT OUTER JOIN Categorys As Cat ON I.CategoryID = Cat.ID)
                                  WHERE Com.Name = '" + item.Company + "'";
            }

            if (String.IsNullOrEmpty(item.Company))
            {
                commandString = @"SELECT I.ItemName, I.ReorderLevel, I.AvailableQuantity, Com.Name As Company, Cat.Name As Category
                                  FROM ((Items As I
                                  LEFT OUTER JOIN Companys As Com ON I.CompanyID = Com.ID)
                                  LEFT OUTER JOIN Categorys As Cat ON I.CategoryID = Cat.ID)
                                  WHERE Cat.Name = '" + item.Category + "'";
            }

            if (!String.IsNullOrEmpty(item.Category) && !String.IsNullOrEmpty(item.Company))
            {
                commandString = @"SELECT I.ItemName, I.ReorderLevel, I.AvailableQuantity, Com.Name As Company, Cat.Name As Category
                                  FROM ((Items As I
                                  LEFT OUTER JOIN Companys As Com ON I.CompanyID = Com.ID)
                                  LEFT OUTER JOIN Categorys As Cat ON I.CategoryID = Cat.ID)
                                  WHERE Cat.Name = '" + item.Category + "' AND Com.Name = '" + item.Company + "'";
            }

            if (!String.IsNullOrEmpty(commandString))
            {
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

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
