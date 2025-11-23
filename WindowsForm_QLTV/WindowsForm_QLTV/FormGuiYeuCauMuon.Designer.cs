namespace WindowsForm_QLTV
{
    partial class FormGuiYeuCauMuon
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvBookCatalog;
        private System.Windows.Forms.TextBox txtSearchBook;
        private System.Windows.Forms.Button btnSearchBook;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Button btnGuiYeuCau;
        private System.Windows.Forms.DataGridView dgvCart; // NEW
        private System.Windows.Forms.Label lblCartTitle; // NEW
        private System.Windows.Forms.Button btnAddToCart; // NEW
        private System.Windows.Forms.Button btnRemoveFromCart; // NEW

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
            this.dgvBookCatalog = new System.Windows.Forms.DataGridView();
            this.txtSearchBook = new System.Windows.Forms.TextBox();
            this.btnSearchBook = new System.Windows.Forms.Button();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.btnGuiYeuCau = new System.Windows.Forms.Button();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.lblCartTitle = new System.Windows.Forms.Label();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.btnRemoveFromCart = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvBookCatalog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(306, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "GỬI YÊU CẦU MƯỢN SÁCH";

            // 
            // txtSearchBook
            // 
            this.txtSearchBook.Location = new System.Drawing.Point(19, 58);
            this.txtSearchBook.Name = "txtSearchBook";
            this.txtSearchBook.Size = new System.Drawing.Size(250, 22);
            this.txtSearchBook.TabIndex = 1;
            this.txtSearchBook.Text = "Nhập tên sách, tác giả...";

            // 
            // btnSearchBook
            // 
            this.btnSearchBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSearchBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchBook.ForeColor = System.Drawing.Color.White;
            this.btnSearchBook.Location = new System.Drawing.Point(275, 55);
            this.btnSearchBook.Name = "btnSearchBook";
            this.btnSearchBook.Size = new System.Drawing.Size(90, 30);
            this.btnSearchBook.TabIndex = 2;
            this.btnSearchBook.Text = "Tìm Kiếm";
            this.btnSearchBook.UseVisualStyleBackColor = false;

            // 
            // dgvBookCatalog
            // 
            this.dgvBookCatalog.AllowUserToAddRows = false;
            this.dgvBookCatalog.AllowUserToDeleteRows = false;
            this.dgvBookCatalog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookCatalog.Location = new System.Drawing.Point(19, 95);
            this.dgvBookCatalog.Name = "dgvBookCatalog";
            this.dgvBookCatalog.ReadOnly = true;
            this.dgvBookCatalog.RowHeadersWidth = 51;
            this.dgvBookCatalog.RowTemplate.Height = 24;
            this.dgvBookCatalog.Size = new System.Drawing.Size(750, 250); // Đã giảm kích thước
            this.dgvBookCatalog.TabIndex = 3;

            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(400, 63);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(70, 16);
            this.lblQuantity.TabIndex = 5;
            this.lblQuantity.Text = "Số lượng:";

            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(476, 61);
            this.numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(50, 22);
            this.numQuantity.TabIndex = 6;
            this.numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // 
            // btnAddToCart (Nút thêm vào giỏ)
            // 
            this.btnAddToCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnAddToCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToCart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddToCart.ForeColor = System.Drawing.Color.White;
            this.btnAddToCart.Location = new System.Drawing.Point(540, 55);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(130, 30);
            this.btnAddToCart.TabIndex = 7;
            this.btnAddToCart.Text = "➕ Thêm vào giỏ";
            this.btnAddToCart.UseVisualStyleBackColor = false;

            // 
            // lblCartTitle (Tiêu đề Giỏ hàng)
            // 
            this.lblCartTitle.AutoSize = true;
            this.lblCartTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCartTitle.Location = new System.Drawing.Point(19, 360);
            this.lblCartTitle.Name = "lblCartTitle";
            this.lblCartTitle.Size = new System.Drawing.Size(183, 28);
            this.lblCartTitle.TabIndex = 8;
            this.lblCartTitle.Text = "GIỎ HÀNG (0 cuốn)";

            // 
            // dgvCart (Giỏ hàng)
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Location = new System.Drawing.Point(19, 395);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.RowHeadersWidth = 51;
            this.dgvCart.RowTemplate.Height = 24;
            this.dgvCart.Size = new System.Drawing.Size(550, 150);
            this.dgvCart.TabIndex = 9;

            // 
            // btnRemoveFromCart (Nút xóa khỏi giỏ)
            // 
            this.btnRemoveFromCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnRemoveFromCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveFromCart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRemoveFromCart.ForeColor = System.Drawing.Color.White;
            this.btnRemoveFromCart.Location = new System.Drawing.Point(580, 420);
            this.btnRemoveFromCart.Name = "btnRemoveFromCart";
            this.btnRemoveFromCart.Size = new System.Drawing.Size(190, 35);
            this.btnRemoveFromCart.TabIndex = 10;
            this.btnRemoveFromCart.Text = "❌ Xóa khỏi giỏ";
            this.btnRemoveFromCart.UseVisualStyleBackColor = false;

            // 
            // btnGuiYeuCau (Gửi yêu cầu tổng)
            // 
            this.btnGuiYeuCau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnGuiYeuCau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuiYeuCau.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnGuiYeuCau.ForeColor = System.Drawing.Color.White;
            this.btnGuiYeuCau.Location = new System.Drawing.Point(580, 470);
            this.btnGuiYeuCau.Name = "btnGuiYeuCau";
            this.btnGuiYeuCau.Size = new System.Drawing.Size(190, 75);
            this.btnGuiYeuCau.TabIndex = 11;
            this.btnGuiYeuCau.Text = "✅ GỬI YÊU CẦU MƯỢN";
            this.btnGuiYeuCau.UseVisualStyleBackColor = false;

            // 
            // FormGuiYeuCauMuon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 570);
            this.Controls.Add(this.btnGuiYeuCau);
            this.Controls.Add(this.btnRemoveFromCart);
            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.lblCartTitle);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.dgvBookCatalog);
            this.Controls.Add(this.btnSearchBook);
            this.Controls.Add(this.txtSearchBook);
            this.Controls.Add(this.lblTitle);
            this.Name = "FormGuiYeuCauMuon";
            this.Text = "Gửi Yêu Cầu Mượn";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookCatalog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}