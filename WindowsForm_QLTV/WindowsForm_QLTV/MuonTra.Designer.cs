namespace WindowsForm_QLTV
{
    partial class MuonTra
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
            this.pnlBackground = new System.Windows.Forms.Panel();
            this.pnlGridContainer = new System.Windows.Forms.Panel();
            this.dgvSachDangMuon = new System.Windows.Forms.DataGridView();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.lblFormTitle = new System.Windows.Forms.Label(); // Giữ lại tiêu đề Form

            this.pnlBackground.SuspendLayout();
            this.pnlGridContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachDangMuon)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlBackground (Dock.Fill)
            // 
            this.pnlBackground.BackColor = System.Drawing.Color.White;
            this.pnlBackground.Controls.Add(this.pnlGridContainer);
            this.pnlBackground.Controls.Add(this.pnlSearch);
            this.pnlBackground.Controls.Add(this.lblFormTitle);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(1000, 650);
            this.pnlBackground.TabIndex = 0;

            // 
            // lblFormTitle (Tiêu đề Form)
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblFormTitle.Location = new System.Drawing.Point(20, 20);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(400, 41);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "SÁCH ĐANG ĐƯỢC MƯỢN";


            // 
            // pnlSearch (Thanh Tìm kiếm)
            // 
            this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearch.Controls.Add(this.btnTimKiem);
            this.pnlSearch.Controls.Add(this.txtTimKiem);
            this.pnlSearch.Controls.Add(this.lblTimKiem);
            this.pnlSearch.Location = new System.Drawing.Point(20, 80);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(960, 50);
            this.pnlSearch.TabIndex = 1;

            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTimKiem.Location = new System.Drawing.Point(10, 15);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(91, 23);
            this.lblTimKiem.TabIndex = 0;
            this.lblTimKiem.Text = "Tên Sách:";

            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.Location = new System.Drawing.Point(110, 12);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(280, 30);
            this.txtTimKiem.TabIndex = 1;

            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(400, 11);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 32);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;

            // 
            // pnlGridContainer (Chứa DataGridView)
            // 
            this.pnlGridContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGridContainer.Controls.Add(this.dgvSachDangMuon);
            this.pnlGridContainer.Location = new System.Drawing.Point(20, 140);
            this.pnlGridContainer.Name = "pnlGridContainer";
            this.pnlGridContainer.Size = new System.Drawing.Size(960, 500);
            this.pnlGridContainer.TabIndex = 2;

            // 
            // dgvSachDangMuon
            // 
            this.dgvSachDangMuon.BackgroundColor = System.Drawing.Color.White;
            this.dgvSachDangMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSachDangMuon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSachDangMuon.Location = new System.Drawing.Point(0, 0);
            this.dgvSachDangMuon.Name = "dgvSachDangMuon";
            this.dgvSachDangMuon.RowHeadersWidth = 51;
            this.dgvSachDangMuon.RowTemplate.Height = 24;
            this.dgvSachDangMuon.Size = new System.Drawing.Size(960, 500);
            this.dgvSachDangMuon.TabIndex = 0;

            // 
            // MuonTra (Cấu hình Form)
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.pnlBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MuonTra";
            this.Text = "Xử lý Trả Sách";

            this.pnlBackground.ResumeLayout(false);
            this.pnlBackground.PerformLayout();
            this.pnlGridContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachDangMuon)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Panel pnlGridContainer;
        private System.Windows.Forms.DataGridView dgvSachDangMuon;
    }
}