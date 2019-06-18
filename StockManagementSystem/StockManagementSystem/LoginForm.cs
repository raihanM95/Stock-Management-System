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
    public partial class LoginForm : Form
    {
        User user = new User();

        public string connectionString = @"Server=DESKTOP-ON380RK\SQLEXPRESS; Database=StockManagementSystemDB; Integrated Security=True";

        public string Message = "";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            loginMessageLabel.Text = "";

            // Validation check
            if (String.IsNullOrEmpty(userNameTextBox.Text))
            {
                loginMessageLabel.Text = "Please enter username";
                return;
            }

            if (String.IsNullOrEmpty(passwordTextBox.Text))
            {
                loginMessageLabel.Text = "Please enter password";
                return;
            }

            // Pass value in User Class
            user.Username = userNameTextBox.Text;
            user.Password = passwordTextBox.Text;

            if (LogIn() != 0)
            {
                // Redirect form
                this.Hide();
                HomeForm home = new HomeForm();
                home.Show();
            }
            else
            {
                // Login error message
                loginMessageLabel.Text = Message;
            }
        }

        public int LogIn()
        {
            int count = 0;

            try
            {
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = connectionString;

                SqlCommand sqlCommand = new SqlCommand();
                string commandString = "SELECT * FROM [dbo].[User] WHERE UserName = '" + user.Username + "' and Password = '" + user.Password + "'";
                sqlCommand.CommandText = commandString;
                sqlCommand.Connection = sqlConnection;

                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();

                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                dataAdapter.Fill(dataTable);
                count = Convert.ToInt32(dataTable.Rows.Count.ToString());

                sqlConnection.Close();

                if (count == 0)
                {
                    Message = "Username or password doesn't match";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return count;
        }
    }
}
