namespace WindowsForm_QLTV
{
    partial class FormQLSach
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // Khai báo Controls
            this.pnlDashboard = new System.Windows.Forms.Panel();
            this.pnlCardContainer = new System.Windows.Forms.FlowLayoutPanel(); // Panel chứa các Card sách
            this.btnNhaXuatBan = new System.Windows.Forms.Button();
            this.btnTacGia = new System.Windows.Forms.Button();
            this.btnQLSach = new System.Windows.Forms.Button();
            // Nút btnQuayLai đã được loại bỏ

            this.pnlDashboard.SuspendLayout();
            this.SuspendLayout();

            // --- pnlDashboard (Menu ngang hoặc trên) ---
            this.pnlDashboard.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.pnlDashboard.Controls.Add(this.btnNhaXuatBan);
            this.pnlDashboard.Controls.Add(this.btnTacGia);
            this.pnlDashboard.Controls.Add(this.btnQLSach);
            this.pnlDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDashboard.Location = new System.Drawing.Point(0, 0);
            this.pnlDashboard.Name = "pnlDashboard";
            this.pnlDashboard.Size = new System.Drawing.Size(900, 60);
            this.pnlDashboard.TabIndex = 0;

            // --- btnQLSach ---
            this.btnQLSach.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnQLSach.ForeColor = System.Drawing.Color.White;
            this.btnQLSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLSach.Location = new System.Drawing.Point(10, 10);
            this.btnQLSach.Name = "btnQLSach";
            this.btnQLSach.Size = new System.Drawing.Size(150, 40);
            this.btnQLSach.Text = "Quản Lý Sách";
            this.btnQLSach.UseVisualStyleBackColor = false;

            // --- btnTacGia ---
            this.btnTacGia.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnTacGia.ForeColor = System.Drawing.Color.White;
            this.btnTacGia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTacGia.Location = new System.Drawing.Point(170, 10);
            this.btnTacGia.Name = "btnTacGia";
            this.btnTacGia.Size = new System.Drawing.Size(150, 40);
            this.btnTacGia.Text = "Tác Giả";
            this.btnTacGia.UseVisualStyleBackColor = false;

            // --- btnNhaXuatBan ---
            this.btnNhaXuatBan.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnNhaXuatBan.ForeColor = System.Drawing.Color.White;
            this.btnNhaXuatBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhaXuatBan.Location = new System.Drawing.Point(330, 10);
            this.btnNhaXuatBan.Name = "btnNhaXuatBan";
            this.btnNhaXuatBan.Size = new System.Drawing.Size(150, 40);
            this.btnNhaXuatBan.Text = "Nhà Xuất Bản";
            this.btnNhaXuatBan.UseVisualStyleBackColor = false;

            // --- pnlCardContainer (Chứa các Card sách) ---
            this.pnlCardContainer.AutoScroll = true;
            this.pnlCardContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardContainer.Location = new System.Drawing.Point(0, 60);
            this.pnlCardContainer.Name = "pnlCardContainer";
            this.pnlCardContainer.Size = new System.Drawing.Size(900, 540);
            this.pnlCardContainer.TabIndex = 1;

            // --- FormQLSach ---
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.pnlCardContainer);
            this.Controls.Add(this.pnlDashboard);
            this.Name = "FormQLSach";
            this.Text = "Quản Lý Sách";
            this.pnlDashboard.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlDashboard;
        private System.Windows.Forms.FlowLayoutPanel pnlCardContainer;
        private System.Windows.Forms.Button btnQLSach;
        private System.Windows.Forms.Button btnTacGia;
        private System.Windows.Forms.Button btnNhaXuatBan;
        // Đã bỏ btnQuayLai
    }
}