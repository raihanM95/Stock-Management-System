using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagementSystem.Models;
using StockManagementSystem.BLL;


namespace StockManagementSystem
{
    public partial class CategorySetupForm : Form
    {
        CategoryManager _categoryManager;
        private Category category;

        public CategorySetupForm()
        {
            InitializeComponent();

            _categoryManager = new CategoryManager();
            category = new Category();
        }

        private void CategorySetupForm_Load(object sender, EventArgs e)
        {
            categoryDataGridView.DataSource = _categoryManager.LoadCategoryDataGridView();
        }
        
        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveButton.Text.Equals("Save"))
                {
                    category.Name = nameTextBox.Text;
                    if (String.IsNullOrEmpty(category.Name))
                    {
                        MessageBox.Show("Category Name can not be Empty!");
                        return;
                    }
                    
                    bool validationCheck = _categoryManager.ValidationCheck(category);
                    if (validationCheck == true)
                    {
                        MessageBox.Show("Category [ " + category.Name + " ] already Exist!!");
                        return;
                    }
                    
                    int insert;
                    insert = _categoryManager.InsertCategory(category);
                    if (insert > 0)
                    {
                        MessageBox.Show("Saved Succesfully");
                    }
                    else
                    {
                        MessageBox.Show("Sorry! Saved Failed");
                    }

                    categoryDataGridView.DataSource = _categoryManager.LoadCategoryDataGridView();
                }
                else
                {
                    category.Name = nameTextBox.Text;
                    int update;
                    update = _categoryManager.UpdateCategory(category);
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

                categoryDataGridView.DataSource = _categoryManager.LoadCategoryDataGridView();
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
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
