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
        string connectionString;
        SqlConnection sqlConnection;
        private string commandString;
        private SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;

        public CompanyRepository()
        {
            connectionString = @"Server=LAPTOP-BASHAROV\SQLEXPRESS; Database=StockManagementSystemDB; Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
        }

        public DataTable LoadCompanyDataGridView()
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

        public int InsertCompany(Company company)
        {
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
            commandString = @"SELECT * FROM Companys WHERE Name = '" + company.Name + "'";
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
    }
}
