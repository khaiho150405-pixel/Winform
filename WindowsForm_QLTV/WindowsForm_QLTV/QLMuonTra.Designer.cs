namespace WindowsForm_QLTV
{
    partial class FormQLMuonTra
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
            this.pnlBackground = new System.Windows.Forms.Panel();
            this.pnlSearchArea = new System.Windows.Forms.Panel();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.lblLocTrangThai = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearchTitle = new System.Windows.Forms.Label();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.dgvActiveLoans = new System.Windows.Forms.DataGridView();
            this.pnlDashboard = new System.Windows.Forms.Panel();
            this.pnlTraSach = new System.Windows.Forms.Panel();
            this.btnTraSach = new System.Windows.Forms.Button();
            this.pnlMuonSach = new System.Windows.Forms.Panel();
            this.btnMuonSach = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.pnlBackground.SuspendLayout();
            this.pnlSearchArea.SuspendLayout();
            this.pnlMainContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveLoans)).BeginInit();
            this.pnlDashboard.SuspendLayout();
            this.pnlTraSach.SuspendLayout();
            this.pnlMuonSach.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBackground
            // 
            this.pnlBackground.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBackground.Controls.Add(this.pnlSearchArea);
            this.pnlBackground.Controls.Add(this.pnlMainContent);
            this.pnlBackground.Controls.Add(this.pnlDashboard);
            this.pnlBackground.Controls.Add(this.pnlHeader);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(1000, 700);
            this.pnlBackground.TabIndex = 0;
            // 
            // pnlSearchArea
            // 
            this.pnlSearchArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearchArea.Controls.Add(this.cboTrangThai);
            this.pnlSearchArea.Controls.Add(this.lblLocTrangThai);
            this.pnlSearchArea.Controls.Add(this.btnTimKiem);
            this.pnlSearchArea.Controls.Add(this.txtSearch);
            this.pnlSearchArea.Controls.Add(this.lblSearchTitle);
            this.pnlSearchArea.Location = new System.Drawing.Point(350, 50);
            this.pnlSearchArea.Name = "pnlSearchArea";
            this.pnlSearchArea.Size = new System.Drawing.Size(640, 70);
            this.pnlSearchArea.TabIndex = 4;
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Location = new System.Drawing.Point(100, 28);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(140, 28);
            this.cboTrangThai.TabIndex = 4;
            // 
            // lblLocTrangThai
            // 
            this.lblLocTrangThai.AutoSize = true;
            this.lblLocTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLocTrangThai.Location = new System.Drawing.Point(10, 32);
            this.lblLocTrangThai.Name = "lblLocTrangThai";
            this.lblLocTrangThai.Size = new System.Drawing.Size(84, 20);
            this.lblLocTrangThai.TabIndex = 3;
            this.lblLocTrangThai.Text = "Trạng thái:";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(540, 25);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(90, 30);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Location = new System.Drawing.Point(330, 28);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 27);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.Text = "Nhập tên người mượn...";
            // 
            // lblSearchTitle
            // 
            this.lblSearchTitle.AutoSize = true;
            this.lblSearchTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearchTitle.Location = new System.Drawing.Point(255, 32);
            this.lblSearchTitle.Name = "lblSearchTitle";
            this.lblSearchTitle.Size = new System.Drawing.Size(69, 20);
            this.lblSearchTitle.TabIndex = 0;
            this.lblSearchTitle.Text = "Tên SV:";
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMainContent.BackColor = System.Drawing.Color.White;
            this.pnlMainContent.Controls.Add(this.dgvActiveLoans);
            this.pnlMainContent.Location = new System.Drawing.Point(350, 130);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new System.Drawing.Size(640, 560);
            this.pnlMainContent.TabIndex = 3;
            // 
            // dgvActiveLoans
            //
            this.dgvActiveLoans.AllowUserToAddRows = false;
            this.dgvActiveLoans.AllowUserToDeleteRows = false;
            this.dgvActiveLoans.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvActiveLoans.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvActiveLoans.BackgroundColor = System.Drawing.Color.White;
            this.dgvActiveLoans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActiveLoans.Location = new System.Drawing.Point(0, 0);
            this.dgvActiveLoans.Name = "dgvActiveLoans";
            this.dgvActiveLoans.ReadOnly = true;
            this.dgvActiveLoans.RowHeadersWidth = 51;
            this.dgvActiveLoans.RowTemplate.Height = 24;
            this.dgvActiveLoans.Size = new System.Drawing.Size(640, 560);
            this.dgvActiveLoans.TabIndex = 0;
            //
            // pnlDashboard
            // 
            this.pnlDashboard.Controls.Add(this.pnlTraSach);
            this.pnlDashboard.Controls.Add(this.pnlMuonSach);
            this.pnlDashboard.Location = new System.Drawing.Point(20, 50);
            this.pnlDashboard.Name = "pnlDashboard";
            this.pnlDashboard.Size = new System.Drawing.Size(300, 640);
            this.pnlDashboard.TabIndex = 2;
            // 
            // pnlTraSach
            // 
            this.pnlTraSach.BackColor = System.Drawing.Color.White;
            this.pnlTraSach.Controls.Add(this.btnTraSach);
            this.pnlTraSach.Location = new System.Drawing.Point(10, 230);
            this.pnlTraSach.Name = "pnlTraSach";
            this.pnlTraSach.Size = new System.Drawing.Size(280, 200);
            this.pnlTraSach.TabIndex = 1;
            // 
            // btnTraSach
            // 
            this.btnTraSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnTraSach.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnTraSach.FlatAppearance.BorderSize = 0;
            this.btnTraSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTraSach.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnTraSach.ForeColor = System.Drawing.Color.White;
            this.btnTraSach.Location = new System.Drawing.Point(0, 160);
            this.btnTraSach.Name = "btnTraSach";
            this.btnTraSach.Size = new System.Drawing.Size(280, 40);
            this.btnTraSach.TabIndex = 0;
            this.btnTraSach.Text = "TRẢ SÁCH";
            this.btnTraSach.UseVisualStyleBackColor = false;
            // 
            // pnlMuonSach
            // 
            this.pnlMuonSach.BackColor = System.Drawing.Color.White;
            this.pnlMuonSach.Controls.Add(this.btnMuonSach);
            this.pnlMuonSach.Location = new System.Drawing.Point(10, 10);
            this.pnlMuonSach.Name = "pnlMuonSach";
            this.pnlMuonSach.Size = new System.Drawing.Size(280, 200);
            this.pnlMuonSach.TabIndex = 0;
            // 
            // btnMuonSach
            // 
            this.btnMuonSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnMuonSach.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnMuonSach.FlatAppearance.BorderSize = 0;
            this.btnMuonSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMuonSach.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnMuonSach.ForeColor = System.Drawing.Color.White;
            this.btnMuonSach.Location = new System.Drawing.Point(0, 160);
            this.btnMuonSach.Name = "btnMuonSach";
            this.btnMuonSach.Size = new System.Drawing.Size(280, 40);
            this.btnMuonSach.TabIndex = 0;
            this.btnMuonSach.Text = "MƯỢN SÁCH";
            this.btnMuonSach.UseVisualStyleBackColor = false;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.pnlHeader.Controls.Add(this.lblFormTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1000, 50);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.ForeColor = System.Drawing.Color.White;
            this.lblFormTitle.Location = new System.Drawing.Point(10, 6);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(271, 38);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "QUẢN LÝ MƯỢN TRẢ";
            // 
            // FormQLMuonTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.pnlBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormQLMuonTra";
            this.Text = "FormQLMuonTra";
            this.pnlBackground.ResumeLayout(false);
            this.pnlSearchArea.ResumeLayout(false);
            this.pnlSearchArea.PerformLayout();
            this.pnlMainContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveLoans)).EndInit();
            this.pnlDashboard.ResumeLayout(false);
            this.pnlTraSach.ResumeLayout(false);
            this.pnlMuonSach.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel pnlDashboard;
        private System.Windows.Forms.Panel pnlMuonSach;
        private System.Windows.Forms.Button btnMuonSach;
        private System.Windows.Forms.Panel pnlTraSach;
        private System.Windows.Forms.Button btnTraSach;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.Panel pnlSearchArea;
        private System.Windows.Forms.Label lblSearchTitle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvActiveLoans;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label lblLocTrangThai;
    }
}