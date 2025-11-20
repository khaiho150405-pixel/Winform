namespace WindowsForm_QLTV
{
    partial class UC_TrangChu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.pnlBackground = new System.Windows.Forms.Panel();
            this.pnlBookContainer = new System.Windows.Forms.Panel();
            this.lblTatCaSach = new System.Windows.Forms.Label();
            this.pnlBanner = new System.Windows.Forms.Panel();
            this.lblWelcomeText = new System.Windows.Forms.Label();
            this.pnlBackground.SuspendLayout();
            this.pnlBanner.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBackground
            // 
            this.pnlBackground.AutoScroll = true;
            this.pnlBackground.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBackground.Controls.Add(this.pnlBookContainer);
            this.pnlBackground.Controls.Add(this.lblTatCaSach);
            this.pnlBackground.Controls.Add(this.pnlBanner);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(1000, 700);
            this.pnlBackground.TabIndex = 0;
            // 
            // pnlBookContainer
            // 
            this.pnlBookContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBookContainer.Location = new System.Drawing.Point(30, 320);
            this.pnlBookContainer.Name = "pnlBookContainer";
            this.pnlBookContainer.Size = new System.Drawing.Size(940, 350);
            this.pnlBookContainer.TabIndex = 2;
            // 
            // lblTatCaSach
            // 
            this.lblTatCaSach.AutoSize = true;
            this.lblTatCaSach.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTatCaSach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTatCaSach.Location = new System.Drawing.Point(25, 270);
            this.lblTatCaSach.Name = "lblTatCaSach";
            this.lblTatCaSach.Size = new System.Drawing.Size(262, 31);
            this.lblTatCaSach.TabIndex = 1;
            this.lblTatCaSach.Text = "DANH SÁCH SÁCH MỚI";
            // 
            // pnlBanner
            // 
            this.pnlBanner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219))))); // Màu xanh dương nổi bật
            this.pnlBanner.Controls.Add(this.lblWelcomeText);
            this.pnlBanner.Location = new System.Drawing.Point(0, 0);
            this.pnlBanner.Name = "pnlBanner";
            this.pnlBanner.Size = new System.Drawing.Size(1000, 250);
            this.pnlBanner.TabIndex = 0;
            // 
            // lblWelcomeText
            // 
            this.lblWelcomeText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWelcomeText.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeText.ForeColor = System.Drawing.Color.White;
            this.lblWelcomeText.Location = new System.Drawing.Point(0, 0);
            this.lblWelcomeText.Name = "lblWelcomeText";
            this.lblWelcomeText.Size = new System.Drawing.Size(1000, 250);
            this.lblWelcomeText.TabIndex = 0;
            this.lblWelcomeText.Text = "THƯ VIỆN SỐ HUFI";
            this.lblWelcomeText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UC_TrangChu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.pnlBackground);
            this.Name = "UC_TrangChu";
            this.Size = new System.Drawing.Size(1000, 700);
            this.pnlBackground.ResumeLayout(false);
            this.pnlBackground.PerformLayout();
            this.pnlBanner.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        // Khai báo Controls chính thức
        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.Panel pnlBanner;
        private System.Windows.Forms.Label lblWelcomeText;
        private System.Windows.Forms.Panel pnlBookContainer;
        private System.Windows.Forms.Label lblTatCaSach;
    }
}