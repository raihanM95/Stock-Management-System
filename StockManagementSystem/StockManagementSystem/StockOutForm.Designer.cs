namespace StockManagementSystem
{
    partial class StockOutForm
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
            this.messageLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.stockOutQuantityTextBox = new System.Windows.Forms.TextBox();
            this.availableQuantityTextBox = new System.Windows.Forms.TextBox();
            this.reorderLevelTextBox = new System.Windows.Forms.TextBox();
            this.itemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.itemComboBox = new System.Windows.Forms.ComboBox();
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.companyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.companyComboBox = new System.Windows.Forms.ComboBox();
            this.SellButton = new System.Windows.Forms.Button();
            this.LostButton = new System.Windows.Forms.Button();
            this.DamageButton = new System.Windows.Forms.Button();
            this.displayStockOutDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.displayStockOutDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(249, 314);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(0, 20);
            this.messageLabel.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(191, 263);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Stock Out Quantity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(187, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Available Quantity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(214, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Reorder Level";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(281, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Item";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Category";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(246, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Company";
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(466, 306);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(100, 36);
            this.AddButton.TabIndex = 21;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            // 
            // stockOutQuantityTextBox
            // 
            this.stockOutQuantityTextBox.Location = new System.Drawing.Point(342, 260);
            this.stockOutQuantityTextBox.Name = "stockOutQuantityTextBox";
            this.stockOutQuantityTextBox.Size = new System.Drawing.Size(224, 26);
            this.stockOutQuantityTextBox.TabIndex = 20;
            // 
            // availableQuantityTextBox
            // 
            this.availableQuantityTextBox.Location = new System.Drawing.Point(342, 217);
            this.availableQuantityTextBox.Name = "availableQuantityTextBox";
            this.availableQuantityTextBox.ReadOnly = true;
            this.availableQuantityTextBox.Size = new System.Drawing.Size(224, 26);
            this.availableQuantityTextBox.TabIndex = 19;
            // 
            // reorderLevelTextBox
            // 
            this.reorderLevelTextBox.Location = new System.Drawing.Point(342, 175);
            this.reorderLevelTextBox.Name = "reorderLevelTextBox";
            this.reorderLevelTextBox.ReadOnly = true;
            this.reorderLevelTextBox.Size = new System.Drawing.Size(224, 26);
            this.reorderLevelTextBox.TabIndex = 18;
            // 
            // itemBindingSource
            // 
            this.itemBindingSource.DataSource = typeof(StockManagementSystem.Models.Item);
            // 
            // itemComboBox
            // 
            this.itemComboBox.DataSource = this.itemBindingSource;
            this.itemComboBox.DisplayMember = "ItemName";
            this.itemComboBox.FormattingEnabled = true;
            this.itemComboBox.Location = new System.Drawing.Point(342, 130);
            this.itemComboBox.Name = "itemComboBox";
            this.itemComboBox.Size = new System.Drawing.Size(224, 28);
            this.itemComboBox.TabIndex = 17;
            this.itemComboBox.ValueMember = "ID";
            // 
            // categoryBindingSource
            // 
            this.categoryBindingSource.DataSource = typeof(StockManagementSystem.Models.Category);
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.DataSource = this.categoryBindingSource;
            this.categoryComboBox.DisplayMember = "Name";
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(342, 86);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(224, 28);
            this.categoryComboBox.TabIndex = 16;
            this.categoryComboBox.ValueMember = "ID";
            // 
            // companyBindingSource
            // 
            this.companyBindingSource.DataSource = typeof(StockManagementSystem.Models.Company);
            // 
            // companyComboBox
            // 
            this.companyComboBox.DataSource = this.companyBindingSource;
            this.companyComboBox.DisplayMember = "Name";
            this.companyComboBox.FormattingEnabled = true;
            this.companyComboBox.Location = new System.Drawing.Point(342, 40);
            this.companyComboBox.Name = "companyComboBox";
            this.companyComboBox.Size = new System.Drawing.Size(224, 28);
            this.companyComboBox.TabIndex = 12;
            this.companyComboBox.ValueMember = "ID";
            // 
            // SellButton
            // 
            this.SellButton.Location = new System.Drawing.Point(479, 591);
            this.SellButton.Name = "SellButton";
            this.SellButton.Size = new System.Drawing.Size(100, 36);
            this.SellButton.TabIndex = 21;
            this.SellButton.Text = "Sell";
            this.SellButton.UseVisualStyleBackColor = true;
            // 
            // LostButton
            // 
            this.LostButton.Location = new System.Drawing.Point(585, 591);
            this.LostButton.Name = "LostButton";
            this.LostButton.Size = new System.Drawing.Size(100, 36);
            this.LostButton.TabIndex = 21;
            this.LostButton.Text = "Lost";
            this.LostButton.UseVisualStyleBackColor = true;
            // 
            // DamageButton
            // 
            this.DamageButton.Location = new System.Drawing.Point(691, 591);
            this.DamageButton.Name = "DamageButton";
            this.DamageButton.Size = new System.Drawing.Size(100, 36);
            this.DamageButton.TabIndex = 21;
            this.DamageButton.Text = "Damage";
            this.DamageButton.UseVisualStyleBackColor = true;
            // 
            // displayStockOutDataGridView
            // 
            this.displayStockOutDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.displayStockOutDataGridView.Location = new System.Drawing.Point(14, 370);
            this.displayStockOutDataGridView.Name = "displayStockOutDataGridView";
            this.displayStockOutDataGridView.ReadOnly = true;
            this.displayStockOutDataGridView.RowTemplate.Height = 28;
            this.displayStockOutDataGridView.Size = new System.Drawing.Size(778, 196);
            this.displayStockOutDataGridView.TabIndex = 22;
            // 
            // StockOutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 639);
            this.Controls.Add(this.displayStockOutDataGridView);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DamageButton);
            this.Controls.Add(this.LostButton);
            this.Controls.Add(this.SellButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.stockOutQuantityTextBox);
            this.Controls.Add(this.availableQuantityTextBox);
            this.Controls.Add(this.reorderLevelTextBox);
            this.Controls.Add(this.itemComboBox);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.companyComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StockOutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Out";
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.displayStockOutDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.TextBox stockOutQuantityTextBox;
        private System.Windows.Forms.TextBox availableQuantityTextBox;
        private System.Windows.Forms.TextBox reorderLevelTextBox;
        private System.Windows.Forms.BindingSource itemBindingSource;
        private System.Windows.Forms.ComboBox itemComboBox;
        private System.Windows.Forms.BindingSource categoryBindingSource;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.BindingSource companyBindingSource;
        private System.Windows.Forms.ComboBox companyComboBox;
        private System.Windows.Forms.Button SellButton;
        private System.Windows.Forms.Button LostButton;
        private System.Windows.Forms.Button DamageButton;
        private System.Windows.Forms.DataGridView displayStockOutDataGridView;
    }
}