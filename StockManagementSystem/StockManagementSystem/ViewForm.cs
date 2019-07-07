using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagementSystem.Models;
using StockManagementSystem.BLL;

namespace StockManagementSystem
{
    public partial class ViewForm : Form
    {
        StockManager _stockManager;

        public ViewForm()
        {
            InitializeComponent();
            _stockManager = new StockManager();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            string fromDate = fromDateTimePicker.Value.ToString("yyyy-MM-dd");
            string toDate = toDateTimePicker.Value.ToString("yyyy-MM-dd");

            string status = "";

            if (soldRadioButton.Checked == true)
            {
                status = "Sell";
            }
            else if (damagedRadioButton.Checked == true)
            {
                status = "Lost";
            }
            else
            {
                status = "Damaged";
            }

            dataTable = _stockManager.ViewReport(fromDate, toDate, status);
            //viewDataGridView.DataSource = dataTable;

            if (dataTable.Rows.Count > 0)
            {
                viewDataGridView.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("No Data Found");
                viewDataGridView.DataSource = null;
            }
        }

        private void viewDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            viewDataGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
    }
}
