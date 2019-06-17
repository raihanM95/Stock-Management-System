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
            User user = new User();
            user.Username = userNameTextBox.Text;
            user.Password = passwordTextBox.Text;

            if (user.LogIn() != 0)
            {
                // Redirect form
                this.Hide();
                HomeForm home = new HomeForm();
                home.Show();
            }
            else
            {
                // Login error message
                loginMessageLabel.Text = user.Message;
            }
        }
    }
}
