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

        string connectionString = @"Server=LAPTOP-BASHAROV\SQLEXPRESS; Database=StockManagementSystemDB; Integrated Security=True";
        SqlConnection sqlConnection;

        private string commandString;
        SqlCommand sqlCommand;
        // sqlConnection = new SqlConnection(connectionString);

        public DataTable LoadCompanyDataGridView()
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT * FROM Companys";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            

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

        public int InsertCompany(Company company)
        {
            sqlConnection = new SqlConnection(connectionString);

            commandString = @"INSERT INTO Companys  ( Name ) VALUES ('" + company.Name + "')";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            

            sqlConnection.Open();

            int insert = 0;

            insert = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return insert;
        }

        public int UpdateCompany(Company company)
        {
            sqlConnection = new SqlConnection(connectionString);

            commandString = "UPDATE Companys SET Name =  '" + company.Name + "' WHERE ID = " + company.ID + "";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            

            sqlConnection.Open();

            int update = 0;

            update = sqlCommand.ExecuteNonQuery();

            

            sqlConnection.Close();
            return update;

        }



        public bool ValidationCheck(Company company)
        {
            sqlConnection = new SqlConnection(connectionString);
            if (!String.IsNullOrEmpty(company.Name))
            {
                commandString = @"SELECT * FROM Companys WHERE Name = '" + company.Name + "'";
            }


            sqlCommand = new SqlCommand(commandString, sqlConnection);
          

            sqlConnection.Open();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            bool validationCheck = false;
            if (dataTable.Rows.Count > 0)
            {
                validationCheck = true;

            }

            sqlConnection.Close();


            return validationCheck;
        }
    }
}
