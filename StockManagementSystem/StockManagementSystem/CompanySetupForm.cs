using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagementSystem.BLL;
using StockManagementSystem.Models;

namespace StockManagementSystem
{
    public partial class CompanySetupForm : Form
    {
        CompanyManager _companyManager;
        private Company company ;

        public CompanySetupForm()
        {
            InitializeComponent();

            _companyManager = new CompanyManager();
            company = new Company();
        }

        private void CompanySetupForm_Load(object sender, EventArgs e)
        {
            companyDataGridView.DataSource = _companyManager.LoadCompanyDataGridView();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveButton.Text.Equals("Save"))
                {
                    company.Name = nameTextBox.Text;
                    if (String.IsNullOrEmpty(company.Name))
                    {
                        MessageBox.Show("Category Name can not be Empty!");
                        return;
                    }
                    
                    bool validationCheck = _companyManager.ValidationCheck(company);
                    if (validationCheck == true)
                    {
                        MessageBox.Show("Company [ " + company.Name + " ] already Exist!!");
                        return;
                    }
                    
                    int insert = _companyManager.InsertCompany(company);

                    if (insert > 0)
                    {
                        MessageBox.Show("Saved Succesfully");
                    }
                    else
                    {
                        MessageBox.Show("Sorry! Saved Failed");
                    }

                    companyDataGridView.DataSource = _companyManager.LoadCompanyDataGridView();
                }
                else
                {
                    company.Name = nameTextBox.Text;
                    int update = _companyManager.UpdateCompany(company);

                    if (update > 0)
                    {
                        MessageBox.Show("Updated Succesfully");
                    }
                    else
                    {
                        MessageBox.Show("Sorry! Updated Failed");
                    }

                    SaveButton.Text = "Save";
                }

                nameTextBox.Clear();
                companyDataGridView.DataSource = _companyManager.LoadCompanyDataGridView();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
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
