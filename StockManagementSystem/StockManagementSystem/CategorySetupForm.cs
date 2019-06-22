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
       

        public Category category;
        public CategoryManager _categoryManager = new CategoryManager();

        public CategorySetupForm()
        {
            InitializeComponent();
            
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
                        MessageBox.Show("Category Name Can not be Empty!");
                        return;
                    }
                    //dataTable = _categoryManager.ValidationCheck(category);
                    bool isExist = _categoryManager.ValidationCheck(category);
                    if ( isExist == true)
                    {
                        MessageBox.Show("Category  [ " + category.Name + " ]  alreday Exist!!");
                        return;

                    }
                    //InsertCategory(category);
                    int isExecuted;
                    isExecuted = _categoryManager.InsertCategory(category);
                    if (isExecuted > 0)
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
                    int isExist;
                    isExist = _categoryManager.UpdateCategory(category);
                    if (isExist > 0)
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
