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
    public partial class SearchForm : Form
    {
        ItemManager _itemManager;
        private Item item;
        DataTable dataTable;

        public SearchForm()
        {
            InitializeComponent();

            _itemManager = new ItemManager();
            item = new Item();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            item.Category = categoryComboBox.Text;
            item.Company = companyComboBox.Text;

            dataTable = _itemManager.Search(item);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                searchAndViewDataGridView.DataSource = dataTable;
            }
            else
            {
                messageLabel.Text = "Sorry! No data found";
                searchAndViewDataGridView.DataSource = null;
            }
        }

        private void SearchAndViewForm_Load(object sender, EventArgs e)
        {
            companyComboBox.DataSource = _itemManager.LoadCompany();
            companyComboBox.Text = "-Select-";

            categoryComboBox.DataSource = _itemManager.LoadCategory();
            categoryComboBox.Text = "-Select-";
        }

        private void searchAndViewDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            searchAndViewDataGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
    }
}
