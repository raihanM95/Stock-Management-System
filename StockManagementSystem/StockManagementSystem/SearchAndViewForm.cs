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
using StockManagementSystem.BLL;

namespace StockManagementSystem
{
    public partial class SearchAndViewForm : Form
    {
        SearchAndViewManager _searchAndViewManager = new SearchAndViewManager();
        SearchAndViewModel _searchAndViewModel = new SearchAndViewModel();
        DataTable dataTable;
        public SearchAndViewForm()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            _searchAndViewModel.Category = categoryComboBox.SelectedText;
            _searchAndViewModel.Company = companyComboBox.SelectedText;

            dataTable = _searchAndViewManager.Search(_searchAndViewModel);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                searchAndViewDataGridView.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Sorry! Not Found Any Record");
                searchAndViewDataGridView.DataSource = null;
            }

        }

        private void SearchAndViewForm_Load(object sender, EventArgs e)
        {
            companyComboBox.DataSource = _searchAndViewManager.LoadCompany();
            companyComboBox.Text = "<Select>";

            categoryComboBox.DataSource = _searchAndViewManager.LoadCategory();
            categoryComboBox.Text = "<Select>";

        }

        private void searchAndViewDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            searchAndViewDataGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
    }
}
