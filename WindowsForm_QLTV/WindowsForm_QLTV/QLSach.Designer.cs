namespace WindowsForm_QLTV
{
    partial class FormQLSach
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
            this.pnlCardContainer = new System.Windows.Forms.Panel();
            this.lblCardHeader = new System.Windows.Forms.Label();
            this.pnlTopDashboard = new System.Windows.Forms.Panel();
            this.pnlNhaXuatBan = new System.Windows.Forms.Panel();
            this.btnNhaXuatBan = new System.Windows.Forms.Button();
            this.lblNhaXuatBan = new System.Windows.Forms.Label();
            this.pnlTheLoai = new System.Windows.Forms.Panel();
            this.btnTheLoai = new System.Windows.Forms.Button();
            this.lblTheLoai = new System.Windows.Forms.Label();
            this.pnlTacGia = new System.Windows.Forms.Panel();
            this.btnTacGia = new System.Windows.Forms.Button();
            this.lblTacGia = new System.Windows.Forms.Label();
            this.pnlQLSach = new System.Windows.Forms.Panel();
            this.btnQLSach = new System.Windows.Forms.Button();
            this.lblQLSach = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.pnlBackground.SuspendLayout();
            this.pnlTopDashboard.SuspendLayout();
            this.pnlNhaXuatBan.SuspendLayout();
            this.pnlTheLoai.SuspendLayout();
            this.pnlTacGia.SuspendLayout();
            this.pnlQLSach.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBackground
            // 
            this.pnlBackground.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBackground.Controls.Add(this.pnlCardContainer);
            this.pnlBackground.Controls.Add(this.lblCardHeader);
            this.pnlBackground.Controls.Add(this.pnlTopDashboard);
            this.pnlBackground.Controls.Add(this.pnlHeader);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(1000, 700);
            this.pnlBackground.TabIndex = 0;
            // 
            // pnlCardContainer
            // 
            this.pnlCardContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right))); // Neo 4 phía
            this.pnlCardContainer.AutoScroll = true;
            this.pnlCardContainer.Location = new System.Drawing.Point(30, 300);
            this.pnlCardContainer.Name = "pnlCardContainer";
            this.pnlCardContainer.Size = new System.Drawing.Size(940, 380);
            this.pnlCardContainer.TabIndex = 3;
            // 
            // lblCardHeader
            // 
            this.lblCardHeader.AutoSize = true;
            this.lblCardHeader.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblCardHeader.Location = new System.Drawing.Point(25, 250);
            this.lblCardHeader.Name = "lblCardHeader";
            this.lblCardHeader.Size = new System.Drawing.Size(193, 31);
            this.lblCardHeader.TabIndex = 2;
            this.lblCardHeader.Text = "QUẢN LÝ SÁCH";
            // 
            // pnlTopDashboard
            // 
            this.pnlTopDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right))); // Neo trái, trên, phải
            this.pnlTopDashboard.Controls.Add(this.pnlNhaXuatBan);
            this.pnlTopDashboard.Controls.Add(this.pnlTheLoai);
            this.pnlTopDashboard.Controls.Add(this.pnlTacGia);
            this.pnlTopDashboard.Controls.Add(this.pnlQLSach);
            this.pnlTopDashboard.Location = new System.Drawing.Point(30, 80);
            this.pnlTopDashboard.Name = "pnlTopDashboard";
            this.pnlTopDashboard.Size = new System.Drawing.Size(940, 150);
            this.pnlTopDashboard.TabIndex = 1;
            // 
            // pnlNhaXuatBan
            // 
            this.pnlNhaXuatBan.BackColor = System.Drawing.Color.White;
            this.pnlNhaXuatBan.Controls.Add(this.btnNhaXuatBan);
            this.pnlNhaXuatBan.Controls.Add(this.lblNhaXuatBan);
            this.pnlNhaXuatBan.Location = new System.Drawing.Point(710, 10);
            this.pnlNhaXuatBan.Name = "pnlNhaXuatBan";
            this.pnlNhaXuatBan.Size = new System.Drawing.Size(220, 130);
            this.pnlNhaXuatBan.TabIndex = 3;
            // 
            // btnNhaXuatBan
            // 
            this.btnNhaXuatBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnNhaXuatBan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnNhaXuatBan.FlatAppearance.BorderSize = 0;
            this.btnNhaXuatBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhaXuatBan.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhaXuatBan.ForeColor = System.Drawing.Color.White;
            this.btnNhaXuatBan.Location = new System.Drawing.Point(0, 90);
            this.btnNhaXuatBan.Name = "btnNhaXuatBan";
            this.btnNhaXuatBan.Size = new System.Drawing.Size(220, 40);
            this.btnNhaXuatBan.TabIndex = 2;
            this.btnNhaXuatBan.Text = "Nhà Xuất Bản";
            this.btnNhaXuatBan.UseVisualStyleBackColor = false;
            // 
            // lblNhaXuatBan
            // 
            this.lblNhaXuatBan.AutoSize = true;
            this.lblNhaXuatBan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNhaXuatBan.Location = new System.Drawing.Point(10, 10);
            this.lblNhaXuatBan.Name = "lblNhaXuatBan";
            this.lblNhaXuatBan.Size = new System.Drawing.Size(126, 23);
            this.lblNhaXuatBan.TabIndex = 1;
            this.lblNhaXuatBan.Text = "NHÀ XUẤT BẢN";
            // 
            // pnlTheLoai
            // 
            this.pnlTheLoai.BackColor = System.Drawing.Color.White;
            this.pnlTheLoai.Controls.Add(this.btnTheLoai);
            this.pnlTheLoai.Controls.Add(this.lblTheLoai);
            this.pnlTheLoai.Location = new System.Drawing.Point(475, 10);
            this.pnlTheLoai.Name = "pnlTheLoai";
            this.pnlTheLoai.Size = new System.Drawing.Size(220, 130);
            this.pnlTheLoai.TabIndex = 2;
            // 
            // btnTheLoai
            // 
            this.btnTheLoai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnTheLoai.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnTheLoai.FlatAppearance.BorderSize = 0;
            this.btnTheLoai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTheLoai.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTheLoai.ForeColor = System.Drawing.Color.White;
            this.btnTheLoai.Location = new System.Drawing.Point(0, 90);
            this.btnTheLoai.Name = "btnTheLoai";
            this.btnTheLoai.Size = new System.Drawing.Size(220, 40);
            this.btnTheLoai.TabIndex = 2;
            this.btnTheLoai.Text = "Thể Loại";
            this.btnTheLoai.UseVisualStyleBackColor = false;
            // 
            // lblTheLoai
            // 
            this.lblTheLoai.AutoSize = true;
            this.lblTheLoai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTheLoai.Location = new System.Drawing.Point(10, 10);
            this.lblTheLoai.Name = "lblTheLoai";
            this.lblTheLoai.Size = new System.Drawing.Size(79, 23);
            this.lblTheLoai.TabIndex = 1;
            this.lblTheLoai.Text = "THỂ LOẠI";
            // 
            // pnlTacGia
            // 
            this.pnlTacGia.BackColor = System.Drawing.Color.White;
            this.pnlTacGia.Controls.Add(this.btnTacGia);
            this.pnlTacGia.Controls.Add(this.lblTacGia);
            this.pnlTacGia.Location = new System.Drawing.Point(240, 10);
            this.pnlTacGia.Name = "pnlTacGia";
            this.pnlTacGia.Size = new System.Drawing.Size(220, 130);
            this.pnlTacGia.TabIndex = 1;
            // 
            // btnTacGia
            // 
            this.btnTacGia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnTacGia.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnTacGia.FlatAppearance.BorderSize = 0;
            this.btnTacGia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTacGia.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTacGia.ForeColor = System.Drawing.Color.White;
            this.btnTacGia.Location = new System.Drawing.Point(0, 90);
            this.btnTacGia.Name = "btnTacGia";
            this.btnTacGia.Size = new System.Drawing.Size(220, 40);
            this.btnTacGia.TabIndex = 2;
            this.btnTacGia.Text = "Tác Giả";
            this.btnTacGia.UseVisualStyleBackColor = false;
            // 
            // lblTacGia
            // 
            this.lblTacGia.AutoSize = true;
            this.lblTacGia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTacGia.Location = new System.Drawing.Point(10, 10);
            this.lblTacGia.Name = "lblTacGia";
            this.lblTacGia.Size = new System.Drawing.Size(68, 23);
            this.lblTacGia.TabIndex = 1;
            this.lblTacGia.Text = "TÁC GIẢ";
            // 
            // pnlQLSach
            // 
            this.pnlQLSach.BackColor = System.Drawing.Color.White;
            this.pnlQLSach.Controls.Add(this.btnQLSach);
            this.pnlQLSach.Controls.Add(this.lblQLSach);
            this.pnlQLSach.Location = new System.Drawing.Point(5, 10);
            this.pnlQLSach.Name = "pnlQLSach";
            this.pnlQLSach.Size = new System.Drawing.Size(220, 130);
            this.pnlQLSach.TabIndex = 0;
            // 
            // btnQLSach
            // 
            this.btnQLSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnQLSach.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnQLSach.FlatAppearance.BorderSize = 0;
            this.btnQLSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLSach.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLSach.ForeColor = System.Drawing.Color.White;
            this.btnQLSach.Location = new System.Drawing.Point(0, 90);
            this.btnQLSach.Name = "btnQLSach";
            this.btnQLSach.Size = new System.Drawing.Size(220, 40);
            this.btnQLSach.TabIndex = 2;
            this.btnQLSach.Text = "Quản Lý Sách";
            this.btnQLSach.UseVisualStyleBackColor = false;
            // 
            // lblQLSach
            // 
            this.lblQLSach.AutoSize = true;
            this.lblQLSach.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblQLSach.Location = new System.Drawing.Point(10, 10);
            this.lblQLSach.Name = "lblQLSach";
            this.lblQLSach.Size = new System.Drawing.Size(124, 23);
            this.lblQLSach.TabIndex = 1;
            this.lblQLSach.Text = "QUẢN LÝ SÁCH";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.pnlHeader.Controls.Add(this.lblFormTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1000, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.ForeColor = System.Drawing.Color.White;
            this.lblFormTitle.Location = new System.Drawing.Point(10, 6);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(217, 38);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "QUẢN LÝ SÁCH";
            // 
            // FormQLSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.pnlBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormQLSach";
            this.Text = "FormQLSach";
            this.pnlBackground.ResumeLayout(false);
            this.pnlBackground.PerformLayout();
            this.pnlTopDashboard.ResumeLayout(false);
            this.pnlNhaXuatBan.ResumeLayout(false);
            this.pnlNhaXuatBan.PerformLayout();
            this.pnlTheLoai.ResumeLayout(false);
            this.pnlTheLoai.PerformLayout();
            this.pnlTacGia.ResumeLayout(false);
            this.pnlTacGia.PerformLayout();
            this.pnlQLSach.ResumeLayout(false);
            this.pnlQLSach.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // Khai báo lại các controls
        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel pnlTopDashboard;
        private System.Windows.Forms.Panel pnlQLSach;
        private System.Windows.Forms.Label lblQLSach;
        private System.Windows.Forms.Button btnQLSach;
        private System.Windows.Forms.Panel pnlTacGia;
        private System.Windows.Forms.Button btnTacGia;
        private System.Windows.Forms.Label lblTacGia;
        private System.Windows.Forms.Panel pnlNhaXuatBan;
        private System.Windows.Forms.Button btnNhaXuatBan;
        private System.Windows.Forms.Label lblNhaXuatBan;
        private System.Windows.Forms.Panel pnlTheLoai;
        private System.Windows.Forms.Button btnTheLoai;
        private System.Windows.Forms.Label lblTheLoai;
        private System.Windows.Forms.Label lblCardHeader;
        private System.Windows.Forms.Panel pnlCardContainer;
    }
}