using StockManagementSystem.Models;
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

namespace StockManagementSystem
{
    public partial class StockInForm : Form
    {
        public string connectionString = @"Server=DESKTOP-ON380RK\SQLEXPRESS; Database=StockManagementSystemDB; Integrated Security=True";

        SqlConnection sqlConnection;
        SqlDataReader reader;

        private string commandString;
        private SqlCommand sqlCommand;

        Stock stock = new Stock();

        public StockInForm()
        {
            InitializeComponent();

            sqlConnection = new SqlConnection(connectionString);

            DisplayStock();
        }

        private void StockInForm_Load(object sender, EventArgs e)
        {
            LoadCompany();
            LoadCategory();
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItem();
        }

        private void itemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReorder();
            LoadQuantity();
            LoadItemID();
        }

        private void LoadCompany()
        {
            try
            {
                commandString = @"SELECT * FROM Companys";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }

                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                    companyComboBox.DataSource = dataTable;

                sqlConnection.Close();

                companyComboBox.Text = "-Select-";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadCategory()
        {
            try
            {
                commandString = @"SELECT * FROM Categorys";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }

                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                    categoryComboBox.DataSource = dataTable;

                sqlConnection.Close();

                categoryComboBox.Text = "-Select-";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadItem()
        {
            try
            {
                commandString = @"SELECT Items.ItemName FROM ((Items LEFT JOIN Companys ON Items.CompanyID = Companys.ID) LEFT JOIN Categorys ON Items.CategoryID = Categorys.ID) WHERE Companys.ID = '" + companyComboBox.SelectedValue + "' AND Categorys.ID = '" + categoryComboBox.SelectedValue + "'";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }

                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                    itemComboBox.DataSource = dataTable;

                sqlConnection.Close();

                itemComboBox.Text = "-Select-";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadReorder()
        {
            try
            {
                commandString = @"SELECT ReorderLevel FROM Items WHERE ItemName = '" + itemComboBox.Text + "'";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }

                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    reorderLevelTextBox.Text = (reader["ReorderLevel"]).ToString();
                }

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadQuantity()
        {
            try
            {
                availableQuantityTextBox.Text = "0";
                commandString = @"SELECT Stocks.Quantity FROM Stocks LEFT JOIN Items ON Stocks.ItemID = Items.ID WHERE ItemName = '" + itemComboBox.Text + "'";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }

                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    availableQuantityTextBox.Text = (reader["Quantity"]).ToString();
                    //if (availableQuantityTextBox.Text == "")
                    //{
                    //    availableQuantityTextBox.Text = "0";
                    //}
                }

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadItemID()
        {
            try
            {
                commandString = @"SELECT ID FROM Items WHERE ItemName = '" + itemComboBox.Text + "'";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }

                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    stock.ItemID = Convert.ToInt32(reader["ID"]);
                }

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveButton.Text == "Save")
                {
                    if (IsFormValid())
                    {
                        int availableQuantity = Convert.ToInt32(availableQuantityTextBox.Text);
                        int stockInQuantity = Convert.ToInt32(stockInQuantityTextBox.Text);
                        stock.Quantity = availableQuantity + stockInQuantity;
                        stock.Date = DateTime.Now;
                        stock.Status = "Stock In";

                        StockIn(stock);
                    }
                }
                if (SaveButton.Text == "Update")
                {
                    if (String.IsNullOrEmpty(stockInQuantityTextBox.Text))
                    {
                        messageLabel.Text = "Please enter quantity";
                        return;
                    }
                    
                    stock.Quantity = Convert.ToInt32(stockInQuantityTextBox.Text);
                    
                    UpdateStock(stock);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool IsFormValid()
        {
            messageLabel.Text = "";

            if (companyComboBox.Text.Equals("-Select-"))
            {
                messageLabel.Text = "Select company";
                return false;
            }

            if (categoryComboBox.Text.Equals("-Select-"))
            {
                messageLabel.Text = "Select category";
                return false;
            }

            if (itemComboBox.Text.Equals("-Select-"))
            {
                messageLabel.Text = "Select item";
                return false;
            }

            if (String.IsNullOrEmpty(stockInQuantityTextBox.Text))
            {
                messageLabel.Text = "Please enter quantity";
                return false;
            }
            
            return true;
        }

        private void StockIn(Stock stock)
        {
            try
            {
                messageLabel.Text = "";

                commandString = "INSERT INTO Stocks (ItemID, Quantity, Date, Status) VALUES (" + stock.ItemID + ", " + stock.Quantity + ", '" + stock.Date + "', '" + stock.Status + "')";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }

                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    messageLabel.Text = "Save Successful.";

                    Reset();
                    DisplayStock();
                }
                else
                {
                    messageLabel.Text = "Save Failed!";
                }

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateStock(Stock stock)
        {
            try
            {
                messageLabel.Text = "";

                string query = "UPDATE Stocks SET Quantity = '" + stock.Quantity + "' WHERE ID = '" + stock.ID + "'";
                sqlCommand = new SqlCommand(query, sqlConnection);

                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }

                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    messageLabel.Text = "Update Successful.";

                    Reset();
                    DisplayStock();
                }
                else
                {
                    messageLabel.Text = "Update Failed!";
                }

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void Reset()
        {
            companyComboBox.Text = "-Select-";
            categoryComboBox.Text = "-Select-";
            itemComboBox.Text = "-Select-";
            reorderLevelTextBox.Clear();
            availableQuantityTextBox.Clear();
            stockInQuantityTextBox.Clear();

            SaveButton.Text = "Save";
        }

        private void DisplayStock()
        {
            try
            {
                commandString = @"SELECT * FROM StocksView";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    displayStockInDataGridView.DataSource = dataTable;
                }

                sqlConnection.Close();

                DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
                editButton.FlatStyle = FlatStyle.Popup;

                editButton.HeaderText = "Action";
                editButton.Name = "Edit";
                editButton.UseColumnTextForButtonValue = true;
                editButton.Text = "Edit";
                editButton.Width = 60;
                if(displayStockInDataGridView.Columns.Contains(editButton.Name = "Edit"))
                {

                }
                else
                {
                    displayStockInDataGridView.Columns.Add(editButton);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void displayStockInDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            displayStockInDataGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void displayStockInDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 7)
            {
                stock.ID = Convert.ToInt32(displayStockInDataGridView.CurrentRow.Cells[1].Value.ToString());
                itemComboBox.Text = displayStockInDataGridView.CurrentRow.Cells[3].Value.ToString();
                availableQuantityTextBox.Text = displayStockInDataGridView.CurrentRow.Cells[5].Value.ToString();
                stockInQuantityTextBox.Text = displayStockInDataGridView.CurrentRow.Cells[5].Value.ToString();

                SaveButton.Text = "Update";
            }
        }
    }
}