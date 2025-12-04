namespace WindowsForm_QLTV
{
    partial class FormMuonSach
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
            this.pbBookCover = new System.Windows.Forms.PictureBox();
            this.txtGiaMuon = new System.Windows.Forms.TextBox();
            this.lblGiaMuon = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.dgvChiTietMuon = new System.Windows.Forms.DataGridView();
            this.lblDetails = new System.Windows.Forms.Label();
            this.lblRequestInfo = new System.Windows.Forms.Label();
            this.pnlAction = new System.Windows.Forms.Panel();
            this.btnTuChoi = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.pnlBookSearch = new System.Windows.Forms.Panel();
            this.txtSLMuon = new System.Windows.Forms.TextBox();
            this.lblSLMuon = new System.Windows.Forms.Label();
            this.txtSoLuongTon = new System.Windows.Forms.TextBox();
            this.lblSLTon = new System.Windows.Forms.Label();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.lblBookTitle = new System.Windows.Forms.Label();
            this.pnlPendingLoans = new System.Windows.Forms.Panel();
            this.dgvPendingLoans = new System.Windows.Forms.DataGridView();
            this.lblPendingLoansTitle = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.pbBookCover)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietMuon)).BeginInit();
            this.pnlAction.SuspendLayout();
            this.pnlInput.SuspendLayout();
            this.pnlBookSearch.SuspendLayout();
            this.pnlPendingLoans.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingLoans)).BeginInit();
            this.SuspendLayout();

            // 
            // pbBookCover
            // 
            this.pbBookCover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbBookCover.Location = new System.Drawing.Point(10, 40);
            this.pbBookCover.Name = "pbBookCover";
            this.pbBookCover.Size = new System.Drawing.Size(110, 150); // Thu nhỏ ảnh
            this.pbBookCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBookCover.TabIndex = 8;
            this.pbBookCover.TabStop = false;

            // 
            // txtGiaMuon
            // 
            this.txtGiaMuon.Enabled = false;
            this.txtGiaMuon.Location = new System.Drawing.Point(210, 105); // Dời sang phải ảnh
            this.txtGiaMuon.Name = "txtGiaMuon";
            this.txtGiaMuon.Size = new System.Drawing.Size(90, 22);
            this.txtGiaMuon.TabIndex = 11;

            // 
            // lblGiaMuon
            // 
            this.lblGiaMuon.AutoSize = true;
            this.lblGiaMuon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGiaMuon.Location = new System.Drawing.Point(130, 108);
            this.lblGiaMuon.Name = "lblGiaMuon";
            this.lblGiaMuon.Size = new System.Drawing.Size(73, 20);
            this.lblGiaMuon.TabIndex = 10;
            this.lblGiaMuon.Text = "Giá Mượn:";

            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlDetails);
            this.pnlMain.Controls.Add(this.pnlAction);
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Controls.Add(this.pnlInput);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(950, 700);
            this.pnlMain.TabIndex = 0;

            // 
            // pnlDetails
            // 
            // --- TĂNG CHIỀU CAO để xem nhiều sách hơn ---
            this.pnlDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetails.Controls.Add(this.dgvChiTietMuon);
            this.pnlDetails.Controls.Add(this.lblDetails);
            this.pnlDetails.Controls.Add(this.lblRequestInfo);
            this.pnlDetails.Location = new System.Drawing.Point(40, 450); // Dời lên trên (Y giảm)
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(870, 170); // Tăng Height lên 170
            this.pnlDetails.TabIndex = 3;

            // 
            // dgvChiTietMuon
            // 
            this.dgvChiTietMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietMuon.Dock = System.Windows.Forms.DockStyle.Fill; // Fill toàn bộ panel chi tiết
            this.dgvChiTietMuon.Location = new System.Drawing.Point(0, 30);
            this.dgvChiTietMuon.Name = "dgvChiTietMuon";
            this.dgvChiTietMuon.RowHeadersWidth = 51;
            this.dgvChiTietMuon.RowTemplate.Height = 24;
            this.dgvChiTietMuon.Size = new System.Drawing.Size(868, 138);
            this.dgvChiTietMuon.TabIndex = 1;

            // 
            // lblDetails
            // 
            this.lblDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.lblDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDetails.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblDetails.Location = new System.Drawing.Point(0, 0);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(868, 30);
            this.lblDetails.TabIndex = 0;
            this.lblDetails.Text = "CHI TIẾT PHIẾU ĐANG CHỌN";
            this.lblDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // lblRequestInfo
            // 
            this.lblRequestInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRequestInfo.Location = new System.Drawing.Point(400, 0);
            this.lblRequestInfo.Name = "lblRequestInfo";
            this.lblRequestInfo.Size = new System.Drawing.Size(460, 30);
            this.lblRequestInfo.TabIndex = 2;
            this.lblRequestInfo.Text = "Chọn một phiếu bên trái để xem chi tiết.";
            this.lblRequestInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // pnlAction
            // 
            this.pnlAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAction.Controls.Add(this.btnTuChoi);
            this.pnlAction.Controls.Add(this.btnXacNhan);
            this.pnlAction.Location = new System.Drawing.Point(40, 630);
            this.pnlAction.Name = "pnlAction";
            this.pnlAction.Size = new System.Drawing.Size(870, 50);
            this.pnlAction.TabIndex = 2;

            // 
            // btnTuChoi
            // 
            // --- DỜI QUA TRÁI ---
            this.btnTuChoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTuChoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnTuChoi.FlatAppearance.BorderSize = 0;
            this.btnTuChoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTuChoi.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.btnTuChoi.ForeColor = System.Drawing.Color.White;
            this.btnTuChoi.Location = new System.Drawing.Point(210, 5); // Vị trí mới
            this.btnTuChoi.Name = "btnTuChoi";
            this.btnTuChoi.Size = new System.Drawing.Size(160, 40);
            this.btnTuChoi.TabIndex = 1;
            this.btnTuChoi.Text = "TỪ CHỐI YÊU CẦU";
            this.btnTuChoi.UseVisualStyleBackColor = false;

            // 
            // btnXacNhan
            // 
            // --- DỜI QUA TRÁI ---
            this.btnXacNhan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXacNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnXacNhan.FlatAppearance.BorderSize = 0;
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(0, 5); // Vị trí mới (sát trái)
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(190, 40);
            this.btnXacNhan.TabIndex = 0;
            this.btnXacNhan.Text = "XÁC NHẬN CHO MƯỢN";
            this.btnXacNhan.UseVisualStyleBackColor = false;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(392, 38);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "XỬ LÝ YÊU CẦU MƯỢN SÁCH";

            // 
            // pnlInput
            // 
            this.pnlInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInput.Controls.Add(this.pnlBookSearch);
            this.pnlInput.Controls.Add(this.pnlPendingLoans);
            this.pnlInput.Location = new System.Drawing.Point(40, 70);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(870, 370); // Giảm chiều cao để nhường chỗ cho pnlDetails
            this.pnlInput.TabIndex = 0;

            // 
            // pnlBookSearch
            // 
            // --- THU NHỎ LẠI ---
            this.pnlBookSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBookSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBookSearch.Controls.Add(this.txtSLMuon);
            this.pnlBookSearch.Controls.Add(this.lblSLMuon);
            this.pnlBookSearch.Controls.Add(this.txtSoLuongTon);
            this.pnlBookSearch.Controls.Add(this.lblSLTon);
            this.pnlBookSearch.Controls.Add(this.txtTenSach);
            this.pnlBookSearch.Controls.Add(this.lblBookTitle);
            this.pnlBookSearch.Controls.Add(this.pbBookCover);
            this.pnlBookSearch.Controls.Add(this.lblGiaMuon);
            this.pnlBookSearch.Controls.Add(this.txtGiaMuon);
            this.pnlBookSearch.Location = new System.Drawing.Point(550, 10); // Dời sang phải (X tăng)
            this.pnlBookSearch.Name = "pnlBookSearch";
            this.pnlBookSearch.Size = new System.Drawing.Size(310, 350); // Width giảm xuống còn 310
            this.pnlBookSearch.TabIndex = 1;

            // 
            // txtSLMuon
            // 
            this.txtSLMuon.Enabled = false;
            this.txtSLMuon.Location = new System.Drawing.Point(210, 135);
            this.txtSLMuon.Name = "txtSLMuon";
            this.txtSLMuon.Size = new System.Drawing.Size(90, 22);
            this.txtSLMuon.TabIndex = 13;

            // 
            // lblSLMuon
            // 
            this.lblSLMuon.AutoSize = true;
            this.lblSLMuon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSLMuon.Location = new System.Drawing.Point(130, 138);
            this.lblSLMuon.Name = "lblSLMuon";
            this.lblSLMuon.Size = new System.Drawing.Size(80, 20);
            this.lblSLMuon.TabIndex = 12;
            this.lblSLMuon.Text = "SL Yêu cầu:";

            // 
            // txtSoLuongTon
            // 
            this.txtSoLuongTon.Enabled = false;
            this.txtSoLuongTon.Location = new System.Drawing.Point(210, 75);
            this.txtSoLuongTon.Name = "txtSoLuongTon";
            this.txtSoLuongTon.Size = new System.Drawing.Size(90, 22);
            this.txtSoLuongTon.TabIndex = 7;

            // 
            // lblSLTon
            // 
            this.lblSLTon.AutoSize = true;
            this.lblSLTon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSLTon.Location = new System.Drawing.Point(130, 78);
            this.lblSLTon.Name = "lblSLTon";
            this.lblSLTon.Size = new System.Drawing.Size(83, 20);
            this.lblSLTon.TabIndex = 6;
            this.lblSLTon.Text = "SL Tồn Kho:";

            // 
            // txtTenSach
            // 
            this.txtTenSach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenSach.Enabled = false;
            this.txtTenSach.Location = new System.Drawing.Point(130, 40); // Đặt tên sách bên cạnh ảnh
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(170, 22);
            this.txtTenSach.TabIndex = 5;

            // 
            // lblBookTitle
            // 
            this.lblBookTitle.AutoSize = true;
            this.lblBookTitle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblBookTitle.Location = new System.Drawing.Point(10, 10);
            this.lblBookTitle.Name = "lblBookTitle";
            this.lblBookTitle.Size = new System.Drawing.Size(130, 23);
            this.lblBookTitle.TabIndex = 0;
            this.lblBookTitle.Text = "CHI TIẾT SÁCH";

            // 
            // pnlPendingLoans
            // 
            // --- MỞ RỘNG RA ---
            this.pnlPendingLoans.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlPendingLoans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPendingLoans.Controls.Add(this.dgvPendingLoans);
            this.pnlPendingLoans.Controls.Add(this.lblPendingLoansTitle);
            this.pnlPendingLoans.Location = new System.Drawing.Point(10, 10);
            this.pnlPendingLoans.Name = "pnlPendingLoans";
            this.pnlPendingLoans.Size = new System.Drawing.Size(530, 350); // Tăng Width lên 530
            this.pnlPendingLoans.TabIndex = 0;

            // 
            // dgvPendingLoans
            // 
            this.dgvPendingLoans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendingLoans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPendingLoans.Location = new System.Drawing.Point(0, 30);
            this.dgvPendingLoans.Name = "dgvPendingLoans";
            this.dgvPendingLoans.RowHeadersWidth = 51;
            this.dgvPendingLoans.RowTemplate.Height = 24;
            this.dgvPendingLoans.Size = new System.Drawing.Size(528, 318);
            this.dgvPendingLoans.TabIndex = 1;

            // 
            // lblPendingLoansTitle
            // 
            this.lblPendingLoansTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.lblPendingLoansTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPendingLoansTitle.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblPendingLoansTitle.Location = new System.Drawing.Point(0, 0);
            this.lblPendingLoansTitle.Name = "lblPendingLoansTitle";
            this.lblPendingLoansTitle.Size = new System.Drawing.Size(528, 30);
            this.lblPendingLoansTitle.TabIndex = 0;
            this.lblPendingLoansTitle.Text = "DANH SÁCH YÊU CẦU CHỜ DUYỆT";
            this.lblPendingLoansTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // FormMuonSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMuonSach";
            this.Text = "FormMuonSach";
            ((System.ComponentModel.ISupportInitialize)(this.pbBookCover)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietMuon)).EndInit();
            this.pnlAction.ResumeLayout(false);
            this.pnlInput.ResumeLayout(false);
            this.pnlBookSearch.ResumeLayout(false);
            this.pnlBookSearch.PerformLayout();
            this.pnlPendingLoans.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingLoans)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.Panel pnlBookSearch;
        private System.Windows.Forms.Label lblBookTitle;
        private System.Windows.Forms.Panel pnlPendingLoans;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtSoLuongTon;
        private System.Windows.Forms.Label lblSLTon;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.TextBox txtSLMuon;
        private System.Windows.Forms.Label lblSLMuon;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.DataGridView dgvChiTietMuon;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.Panel pnlAction;
        private System.Windows.Forms.Button btnTuChoi;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.DataGridView dgvPendingLoans;
        private System.Windows.Forms.Label lblPendingLoansTitle;
        private System.Windows.Forms.Label lblRequestInfo;
        private System.Windows.Forms.PictureBox pbBookCover;
        private System.Windows.Forms.TextBox txtGiaMuon;
        private System.Windows.Forms.Label lblGiaMuon;
    }
}