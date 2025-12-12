namespace WindowsForm_QLTV
{
    partial class MuonTra
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnGuiYeuCauMuon;
        private System.Windows.Forms.Button btnGuiYeuCauTra;

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
            this.pnlBackground = new System.Windows.Forms.Panel();
            this.pnlGridContainer = new System.Windows.Forms.Panel();
            this.dgvLoanHistory = new System.Windows.Forms.DataGridView();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnGuiYeuCauTra = new System.Windows.Forms.Button();
            this.btnGuiYeuCauMuon = new System.Windows.Forms.Button();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.lblThongTinPhat = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.lblTrangThaiPhat = new System.Windows.Forms.Label();

            this.pnlBackground.SuspendLayout();
            this.pnlGridContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoanHistory)).BeginInit();
            this.pnlActions.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlBackground
            // 
            this.pnlBackground.BackColor = System.Drawing.Color.White;
            this.pnlBackground.Controls.Add(this.pnlGridContainer);
            this.pnlBackground.Controls.Add(this.pnlActions);
            this.pnlBackground.Controls.Add(this.lblFormTitle);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(1000, 650);
            this.pnlBackground.TabIndex = 0;

            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblFormTitle.Location = new System.Drawing.Point(20, 20);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(400, 41);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "LỊCH SỬ MƯỢN/TRẢ CỦA TÔI";

            // 
            // pnlActions (Chứa các nút chức năng)
            // 
            this.pnlActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlActions.Controls.Add(this.btnGuiYeuCauTra);
            this.pnlActions.Controls.Add(this.btnGuiYeuCauMuon);
            this.pnlActions.Location = new System.Drawing.Point(20, 80);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(960, 50);
            this.pnlActions.TabIndex = 1;

            // 
            // btnGuiYeuCauMuon (Nút Mượn)
            // 
            this.btnGuiYeuCauMuon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96))))); // XANH LÁ
            this.btnGuiYeuCauMuon.FlatAppearance.BorderSize = 0;
            this.btnGuiYeuCauMuon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuiYeuCauMuon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuiYeuCauMuon.ForeColor = System.Drawing.Color.White;
            this.btnGuiYeuCauMuon.Location = new System.Drawing.Point(10, 8);
            this.btnGuiYeuCauMuon.Name = "btnGuiYeuCauMuon";
            this.btnGuiYeuCauMuon.Size = new System.Drawing.Size(220, 35);
            this.btnGuiYeuCauMuon.TabIndex = 0;
            this.btnGuiYeuCauMuon.Text = "➕ GỬI YÊU CẦU MƯỢN MỚI";
            this.btnGuiYeuCauMuon.UseVisualStyleBackColor = false;

            // 
            // btnGuiYeuCauTra (Nút Trả)
            // 
            this.btnGuiYeuCauTra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34))))); // CAM
            this.btnGuiYeuCauTra.FlatAppearance.BorderSize = 0;
            this.btnGuiYeuCauTra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuiYeuCauTra.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuiYeuCauTra.ForeColor = System.Drawing.Color.White;
            this.btnGuiYeuCauTra.Location = new System.Drawing.Point(240, 8);
            this.btnGuiYeuCauTra.Name = "btnGuiYeuCauTra";
            this.btnGuiYeuCauTra.Size = new System.Drawing.Size(200, 35);
            this.btnGuiYeuCauTra.TabIndex = 1;
            this.btnGuiYeuCauTra.Text = "↩️ GỬI YÊU CẦU TRẢ SÁCH";
            this.btnGuiYeuCauTra.UseVisualStyleBackColor = false;

            //
            // lblThongTinPhat (Hiển thị tổng tiền)
            // 
            this.lblThongTinPhat.AutoSize = true;
            this.lblThongTinPhat.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblThongTinPhat.ForeColor = System.Drawing.Color.Red;
            this.lblThongTinPhat.Location = new System.Drawing.Point(460, 12);
            this.lblThongTinPhat.Name = "lblThongTinPhat";
            this.lblThongTinPhat.Size = new System.Drawing.Size(0, 25);
            this.lblThongTinPhat.TabIndex = 2;

            // 
            // btnThanhToan (Nút đóng phạt)
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.Firebrick; // Màu đỏ cảnh báo
            this.btnThanhToan.FlatAppearance.BorderSize = 0;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(750, 8); // Đặt góc phải
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(180, 35);
            this.btnThanhToan.TabIndex = 3;
            this.btnThanhToan.Text = "💸 THANH TOÁN";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Visible = false; // Mặc định ẩn, chỉ hiện khi có nợ

            // 
            // pnlGridContainer (Chứa DataGridView)
            // 
            this.pnlGridContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGridContainer.Controls.Add(this.dgvLoanHistory);
            this.pnlGridContainer.Location = new System.Drawing.Point(20, 140);
            this.pnlGridContainer.Name = "pnlGridContainer";
            this.pnlGridContainer.Size = new System.Drawing.Size(960, 480);
            this.pnlGridContainer.TabIndex = 2;

            // 
            // dgvLoanHistory
            // 
            this.dgvLoanHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvLoanHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoanHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLoanHistory.Location = new System.Drawing.Point(0, 0);
            this.dgvLoanHistory.Name = "dgvLoanHistory";
            this.dgvLoanHistory.RowHeadersWidth = 51;
            this.dgvLoanHistory.RowTemplate.Height = 24;
            this.dgvLoanHistory.Size = new System.Drawing.Size(960, 480);
            this.dgvLoanHistory.TabIndex = 0;

            // 
            // MuonTra (Cấu hình Form)
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.pnlBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MuonTra";
            this.Text = "Lịch sử Mượn/Trả";

            this.pnlBackground.ResumeLayout(false);
            this.pnlBackground.PerformLayout();
            this.pnlGridContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoanHistory)).EndInit();
            this.pnlActions.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Panel pnlGridContainer;
        private System.Windows.Forms.DataGridView dgvLoanHistory;
        private System.Windows.Forms.Label lblThongTinPhat;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Label lblTrangThaiPhat;
    }
}