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
    public class CompanyRepository
    {

        string connectionString = @"Server=DESKTOP-ON380RK\SQLEXPRESS; Database=StockManagementSystemDB; Integrated Security=True";
        SqlConnection sqlConnection;

        private string commandString;
        SqlCommand sqlCommand;

        public DataTable LoadCompanyDataGridView()
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT * FROM Companys";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            sqlConnection.Close();

            return dataTable;
        }

        public int InsertCompany(Company company)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"INSERT INTO Companys (Name) VALUES ('" + company.Name + "')";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            int isExecuted = 0;
            isExecuted = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return isExecuted;
        }

        public int UpdateCompany(Company company)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = "UPDATE Companys SET Name = '" + company.Name + "' WHERE ID = " + company.ID + "";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            
            sqlConnection.Open();

            int isExecuted = 0;

            isExecuted = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return isExecuted;
        }

        public bool ValidationCheck(Company company)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT * FROM Companys WHERE Name = '" + company.Name + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            bool isExist = false;
            if (dataTable.Rows.Count > 0)
            {
                isExist = true;
            }

            sqlConnection.Close();

            return isExist;
        }
    }
}
