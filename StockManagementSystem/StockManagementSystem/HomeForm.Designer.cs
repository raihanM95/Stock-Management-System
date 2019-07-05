namespace StockManagementSystem
{
    partial class HomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.CategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CategorySetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CompanyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CompanySetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StockInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StockOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.clock = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CategoryToolStripMenuItem,
            this.CompanyToolStripMenuItem,
            this.ItemToolStripMenuItem,
            this.StockToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(1064, 35);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // CategoryToolStripMenuItem
            // 
            this.CategoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CategorySetupToolStripMenuItem});
            this.CategoryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CategoryToolStripMenuItem.Image")));
            this.CategoryToolStripMenuItem.Name = "CategoryToolStripMenuItem";
            this.CategoryToolStripMenuItem.Size = new System.Drawing.Size(120, 29);
            this.CategoryToolStripMenuItem.Text = "Category";
            // 
            // CategorySetupToolStripMenuItem
            // 
            this.CategorySetupToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CategorySetupToolStripMenuItem.Image")));
            this.CategorySetupToolStripMenuItem.Name = "CategorySetupToolStripMenuItem";
            this.CategorySetupToolStripMenuItem.Size = new System.Drawing.Size(219, 30);
            this.CategorySetupToolStripMenuItem.Text = "Category Setup";
            this.CategorySetupToolStripMenuItem.Click += new System.EventHandler(this.CategorySetupToolStripMenuItem_Click);
            // 
            // CompanyToolStripMenuItem
            // 
            this.CompanyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CompanySetupToolStripMenuItem});
            this.CompanyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CompanyToolStripMenuItem.Image")));
            this.CompanyToolStripMenuItem.Name = "CompanyToolStripMenuItem";
            this.CompanyToolStripMenuItem.Size = new System.Drawing.Size(125, 29);
            this.CompanyToolStripMenuItem.Text = "Company";
            // 
            // CompanySetupToolStripMenuItem
            // 
            this.CompanySetupToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CompanySetupToolStripMenuItem.Image")));
            this.CompanySetupToolStripMenuItem.Name = "CompanySetupToolStripMenuItem";
            this.CompanySetupToolStripMenuItem.Size = new System.Drawing.Size(224, 30);
            this.CompanySetupToolStripMenuItem.Text = "Company Setup";
            this.CompanySetupToolStripMenuItem.Click += new System.EventHandler(this.CompanySetupToolStripMenuItem_Click);
            // 
            // ItemToolStripMenuItem
            // 
            this.ItemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemSetupToolStripMenuItem,
            this.ViewItemsToolStripMenuItem});
            this.ItemToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ItemToolStripMenuItem.Image")));
            this.ItemToolStripMenuItem.Name = "ItemToolStripMenuItem";
            this.ItemToolStripMenuItem.Size = new System.Drawing.Size(84, 29);
            this.ItemToolStripMenuItem.Text = "Item";
            // 
            // ItemSetupToolStripMenuItem
            // 
            this.ItemSetupToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ItemSetupToolStripMenuItem.Image")));
            this.ItemSetupToolStripMenuItem.Name = "ItemSetupToolStripMenuItem";
            this.ItemSetupToolStripMenuItem.Size = new System.Drawing.Size(183, 30);
            this.ItemSetupToolStripMenuItem.Text = "Item Setup";
            this.ItemSetupToolStripMenuItem.Click += new System.EventHandler(this.ItemSetupToolStripMenuItem_Click);
            // 
            // ViewItemsToolStripMenuItem
            // 
            this.ViewItemsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ViewItemsToolStripMenuItem.Image")));
            this.ViewItemsToolStripMenuItem.Name = "ViewItemsToolStripMenuItem";
            this.ViewItemsToolStripMenuItem.Size = new System.Drawing.Size(183, 30);
            this.ViewItemsToolStripMenuItem.Text = "View Items";
            this.ViewItemsToolStripMenuItem.Click += new System.EventHandler(this.ViewItemsToolStripMenuItem_Click);
            // 
            // StockToolStripMenuItem
            // 
            this.StockToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StockInToolStripMenuItem,
            this.StockOutToolStripMenuItem,
            this.ViewReportToolStripMenuItem});
            this.StockToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("StockToolStripMenuItem.Image")));
            this.StockToolStripMenuItem.Name = "StockToolStripMenuItem";
            this.StockToolStripMenuItem.Size = new System.Drawing.Size(91, 29);
            this.StockToolStripMenuItem.Text = "Stock";
            // 
            // StockInToolStripMenuItem
            // 
            this.StockInToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("StockInToolStripMenuItem.Image")));
            this.StockInToolStripMenuItem.Name = "StockInToolStripMenuItem";
            this.StockInToolStripMenuItem.Size = new System.Drawing.Size(191, 30);
            this.StockInToolStripMenuItem.Text = "Stock In";
            this.StockInToolStripMenuItem.Click += new System.EventHandler(this.StockInToolStripMenuItem_Click);
            // 
            // StockOutToolStripMenuItem
            // 
            this.StockOutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("StockOutToolStripMenuItem.Image")));
            this.StockOutToolStripMenuItem.Name = "StockOutToolStripMenuItem";
            this.StockOutToolStripMenuItem.Size = new System.Drawing.Size(191, 30);
            this.StockOutToolStripMenuItem.Text = "Stock Out";
            this.StockOutToolStripMenuItem.Click += new System.EventHandler(this.StockOutToolStripMenuItem_Click);
            // 
            // ViewReportToolStripMenuItem
            // 
            this.ViewReportToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ViewReportToolStripMenuItem.Image")));
            this.ViewReportToolStripMenuItem.Name = "ViewReportToolStripMenuItem";
            this.ViewReportToolStripMenuItem.Size = new System.Drawing.Size(191, 30);
            this.ViewReportToolStripMenuItem.Text = "View Report";
            this.ViewReportToolStripMenuItem.Click += new System.EventHandler(this.ViewReportToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 667);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip.Size = new System.Drawing.Size(1064, 30);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(163, 25);
            this.toolStripStatusLabel.Text = "Team RAM © 2019";
            // 
            // clock
            // 
            this.clock.AutoSize = true;
            this.clock.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clock.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.clock.Location = new System.Drawing.Point(950, 0);
            this.clock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.clock.Name = "clock";
            this.clock.Size = new System.Drawing.Size(127, 33);
            this.clock.TabIndex = 8;
            this.clock.Text = "00:00:00";
            this.clock.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // Timer
            // 
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 35);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1064, 632);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 697);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.clock);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "HomeForm";
            this.Text = "Home";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.HomeForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem CategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CategorySetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CompanyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CompanySetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ItemSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StockInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StockOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewReportToolStripMenuItem;
        private System.Windows.Forms.Label clock;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}



