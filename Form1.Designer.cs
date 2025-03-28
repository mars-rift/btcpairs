namespace btcpairs
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }

                // Add disposal of additional resources
                httpClient?.Dispose();
                _cts?.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCurrencyPair = new System.Windows.Forms.Label();
            this.cbCurrencyPair = new System.Windows.Forms.ComboBox();
            this.lblPriceTitle = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLastUpdatedTitle = new System.Windows.Forms.Label();
            this.lblLastUpdated = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(270, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Bitcoin Price Tracker";
            // 
            // lblCurrencyPair
            // 
            this.lblCurrencyPair.AutoSize = true;
            this.lblCurrencyPair.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCurrencyPair.Location = new System.Drawing.Point(15, 67);
            this.lblCurrencyPair.Name = "lblCurrencyPair";
            this.lblCurrencyPair.Size = new System.Drawing.Size(102, 20);
            this.lblCurrencyPair.TabIndex = 1;
            this.lblCurrencyPair.Text = "Currency Pair:";
            // 
            // cbCurrencyPair
            // 
            this.cbCurrencyPair.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCurrencyPair.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbCurrencyPair.FormattingEnabled = true;
            this.cbCurrencyPair.Location = new System.Drawing.Point(123, 64);
            this.cbCurrencyPair.Name = "cbCurrencyPair";
            this.cbCurrencyPair.Size = new System.Drawing.Size(159, 28);
            this.cbCurrencyPair.TabIndex = 2;
            this.cbCurrencyPair.SelectedIndexChanged += new System.EventHandler(this.CbCurrencyPair_SelectedIndexChanged);
            // 
            // lblPriceTitle
            // 
            this.lblPriceTitle.AutoSize = true;
            this.lblPriceTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPriceTitle.Location = new System.Drawing.Point(15, 12);
            this.lblPriceTitle.Name = "lblPriceTitle";
            this.lblPriceTitle.Size = new System.Drawing.Size(47, 21);
            this.lblPriceTitle.TabIndex = 3;
            this.lblPriceTitle.Text = "Price:";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblPrice.Location = new System.Drawing.Point(68, 7);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(28, 32);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "0";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRefresh.Location = new System.Drawing.Point(300, 63);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 30);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblLastUpdatedTitle);
            this.panel1.Controls.Add(this.lblLastUpdated);
            this.panel1.Controls.Add(this.lblPriceTitle);
            this.panel1.Controls.Add(this.lblPrice);
            this.panel1.Location = new System.Drawing.Point(15, 111);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 89);
            this.panel1.TabIndex = 6;
            // 
            // lblLastUpdatedTitle
            // 
            this.lblLastUpdatedTitle.AutoSize = true;
            this.lblLastUpdatedTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLastUpdatedTitle.Location = new System.Drawing.Point(15, 60);
            this.lblLastUpdatedTitle.Name = "lblLastUpdatedTitle";
            this.lblLastUpdatedTitle.Size = new System.Drawing.Size(83, 15);
            this.lblLastUpdatedTitle.TabIndex = 5;
            this.lblLastUpdatedTitle.Text = "Last Updated:";
            // 
            // lblLastUpdated
            // 
            this.lblLastUpdated.AutoSize = true;
            this.lblLastUpdated.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLastUpdated.Location = new System.Drawing.Point(104, 60);
            this.lblLastUpdated.Name = "lblLastUpdated";
            this.lblLastUpdated.Size = new System.Drawing.Size(12, 15);
            this.lblLastUpdated.TabIndex = 6;
            this.lblLastUpdated.Text = "-";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.Location = new System.Drawing.Point(15, 217);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 15);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Ready";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 241);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cbCurrencyPair);
            this.Controls.Add(this.lblCurrencyPair);
            this.Controls.Add(this.lblTitle);
            this.Name = "Form1";
            this.Text = "Bitcoin Price Tracker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblCurrencyPair;
        private ComboBox cbCurrencyPair;
        private Label lblPriceTitle;
        private Label lblPrice;
        private Button btnRefresh;
        private Panel panel1;
        private Label lblLastUpdatedTitle;
        private Label lblLastUpdated;
        private Label lblStatus;
    }
}
