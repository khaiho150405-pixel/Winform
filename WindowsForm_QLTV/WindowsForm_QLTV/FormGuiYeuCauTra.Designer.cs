namespace WindowsForm_QLTV
{
    partial class FormGuiYeuCauTra
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvActiveLoans;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Button btnGuiYeuCauTra; // Đã đổi tên
        private System.Windows.Forms.Button btnGiaHan; // NEW
        private System.Windows.Forms.Label lblSelectedBook;

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
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvActiveLoans = new System.Windows.Forms.DataGridView();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.btnGuiYeuCauTra = new System.Windows.Forms.Button();
            this.btnGiaHan = new System.Windows.Forms.Button();
            this.lblSelectedBook = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveLoans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(14, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(519, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "YÊU CẦU TRẢ VÀ GIA HẠN SÁCH";
            // 
            // dgvActiveLoans
            // 
            this.dgvActiveLoans.AllowUserToAddRows = false;
            this.dgvActiveLoans.AllowUserToDeleteRows = false;
            // --- QUAN TRỌNG: Anchor 4 phía để bảng giãn full màn hình ---
            this.dgvActiveLoans.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            // -----------------------------------------------------------
            this.dgvActiveLoans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActiveLoans.Location = new System.Drawing.Point(21, 72);
            this.dgvActiveLoans.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvActiveLoans.Name = "dgvActiveLoans";
            this.dgvActiveLoans.ReadOnly = true;
            this.dgvActiveLoans.RowHeadersWidth = 51;
            this.dgvActiveLoans.RowTemplate.Height = 24;
            this.dgvActiveLoans.Size = new System.Drawing.Size(844, 484);
            this.dgvActiveLoans.TabIndex = 3;
            // 
            // numQuantity
            // 
            // --- Anchor Bottom | Left: Dính góc trái dưới ---
            this.numQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // ------------------------------------------------
            this.numQuantity.Location = new System.Drawing.Point(124, 644);
            this.numQuantity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numQuantity.Minimum = new decimal(new int[] {
    1,
    0,
    0,
    0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(56, 26);
            this.numQuantity.TabIndex = 6;
            this.numQuantity.Value = new decimal(new int[] {
    1,
    0,
    0,
    0});
            // 
            // lblQuantity
            // 
            // --- Anchor Bottom | Left: Dính góc trái dưới ---
            this.lblQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // ------------------------------------------------
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(18, 646);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(100, 20);
            this.lblQuantity.TabIndex = 5;
            this.lblQuantity.Text = "SL muốn trả:";
            // 
            // btnGuiYeuCauTra
            // 
            // --- Anchor Bottom | Right: Dính góc phải dưới ---
            this.btnGuiYeuCauTra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            // -------------------------------------------------
            this.btnGuiYeuCauTra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnGuiYeuCauTra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuiYeuCauTra.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuiYeuCauTra.ForeColor = System.Drawing.Color.White;
            this.btnGuiYeuCauTra.Location = new System.Drawing.Point(622, 635);
            this.btnGuiYeuCauTra.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGuiYeuCauTra.Name = "btnGuiYeuCauTra";
            this.btnGuiYeuCauTra.Size = new System.Drawing.Size(243, 44);
            this.btnGuiYeuCauTra.TabIndex = 7;
            this.btnGuiYeuCauTra.Text = "GỬI YÊU CẦU TRẢ";
            this.btnGuiYeuCauTra.UseVisualStyleBackColor = false;
            // 
            // btnGiaHan
            // 
            // --- Anchor Bottom | Right: Dính góc phải dưới ---
            this.btnGiaHan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            // -------------------------------------------------
            this.btnGiaHan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnGiaHan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGiaHan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGiaHan.ForeColor = System.Drawing.Color.White;
            this.btnGiaHan.Location = new System.Drawing.Point(371, 635);
            this.btnGiaHan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGiaHan.Name = "btnGiaHan";
            this.btnGiaHan.Size = new System.Drawing.Size(243, 44);
            this.btnGiaHan.TabIndex = 8;
            this.btnGiaHan.Text = "GIA HẠN (Từng cuốn)";
            this.btnGiaHan.UseVisualStyleBackColor = false;
            // 
            // lblSelectedBook
            // 
            // --- Anchor Bottom | Left: Dính góc trái dưới (Nằm trên hàng nút một chút) ---
            this.lblSelectedBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // -----------------------------------------------------------------------------
            this.lblSelectedBook.AutoSize = true;
            this.lblSelectedBook.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSelectedBook.Location = new System.Drawing.Point(21, 588);
            this.lblSelectedBook.Name = "lblSelectedBook";
            this.lblSelectedBook.Size = new System.Drawing.Size(375, 28);
            this.lblSelectedBook.TabIndex = 4;
            this.lblSelectedBook.Text = "Sách đã chọn: Vui lòng chọn một cuốn";
            // 
            // FormGuiYeuCauTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 712);
            this.Controls.Add(this.btnGiaHan);
            this.Controls.Add(this.btnGuiYeuCauTra);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblSelectedBook);
            this.Controls.Add(this.dgvActiveLoans);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormGuiYeuCauTra";
            this.Text = "Gửi Yêu Cầu Trả Sách";
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveLoans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}