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
    public partial class ItemSetupForm : Form
    {
        ItemManager _itemManager;
        private Item item;

        public ItemSetupForm()
        {
            InitializeComponent();

            _itemManager = new ItemManager();
            item = new Item();
        }

        private void ItemSetupForm_Load(object sender, EventArgs e)
        {
            companyComboBox.DataSource = _itemManager.LoadCompany();
            companyComboBox.Text = "-Select-";

            categoryComboBox.DataSource = _itemManager.LoadCategory();
            categoryComboBox.Text = "-Select-";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(reorderLevelTextBox.Text))
                {
                    messageLabel.Text = "Enter Reorder Level";
                    return;
                }

                item.CategoryID = Convert.ToInt32(categoryComboBox.SelectedValue);
                item.CompanyID = Convert.ToInt32(companyComboBox.SelectedValue);
                item.ItemName = itemNameTextBox.Text;
                item.ReorderLevel = Convert.ToInt32(reorderLevelTextBox.Text);

                if (IsFormValid())
                {
                    messageLabel.Text = "";
                    int isExecuted = 0;

                    isExecuted = _itemManager.ItemInsert(item);

                    if (isExecuted > 0)
                    {
                        messageLabel.Text = "Save Successful.";

                        Reset();
                    }
                    else
                    {
                        messageLabel.Text = "Save Failed!";
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

            if (categoryComboBox.Text.Equals("-Select-"))
            {
                messageLabel.Text = "Select category";
                return false;
            }

            if (companyComboBox.Text.Equals("-Select-"))
            {
                messageLabel.Text = "Select company";
                return false;
            }

            if (String.IsNullOrEmpty(itemNameTextBox.Text))
            {
                messageLabel.Text = "Enter Item";
                return false;
            }

            if (_itemManager.IsDuplicate(item))
            {
                messageLabel.Text = "Item is duplicate!";
                return false;
            }

            if (String.IsNullOrEmpty(reorderLevelTextBox.Text))
            {
                messageLabel.Text = "Enter Reorder Level";
                return false;
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(reorderLevelTextBox.Text, "[^0-9]"))
            {
                messageLabel.Text = "Enter only digits";
                return false;
            }

            return true;
        }

        private void Reset()
        {
            companyComboBox.Text = "-Select-";
            categoryComboBox.Text = "-Select-";
            itemNameTextBox.Clear();
            reorderLevelTextBox.Clear();
        }
    }
}
