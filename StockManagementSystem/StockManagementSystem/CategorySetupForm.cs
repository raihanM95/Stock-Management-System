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
    public partial class CategorySetupForm : Form
    {
        string connectionString = @"Server=LAPTOP-BASHAROV\SQLEXPRESS; Database=StockManagementSystemDB; Integrated Security=True";
        SqlConnection sqlConnection;

        private string commandString ;
        SqlCommand sqlCommand;

        public Category category; 

        public CategorySetupForm()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(connectionString);
            category = new Category();
            
        }

        private void CategorySetupForm_Load(object sender, EventArgs e)
        {
            LoadCategoryDataGridView();
        }

        private void LoadCategoryDataGridView()
        {
            try
            {
                commandString = @"SELECT * FROM Categorys";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);


                if (dataTable.Rows.Count > 0)
                {
                    categoryDataGridView.DataSource = dataTable;
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
                    category.Name = nameTextBox.Text;
                    if (String.IsNullOrEmpty(category.Name))
                    {
                        MessageBox.Show("Category Name Can not be Empty!");
                        return;
                    }
                    dataTable = ValidationCheck(category);
                    if (dataTable.Rows.Count > 0)
                    {
                        MessageBox.Show("Category  [ " + category.Name + " ]  alreday Exist!!");
                        return;

                    }
                    InsertCategory(category);


                }
                else
                {
                    
                    category.Name = nameTextBox.Text;
                    UpdateCategory(category);
                    SaveButton.Text = "Save";
                }
                nameTextBox.Clear();
                LoadCategoryDataGridView();

            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        private void InsertCategory(Category category)
        {
            try
            {
                commandString = @"INSERT INTO Categorys  ( Name ) VALUES ('" + category.Name + "')";
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

        private void UpdateCategory(Category category)
        {
            try
            {
                commandString = "UPDATE Categorys SET Name =  '" + category.Name + "' WHERE ID = " + category.ID + "";
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

        

        private DataTable ValidationCheck(Category category)
        {
            
            if (!String.IsNullOrEmpty(category.Name))
            {
                commandString = @"SELECT * FROM Categorys WHERE Name = '"+category.Name+"'";
            }

            
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            sqlConnection.Close();

            
            return dataTable;
        }

        private void categoryDataGridView_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (categoryDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    categoryDataGridView.CurrentRow.Selected = true;
                    nameTextBox.Text = categoryDataGridView.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn_Name"].FormattedValue.ToString();
                    category.ID = Convert.ToInt32(categoryDataGridView.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn_ID"].FormattedValue);
                    SaveButton.Text = "Update";

                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void categoryDataGridView_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            categoryDataGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
    }
}
