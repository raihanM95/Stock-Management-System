using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagementSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new LoginForm());
            //Application.Run(new HomeForm());
            //Application.Run(new CategorySetupForm());
            //Application.Run(new CompanySetupForm());
            //Application.Run(new ItemSetupForm());
            //Application.Run(new StockInForm());
            //Application.Run(new StockOutForm());
            //Application.Run(new SearchAndViewForm());
            //Application.Run(new ViewForm());
        }
    }
}
