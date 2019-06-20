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
            LoadDisplayGridView();
        }

        private void LoadDisplayGridView()
        {
            commandString = @"SELECT * FROM Categorys";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);


            if (dataTable.Rows.Count > 0)
            {
                displayDataGridView.DataSource = dataTable;
            }



            sqlConnection.Close();
        }

        private void displayDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            displayDataGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            category.Name = nameTextBox.Text;
            InsertCategory(category);
            LoadDisplayGridView();
            nameTextBox.Clear();

        }
       

        private void InsertCategory(Category category)
        {
            commandString = @"INSERT INTO Categorys  ( Name ) VALUES ('"+category.Name+"')";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            int isExecuted = 0;

            isExecuted = sqlCommand.ExecuteNonQuery();

            if (isExecuted > 0)
            {
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Not Saved");
            }

            sqlConnection.Close();
        }

        private void displayDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (displayDataGridView.Rows[e.RowIndex].Cells[0].Value != null)
            //{
            //    displayDataGridView.CurrentRow.Selected = true;
            //    nameTextBox.Text = displayDataGridView.Rows[e.RowIndex].Cells["category.Name"].FormattedValue.ToString();
            //    // nameTextBox.Text = displayDataGridView.CurrentRow.Cells[category.Name].Value.ToString();
            //}
        }
    }
}
