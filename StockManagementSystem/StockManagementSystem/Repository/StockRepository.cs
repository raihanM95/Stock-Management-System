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
        string connectionString;
        SqlConnection sqlConnection;
        private string commandString;
        private SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
        SqlDataReader reader;

        string reorderLevel;
        string availableQuantity;
        int itemId;

        public StockRepository()
        {
            connectionString = @"Server=DESKTOP-ON380RK\SQLEXPRESS; Database=StockManagementSystemDB; Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
        }

        public DataTable LoadCompany()
        {
            commandString = @"SELECT * FROM Companys";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            sqlConnection.Close();

            return dataTable;
        }

        public DataTable LoadCategory()
        {
            commandString = @"SELECT * FROM Categorys";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            sqlConnection.Close();

            return dataTable;
        }

        public DataTable LoadItem(int companyId, int categoryId)
        {
            commandString = @"SELECT Items.ItemName FROM ((Items LEFT JOIN Companys ON Items.CompanyID = Companys.ID) LEFT JOIN Categorys ON Items.CategoryID = Categorys.ID) WHERE Companys.ID = '" + companyId + "' AND Categorys.ID = '" + categoryId + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            sqlConnection.Close();

            return dataTable;
        }

        public string LoadReorder(Stock stock)
        {
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

        public string LoadQuantity(Stock stock)
        {
            commandString = @"SELECT AvailableQuantity FROM Items WHERE ItemName = '" + stock.ItemName + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                availableQuantity = (reader["AvailableQuantity"]).ToString();
            }

            sqlConnection.Close();

            return availableQuantity;
        }

        public int LoadItemID(Stock stock)
        {
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
            int isExecuted = 0;

            commandString = "INSERT INTO Stocks (ItemID, Quantity, Date, Status) VALUES (" + stock.ItemID + ", " + stock.Quantity + ", '" + stock.Date + "', '" + stock.Status + "')";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            isExecuted = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return isExecuted;
        }

        public int UpdateStock(Stock stock)
        {
            int isExecuted = 0;

            string query = "UPDATE Stocks SET Quantity = '" + stock.Quantity + "' WHERE ID = '" + stock.ID + "'";
            sqlCommand = new SqlCommand(query, sqlConnection);

            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            isExecuted = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return isExecuted;
        }

        public int InsertAvailableQuantity(Item item)
        {
            int isExecuted = 0;

            string query = "UPDATE Items SET AvailableQuantity = '" + item.AvailableQuantity + "' WHERE ItemName = '" + item.ItemName + "'";
            sqlCommand = new SqlCommand(query, sqlConnection);

            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            isExecuted = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return isExecuted;
        }

        public DataTable DisplayStock(Stock stock)
        {
            commandString = @"SELECT * FROM StocksView WHERE ItemName = '" + stock.ItemName + "' ORDER BY Date DESC";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            sqlConnection.Close();

            return dataTable;
        }
    }
}
