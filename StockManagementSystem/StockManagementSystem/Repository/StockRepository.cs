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
    public class StockRepository
    {
        public string connectionString = @"Server=DESKTOP-ON380RK\SQLEXPRESS; Database=StockManagementSystemDB; Integrated Security=True";

        SqlConnection sqlConnection;
        private string commandString;
        private SqlCommand sqlCommand;
        SqlDataReader reader;

        public DataTable LoadCompany()
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT * FROM Companys";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
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

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            sqlConnection.Close();

            return dataTable;
        }

        public DataTable LoadItem(int companyId, int categoryId)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT Items.ItemName FROM ((Items LEFT JOIN Companys ON Items.CompanyID = Companys.ID) LEFT JOIN Categorys ON Items.CategoryID = Categorys.ID) WHERE Companys.ID = '" + companyId + "' AND Categorys.ID = '" + categoryId + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            sqlConnection.Close();

            return dataTable;
        }

        string reorderLevel;
        public string LoadReorder(Stock stock)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT ReorderLevel FROM Items WHERE ItemName = '" + stock.ItemName + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                reorderLevel = (reader["ReorderLevel"]).ToString();
            }

            sqlConnection.Close();

            return reorderLevel;
        }

        string availableQuantity;
        public string LoadQuantity(Stock stock)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT Stocks.Quantity FROM Stocks LEFT JOIN Items ON Stocks.ItemID = Items.ID WHERE ItemName = '" + stock.ItemName + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                availableQuantity = (reader["Quantity"]).ToString();
            }

            sqlConnection.Close();

            return availableQuantity;
        }

        int itemId;
        public int LoadItemID(Stock stock)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT ID FROM Items WHERE ItemName = '" + stock.ItemName + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                itemId = Convert.ToInt32(reader["ID"]);
            }

            sqlConnection.Close();

            return itemId;
        }

        public int StockIn(Stock stock)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = "INSERT INTO Stocks (ItemID, Quantity, Date, Status) VALUES (" + stock.ItemID + ", " + stock.Quantity + ", '" + stock.Date + "', '" + stock.Status + "')";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            int isExecuted = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return isExecuted;
        }

        public int UpdateStock(Stock stock)
        {
            sqlConnection = new SqlConnection(connectionString);
            string query = "UPDATE Stocks SET Quantity = '" + stock.Quantity + "' WHERE ID = '" + stock.ID + "'";
            sqlCommand = new SqlCommand(query, sqlConnection);

            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            int isExecuted = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return isExecuted;
        }

        public DataTable DisplayStock()
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT * FROM StocksView ORDER BY Date DESC";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            sqlConnection.Close();

            return dataTable;
        }
    }
}
