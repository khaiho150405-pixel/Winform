namespace WindowsForm_QLTV
{
    partial class FormTraSach
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlAction = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnXacNhanTra = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.dgvLoanDetails = new System.Windows.Forms.DataGridView();
            this.lblLoanDetailsTitle = new System.Windows.Forms.Label();
            this.pnlActiveLoans = new System.Windows.Forms.Panel();
            this.dgvActiveLoans = new System.Windows.Forms.DataGridView();
            this.lblActiveLoansTitle = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblDocGiaStatus = new System.Windows.Forms.Label();
            this.txtSLTra = new System.Windows.Forms.TextBox();
            this.lblSLTra = new System.Windows.Forms.Label();
            this.txtTenDocGia = new System.Windows.Forms.TextBox();
            this.lblTenDocGia = new System.Windows.Forms.Label();
            this.lblReaderTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlAction.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoanDetails)).BeginInit();
            this.pnlActiveLoans.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveLoans)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlAction);
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Controls.Add(this.pnlDetails);
            this.pnlMain.Controls.Add(this.pnlActiveLoans);
            this.pnlMain.Controls.Add(this.pnlSearch);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(950, 700);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlAction
            // 
            this.pnlAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAction.Controls.Add(this.btnHuy);
            this.pnlAction.Controls.Add(this.btnXacNhanTra);
            this.pnlAction.Location = new System.Drawing.Point(30, 620);
            this.pnlAction.Name = "pnlAction";
            this.pnlAction.Size = new System.Drawing.Size(890, 50);
            this.pnlAction.TabIndex = 4;
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(183, 3);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(110, 40);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "HỦY";
            this.btnHuy.UseVisualStyleBackColor = false;
            // 
            // btnXacNhanTra
            // 
            this.btnXacNhanTra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXacNhanTra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnXacNhanTra.FlatAppearance.BorderSize = 0;
            this.btnXacNhanTra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhanTra.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.btnXacNhanTra.ForeColor = System.Drawing.Color.White;
            this.btnXacNhanTra.Location = new System.Drawing.Point(3, 3);
            this.btnXacNhanTra.Name = "btnXacNhanTra";
            this.btnXacNhanTra.Size = new System.Drawing.Size(170, 40);
            this.btnXacNhanTra.TabIndex = 0;
            this.btnXacNhanTra.Text = "XÁC NHẬN TRẢ";
            this.btnXacNhanTra.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(312, 38);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "NGHIỆP VỤ TRẢ SÁCH";
            // 
            // pnlDetails
            // 
            this.pnlDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetails.Controls.Add(this.dgvLoanDetails);
            this.pnlDetails.Controls.Add(this.lblLoanDetailsTitle);
            this.pnlDetails.Location = new System.Drawing.Point(30, 400);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(890, 200);
            this.pnlDetails.TabIndex = 2;
            // 
            // dgvLoanDetails
            // 
            this.dgvLoanDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoanDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLoanDetails.Location = new System.Drawing.Point(0, 30);
            this.dgvLoanDetails.Name = "dgvLoanDetails";
            this.dgvLoanDetails.RowHeadersWidth = 51;
            this.dgvLoanDetails.RowTemplate.Height = 24;
            this.dgvLoanDetails.Size = new System.Drawing.Size(888, 168);
            this.dgvLoanDetails.TabIndex = 1;
            // 
            // lblLoanDetailsTitle
            // 
            this.lblLoanDetailsTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.lblLoanDetailsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLoanDetailsTitle.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblLoanDetailsTitle.Location = new System.Drawing.Point(0, 0);
            this.lblLoanDetailsTitle.Name = "lblLoanDetailsTitle";
            this.lblLoanDetailsTitle.Size = new System.Drawing.Size(888, 30);
            this.lblLoanDetailsTitle.TabIndex = 0;
            this.lblLoanDetailsTitle.Text = "CHI TIẾT PHIẾU MƯỢN ĐÃ CHỌN (Sách còn nợ)";
            this.lblLoanDetailsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlActiveLoans
            // 
            this.pnlActiveLoans.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlActiveLoans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlActiveLoans.Controls.Add(this.dgvActiveLoans);
            this.pnlActiveLoans.Controls.Add(this.lblActiveLoansTitle);
            this.pnlActiveLoans.Location = new System.Drawing.Point(30, 190);
            this.pnlActiveLoans.Name = "pnlActiveLoans";
            this.pnlActiveLoans.Size = new System.Drawing.Size(890, 200);
            this.pnlActiveLoans.TabIndex = 1;
            // 
            // dgvActiveLoans
            // 
            this.dgvActiveLoans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActiveLoans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActiveLoans.Location = new System.Drawing.Point(0, 30);
            this.dgvActiveLoans.Name = "dgvActiveLoans";
            this.dgvActiveLoans.RowHeadersWidth = 51;
            this.dgvActiveLoans.RowTemplate.Height = 24;
            this.dgvActiveLoans.Size = new System.Drawing.Size(888, 168);
            this.dgvActiveLoans.TabIndex = 1;
            // 
            // lblActiveLoansTitle
            // 
            this.lblActiveLoansTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.lblActiveLoansTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblActiveLoansTitle.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblActiveLoansTitle.Location = new System.Drawing.Point(0, 0);
            this.lblActiveLoansTitle.Name = "lblActiveLoansTitle";
            this.lblActiveLoansTitle.Size = new System.Drawing.Size(888, 30);
            this.lblActiveLoansTitle.TabIndex = 0;
            this.lblActiveLoansTitle.Text = "DANH SÁCH PHIẾU MƯỢN ĐANG HOẠT ĐỘNG TRÊN HỆ THỐNG";
            this.lblActiveLoansTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Controls.Add(this.lblDocGiaStatus);
            this.pnlSearch.Controls.Add(this.txtSLTra);
            this.pnlSearch.Controls.Add(this.lblSLTra);
            this.pnlSearch.Controls.Add(this.txtTenDocGia);
            this.pnlSearch.Controls.Add(this.lblTenDocGia);
            this.pnlSearch.Controls.Add(this.lblReaderTitle);
            this.pnlSearch.Location = new System.Drawing.Point(30, 70);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(890, 100);
            this.pnlSearch.TabIndex = 0;
            // 
            // lblDocGiaStatus
            // 
            this.lblDocGiaStatus.AutoSize = true;
            this.lblDocGiaStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDocGiaStatus.ForeColor = System.Drawing.Color.Red;
            this.lblDocGiaStatus.Location = new System.Drawing.Point(284, 15);
            this.lblDocGiaStatus.Name = "lblDocGiaStatus";
            this.lblDocGiaStatus.Size = new System.Drawing.Size(200, 20);
            this.lblDocGiaStatus.TabIndex = 8;
            this.lblDocGiaStatus.Text = "Tổng quan yêu cầu trả sách";
            // 
            // txtSLTra
            // 
            this.txtSLTra.Location = new System.Drawing.Point(790, 50);
            this.txtSLTra.Name = "txtSLTra";
            this.txtSLTra.Size = new System.Drawing.Size(80, 22);
            this.txtSLTra.TabIndex = 6;
            this.txtSLTra.Text = "1";
            // 
            // lblSLTra
            // 
            this.lblSLTra.AutoSize = true;
            this.lblSLTra.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSLTra.Location = new System.Drawing.Point(670, 52);
            this.lblSLTra.Name = "lblSLTra";
            this.lblSLTra.Size = new System.Drawing.Size(91, 20);
            this.lblSLTra.TabIndex = 5;
            this.lblSLTra.Text = "SL muốn trả:";
            // 
            // txtTenDocGia
            // 
            this.txtTenDocGia.Enabled = false;
            this.txtTenDocGia.Location = new System.Drawing.Point(140, 50);
            this.txtTenDocGia.Name = "txtTenDocGia";
            this.txtTenDocGia.Size = new System.Drawing.Size(400, 22);
            this.txtTenDocGia.TabIndex = 4;
            // 
            // lblTenDocGia
            // 
            this.lblTenDocGia.AutoSize = true;
            this.lblTenDocGia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTenDocGia.Location = new System.Drawing.Point(10, 52);
            this.lblTenDocGia.Name = "lblTenDocGia";
            this.lblTenDocGia.Size = new System.Drawing.Size(122, 20);
            this.lblTenDocGia.TabIndex = 3;
            this.lblTenDocGia.Text = "Phiếu đang chọn:";
            // 
            // lblReaderTitle
            // 
            this.lblReaderTitle.AutoSize = true;
            this.lblReaderTitle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblReaderTitle.Location = new System.Drawing.Point(10, 12);
            this.lblReaderTitle.Name = "lblReaderTitle";
            this.lblReaderTitle.Size = new System.Drawing.Size(268, 23);
            this.lblReaderTitle.TabIndex = 9;
            this.lblReaderTitle.Text = "THÔNG TIN PHIẾU ĐANG CHỌN";
            // 
            // FormTraSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTraSach";
            this.Text = "FormTraSach";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlAction.ResumeLayout(false);
            this.pnlDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoanDetails)).EndInit();
            this.pnlActiveLoans.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveLoans)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Panel pnlActiveLoans;
        private System.Windows.Forms.Label lblReaderTitle;
        private System.Windows.Forms.TextBox txtTenDocGia;
        private System.Windows.Forms.Label lblTenDocGia;
        private System.Windows.Forms.DataGridView dgvActiveLoans;
        private System.Windows.Forms.Label lblActiveLoansTitle;
        private System.Windows.Forms.DataGridView dgvLoanDetails;
        private System.Windows.Forms.Label lblLoanDetailsTitle;
        private System.Windows.Forms.Panel pnlAction;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnXacNhanTra;
        private System.Windows.Forms.TextBox txtSLTra;
        private System.Windows.Forms.Label lblSLTra;
        private System.Windows.Forms.Label lblDocGiaStatus;
    }
}