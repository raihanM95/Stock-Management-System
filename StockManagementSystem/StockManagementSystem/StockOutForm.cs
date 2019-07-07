using StockManagementSystem.BLL;
using StockManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagementSystem
{
    public partial class StockOutForm : Form
    {
        StockManager _stockManager;
        private Stock stock;
        private Item item;
        List<Stock> listStockOut;
        private Stock stockOut;
        private DataTable dataTable;

        public StockOutForm()
        {
            InitializeComponent();

            _stockManager = new StockManager();
            stock = new Stock();
            item = new Item();
            listStockOut = new List<Stock>();
        }

        private void StockOutForm_Load(object sender, EventArgs e)
        {
            companyComboBox.DataSource = _stockManager.LoadCompany();
            companyComboBox.Text = "-Select-";

            categoryComboBox.DataSource = _stockManager.LoadCategory();
            categoryComboBox.Text = "-Select-";

            reorderLevelTextBox.Text = "<View>";
            availableQuantityTextBox.Text = "<View>";
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemComboBox.DataSource = _stockManager.LoadItem(Convert.ToInt32(companyComboBox.SelectedValue), Convert.ToInt32(categoryComboBox.SelectedValue));
            itemComboBox.Text = "-Select-";

            reorderLevelTextBox.Text = "<View>";
            availableQuantityTextBox.Text = "<View>";
        }

        private void itemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReorder();
            LoadQuantity();
            //LoadItemID();
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

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (IsFormValid())
            {
                stockOut = new Stock();

                stockOut.ItemID = _stockManager.LoadItemID(stock);
                stockOut.ItemName = itemComboBox.Text;
                stockOut.Company = companyComboBox.Text;
                stockOut.Quantity = Convert.ToInt32(stockOutQuantityTextBox.Text);

                listStockOut.Add(stockOut);
                displayStockOutDataGridView.DataSource = null;
                displayStockOutDataGridView.DataSource = listStockOut;

                foreach (DataGridViewRow row in displayStockOutDataGridView.Rows)
                {
                    row.Cells["SL"].Value = (row.Index + 1).ToString();
                }

                Reset();
            }
        }

        private bool IsFormValid()
        {
            messageLabel.Text = "";
            int reorderLevel = 0;
            int availableQuantity = 0;
            int stockOutQuantity = 0;

            reorderLevel = Convert.ToInt32(reorderLevelTextBox.Text);
            availableQuantity = Convert.ToInt32(availableQuantityTextBox.Text);
            stockOutQuantity = Convert.ToInt32(stockOutQuantityTextBox.Text);

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

            if (String.IsNullOrEmpty(stockOutQuantityTextBox.Text))
            {
                messageLabel.Text = "Please enter quantity";
                return false;
            }

            if(stockOutQuantity > availableQuantity)
            {
                messageLabel.Text = "Sorry quantity not available!!";
                return false;
            }

            if (availableQuantity - stockOutQuantity <= reorderLevel)
            {
                messageLabel.Text = "Please restock this item.";
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
            stockOutQuantityTextBox.Clear();
        }

        private void SellButton_Click(object sender, EventArgs e)
        {
            stock.Status = "Sell";
            StockOut();
        }

        private void LostButton_Click(object sender, EventArgs e)
        {
            stock.Status = "Lost";
            StockOut();
        }

        private void DamageButton_Click(object sender, EventArgs e)
        {
            stock.Status = "Damaged";
            StockOut();
        }

        private void StockOut()
        {
            stockOut = new Stock();
            
            foreach (DataGridViewRow row in displayStockOutDataGridView.Rows)
            {
                stockOut.ItemID = Convert.ToInt32(row.Cells["dataGridViewTextBoxColumn2"].Value.ToString());
                stockOut.Quantity = Convert.ToInt32(row.Cells["dataGridViewTextBoxColumn3"].Value.ToString());
                stockOut.Date = DateTime.Now;
                stockOut.Status = stock.Status;

                item.ID = stockOut.ItemID;
                dataTable = _stockManager.GetQuantity(item);
                int quantity = Convert.ToInt32(dataTable.Rows[0]["AvailableQuantity"]);
                quantity -= stockOut.Quantity;
                item.AvailableQuantity = quantity;
                _stockManager.InsertAvailableQuantity(item);

                int isExecuted = 0;

                isExecuted = _stockManager.StockOut(stockOut);

                if (isExecuted > 0)
                {
                    messageLabel.Text = "Save Successful.";
                }
                else
                {
                    messageLabel.Text = "Save Failed!";
                }
            }

            listStockOut = new List<Stock>();
            displayStockOutDataGridView.DataSource = null;
            displayStockOutDataGridView.DataSource = listStockOut;
        }
    }
}
