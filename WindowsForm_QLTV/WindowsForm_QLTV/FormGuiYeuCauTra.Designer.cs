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
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(425, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "YÊU CẦU TRẢ VÀ GIA HẠN SÁCH";

            // 
            // dgvActiveLoans
            // 
            this.dgvActiveLoans.AllowUserToAddRows = false;
            this.dgvActiveLoans.AllowUserToDeleteRows = false;
            this.dgvActiveLoans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActiveLoans.Location = new System.Drawing.Point(19, 58);
            this.dgvActiveLoans.Name = "dgvActiveLoans";
            this.dgvActiveLoans.ReadOnly = true;
            this.dgvActiveLoans.RowHeadersWidth = 51;
            this.dgvActiveLoans.RowTemplate.Height = 24;
            this.dgvActiveLoans.Size = new System.Drawing.Size(750, 387);
            this.dgvActiveLoans.TabIndex = 3;

            // 
            // lblSelectedBook
            // 
            this.lblSelectedBook.AutoSize = true;
            this.lblSelectedBook.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSelectedBook.Location = new System.Drawing.Point(19, 470);
            this.lblSelectedBook.Name = "lblSelectedBook";
            this.lblSelectedBook.Size = new System.Drawing.Size(306, 23);
            this.lblSelectedBook.TabIndex = 4;
            this.lblSelectedBook.Text = "Sách đã chọn: Vui lòng chọn một cuốn";

            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(16, 517);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(70, 16);
            this.lblQuantity.TabIndex = 5;
            this.lblQuantity.Text = "SL muốn trả:";

            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(92, 515);
            this.numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(50, 22);
            this.numQuantity.TabIndex = 6;
            this.numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // 
            // btnGuiYeuCauTra (Gửi yêu cầu trả)
            // 
            this.btnGuiYeuCauTra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34))))); // CAM
            this.btnGuiYeuCauTra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuiYeuCauTra.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuiYeuCauTra.ForeColor = System.Drawing.Color.White;
            this.btnGuiYeuCauTra.Location = new System.Drawing.Point(553, 508);
            this.btnGuiYeuCauTra.Name = "btnGuiYeuCauTra";
            this.btnGuiYeuCauTra.Size = new System.Drawing.Size(216, 35);
            this.btnGuiYeuCauTra.TabIndex = 7;
            this.btnGuiYeuCauTra.Text = "GỬI YÊU CẦU TRẢ";
            this.btnGuiYeuCauTra.UseVisualStyleBackColor = false;

            // 
            // btnGiaHan (Gia hạn)
            // 
            this.btnGiaHan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219))))); // XANH DƯƠNG
            this.btnGiaHan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGiaHan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGiaHan.ForeColor = System.Drawing.Color.White;
            this.btnGiaHan.Location = new System.Drawing.Point(330, 508);
            this.btnGiaHan.Name = "btnGiaHan";
            this.btnGiaHan.Size = new System.Drawing.Size(216, 35);
            this.btnGiaHan.TabIndex = 8;
            this.btnGiaHan.Text = "GIA HẠN (Từng cuốn)";
            this.btnGiaHan.UseVisualStyleBackColor = false;

            // 
            // FormGuiYeuCauTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 570);
            this.Controls.Add(this.btnGiaHan);
            this.Controls.Add(this.btnGuiYeuCauTra);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblSelectedBook);
            this.Controls.Add(this.dgvActiveLoans);
            this.Controls.Add(this.lblTitle);
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