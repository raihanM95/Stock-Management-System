using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagementSystem.Models;

namespace StockManagementSystem
{
    public partial class CompanySetupForm : Form
    {
        string connectionString = @"Server=LAPTOP-BASHAROV\SQLEXPRESS; Database=StockManagementSystemDB; Integrated Security=True";
        SqlConnection sqlConnection;

        private string commandString;
        SqlCommand sqlCommand;

        public Company company ;


        public CompanySetupForm()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(connectionString);
            company = new Company();
        }

        private void CompanySetupForm_Load(object sender, EventArgs e)
        {
            LoadCompanyDataGridView();
        }


        private void LoadCompanyDataGridView()
        {
            try
            {
                commandString = @"SELECT * FROM Companys";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);


                if (dataTable.Rows.Count > 0)
                {
                    companyDataGridView.DataSource = dataTable;
                }



                sqlConnection.Close();
            }


            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = new DataTable();
                if (SaveButton.Text.Equals("Save"))
                {
                    company.Name = nameTextBox.Text;
                    if (String.IsNullOrEmpty(company.Name))
                    {
                        MessageBox.Show("Category Name Can not be Empty!");
                        return;
                    }
                    dataTable = ValidationCheck(company);
                    if (dataTable.Rows.Count > 0)
                    {
                        MessageBox.Show("Company  [ " + company.Name + " ]  alreday Exist!!");
                        return;

                    }
                    InsertCompany(company);

                }
                else
                {

                    company.Name = nameTextBox.Text;
                    UpdateCompany(company);
                    SaveButton.Text = "Save";
                }
                nameTextBox.Clear();
                LoadCompanyDataGridView();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }


        private void InsertCompany(Company company)
        {
            try
            {
                commandString = @"INSERT INTO Companys  ( Name ) VALUES ('" + company.Name + "')";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                int isExecuted = 0;

                isExecuted = sqlCommand.ExecuteNonQuery();

                if (isExecuted > 0)
                {
                    MessageBox.Show("Saved Succesfully");
                }
                else
                {
                    MessageBox.Show("Sorry! Saved Failed");
                }

                sqlConnection.Close();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        private void UpdateCompany(Company company )
        {
            try
            {
                commandString = "UPDATE Companys SET Name =  '" + company.Name + "' WHERE ID = " + company.ID + "";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                int isExecuted = 0;

                isExecuted = sqlCommand.ExecuteNonQuery();

                if (isExecuted > 0)
                {
                    MessageBox.Show("Updated Succesfully");
                }
                else
                {
                    MessageBox.Show("Sorry! Updated Failed");
                }

                sqlConnection.Close();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

       

        private DataTable ValidationCheck(Company company )
        {

            if (!String.IsNullOrEmpty(company.Name))
            {
                commandString = @"SELECT * FROM Companys WHERE Name = '" + company.Name + "'";
            }


            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            sqlConnection.Close();


            return dataTable;
        }

        private void companyDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                if (companyDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    companyDataGridView.CurrentRow.Selected = true;
                    nameTextBox.Text = companyDataGridView.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn_Name"].FormattedValue.ToString();
                    company.ID = Convert.ToInt32(companyDataGridView.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn_ID"].FormattedValue);
                    SaveButton.Text = "Update";

                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        private void companyDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            companyDataGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        
    }
}
