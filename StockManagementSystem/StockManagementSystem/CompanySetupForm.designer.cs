namespace StockManagementSystem
{
    partial class CompanySetupForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.companyDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn_SL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SaveButton = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.companyDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 80);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 0;
            // 
            // companyDataGridView
            // 
            this.companyDataGridView.AutoGenerateColumns = false;
            this.companyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.companyDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn_SL,
            this.DataGridViewTextBoxColumn_ID,
            this.DataGridViewTextBoxColumn_Name});
            this.companyDataGridView.DataSource = this.categoryBindingSource;
            this.companyDataGridView.Location = new System.Drawing.Point(56, 203);
            this.companyDataGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.companyDataGridView.Name = "companyDataGridView";
            this.companyDataGridView.RowHeadersVisible = false;
            this.companyDataGridView.Size = new System.Drawing.Size(363, 303);
            this.companyDataGridView.TabIndex = 3;
            this.companyDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.companyDataGridView_CellClick);
            this.companyDataGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.companyDataGridView_RowPostPaint);
            // 
            // dataGridViewTextBoxColumn_SL
            // 
            this.dataGridViewTextBoxColumn_SL.HeaderText = "SL";
            this.dataGridViewTextBoxColumn_SL.Name = "dataGridViewTextBoxColumn_SL";
            this.dataGridViewTextBoxColumn_SL.ReadOnly = true;
            this.dataGridViewTextBoxColumn_SL.Width = 70;
            // 
            // DataGridViewTextBoxColumn_ID
            // 
            this.DataGridViewTextBoxColumn_ID.DataPropertyName = "ID";
            this.DataGridViewTextBoxColumn_ID.HeaderText = "ID";
            this.DataGridViewTextBoxColumn_ID.Name = "DataGridViewTextBoxColumn_ID";
            this.DataGridViewTextBoxColumn_ID.Visible = false;
            // 
            // DataGridViewTextBoxColumn_Name
            // 
            this.DataGridViewTextBoxColumn_Name.DataPropertyName = "Name";
            this.DataGridViewTextBoxColumn_Name.HeaderText = "Name";
            this.DataGridViewTextBoxColumn_Name.Name = "DataGridViewTextBoxColumn_Name";
            this.DataGridViewTextBoxColumn_Name.Width = 200;
            // 
            // categoryBindingSource
            // 
            this.categoryBindingSource.DataSource = typeof(StockManagementSystem.Models.Category);
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(260, 97);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(134, 45);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(159, 50);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(235, 26);
            this.nameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(82, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 27);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name";
            // 
            // CompanySetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(478, 557);
            this.Controls.Add(this.companyDataGridView);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "CompanySetupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company Setup";
            this.Load += new System.EventHandler(this.CompanySetupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.companyDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView companyDataGridView;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource categoryBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn_SL;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn_Name;
    }
}