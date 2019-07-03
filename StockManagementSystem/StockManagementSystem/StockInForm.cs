using StockManagementSystem.BLL;
using StockManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagementSystem
{
    public partial class StockInForm : Form
    {
        StockManager _stockManager;
        private Stock stock;

        public StockInForm()
        {
            InitializeComponent();

            _stockManager = new StockManager();
            stock = new Stock();

            DisplayStock();
        }

        private void StockInForm_Load(object sender, EventArgs e)
        {
            companyComboBox.DataSource = _stockManager.LoadCompany();
            companyComboBox.Text = "-Select-";

            categoryComboBox.DataSource = _stockManager.LoadCategory();
            categoryComboBox.Text = "-Select-";
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemComboBox.DataSource = _stockManager.LoadItem(Convert.ToInt32(companyComboBox.SelectedValue), Convert.ToInt32(categoryComboBox.SelectedValue));
            itemComboBox.Text = "-Select-";
        }

        private void itemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReorder();
            LoadQuantity();
            LoadItemID();
        }
        
        private void LoadReorder()
        {
            stock.ItemName = itemComboBox.Text;
            reorderLevelTextBox.Text = _stockManager.LoadReorder(stock);
        }
        
        private void LoadQuantity()
        {
            availableQuantityTextBox.Text = "0";
            availableQuantityTextBox.Text = _stockManager.LoadQuantity(stock);
        }

        private void LoadItemID()
        {
            stock.ItemName = itemComboBox.Text;
            stock.ItemID = _stockManager.LoadItemID(stock);
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

                        try
                        {
                            messageLabel.Text = "";

                            int isExecuted = _stockManager.StockIn(stock);
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
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
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

                    try
                    {
                        messageLabel.Text = "";

                        int isExecuted = _stockManager.UpdateStock(stock);
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
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
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
                displayStockInDataGridView.DataSource = _stockManager.DisplayStock();

                DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
                editButton.FlatStyle = FlatStyle.Popup;

                editButton.HeaderText = "Action";
                editButton.Name = "Edit";
                editButton.UseColumnTextForButtonValue = true;
                editButton.Text = "Edit";
                editButton.Width = 60;
                if (displayStockInDataGridView.Columns.Contains(editButton.Name = "Edit"))
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
            if (e.ColumnIndex == 7)
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