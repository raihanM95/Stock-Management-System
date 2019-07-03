using StockManagementSystem.BLL;
using StockManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagementSystem
{
    public partial class LoginForm : Form
    {
        UserManager _userManager;
        private User user;

        public string Message = "";

        public LoginForm()
        {
            InitializeComponent();

            _userManager = new UserManager();
            user = new User();
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

            try
            {
                if (_userManager.LogIn(user) != 0)
                {
                    // Redirect form
                    this.Hide();
                    HomeForm home = new HomeForm();
                    home.Show();
                }
                else
                {
                    // Login error message
                    loginMessageLabel.Text = "Username or password doesn't match";
                    passwordTextBox.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }
    }
}
