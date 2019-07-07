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
    public partial class HomeForm : Form
    {
        private int childFormNumber = 0;

        public HomeForm()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //oolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        // Call Category Setup form
        private void CategorySetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategorySetupForm categorySetup = new CategorySetupForm();
            categorySetup.Show();
        }

        // Call Company Setup form
        private void CompanySetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompanySetupForm companySetup = new CompanySetupForm();
            companySetup.Show();
        }

        // Call Item Setup form
        private void ItemSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemSetupForm itemSetup = new ItemSetupForm();
            itemSetup.Show();
        }

        // Call Search & View Items Summary form
        private void ViewItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForm search = new SearchForm();
            search.Show();
            
        }

        // Call Stock In form
        private void StockInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockInForm stockIn = new StockInForm();
            stockIn.Show();
        }

        // Call Stock Out form
        private void StockOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockOutForm stockOut = new StockOutForm();
            stockOut.Show();
        }

        // Call View Between Two Dates Report form
        private void ViewReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewForm view = new ViewForm();
            view.Show();
        }

        // Timer add
        private void Timer_Tick(object sender, EventArgs e)
        {
            clock.Text = DateTime.Now.ToString("T");
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            Timer.Start();
        }
    }
}
