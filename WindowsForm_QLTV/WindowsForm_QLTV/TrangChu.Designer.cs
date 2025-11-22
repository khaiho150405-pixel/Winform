using System.Drawing;
using System.Windows.Forms;

namespace WindowsForm_QLTV
{
    partial class TrangChu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.lblCategoryFilter = new System.Windows.Forms.Label();
            this.cmbTheLoai = new System.Windows.Forms.ComboBox();
            this.lblNXBFilter = new System.Windows.Forms.Label();
            this.cmbNXB = new System.Windows.Forms.ComboBox();
            this.txtSearchBook = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlBookCardsContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlFilterBar = new System.Windows.Forms.Panel();
            this.pnlFilterBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCategoryFilter
            // 
            this.lblCategoryFilter.AutoSize = true;
            this.lblCategoryFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCategoryFilter.Location = new System.Drawing.Point(38, 23);
            this.lblCategoryFilter.Name = "lblCategoryFilter";
            this.lblCategoryFilter.Size = new System.Drawing.Size(74, 23);
            this.lblCategoryFilter.TabIndex = 1;
            this.lblCategoryFilter.Text = "Thể loại:";
            // 
            // cmbTheLoai
            // 
            this.cmbTheLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTheLoai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTheLoai.FormattingEnabled = true;
            this.cmbTheLoai.Location = new System.Drawing.Point(125, 20);
            this.cmbTheLoai.Name = "cmbTheLoai";
            this.cmbTheLoai.Size = new System.Drawing.Size(150, 31);
            this.cmbTheLoai.TabIndex = 2;
            // 
            // lblNXBFilter
            // 
            this.lblNXBFilter.AutoSize = true;
            this.lblNXBFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNXBFilter.Location = new System.Drawing.Point(285, 23);
            this.lblNXBFilter.Name = "lblNXBFilter";
            this.lblNXBFilter.Size = new System.Drawing.Size(71, 23);
            this.lblNXBFilter.TabIndex = 3;
            this.lblNXBFilter.Text = "Nhà XB:";
            // 
            // cmbNXB
            // 
            this.cmbNXB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNXB.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbNXB.FormattingEnabled = true;
            this.cmbNXB.Location = new System.Drawing.Point(375, 20);
            this.cmbNXB.Name = "cmbNXB";
            this.cmbNXB.Size = new System.Drawing.Size(150, 31);
            this.cmbNXB.TabIndex = 4;
            // 
            // txtSearchBook
            // 
            this.txtSearchBook.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearchBook.Location = new System.Drawing.Point(540, 20);
            this.txtSearchBook.Name = "txtSearchBook";
            this.txtSearchBook.Size = new System.Drawing.Size(150, 30);
            this.txtSearchBook.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(700, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 30);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // pnlBookCardsContainer
            // 
            this.pnlBookCardsContainer.AutoScroll = true;
            this.pnlBookCardsContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBookCardsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBookCardsContainer.Location = new System.Drawing.Point(0, 60);
            this.pnlBookCardsContainer.Name = "pnlBookCardsContainer";
            this.pnlBookCardsContainer.Padding = new System.Windows.Forms.Padding(10);
            this.pnlBookCardsContainer.Size = new System.Drawing.Size(800, 690);
            this.pnlBookCardsContainer.TabIndex = 7;
            // 
            // pnlFilterBar
            // 
            this.pnlFilterBar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlFilterBar.Controls.Add(this.btnSearch);
            this.pnlFilterBar.Controls.Add(this.txtSearchBook);
            this.pnlFilterBar.Controls.Add(this.cmbNXB);
            this.pnlFilterBar.Controls.Add(this.lblNXBFilter);
            this.pnlFilterBar.Controls.Add(this.cmbTheLoai);
            this.pnlFilterBar.Controls.Add(this.lblCategoryFilter);
            this.pnlFilterBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBar.Location = new System.Drawing.Point(0, 0);
            this.pnlFilterBar.Name = "pnlFilterBar";
            this.pnlFilterBar.Size = new System.Drawing.Size(800, 60);
            this.pnlFilterBar.TabIndex = 0;
            // 
            // TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 750);
            this.Controls.Add(this.pnlBookCardsContainer);
            this.Controls.Add(this.pnlFilterBar);
            this.Name = "TrangChu";
            this.Text = "Danh Sách Sách";
            this.pnlFilterBar.ResumeLayout(false);
            this.pnlFilterBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // KHAI BÁO CÁC BIẾN THÀNH PHẦN (CONTROLS)
        private System.Windows.Forms.Panel pnlFilterBar;
        private System.Windows.Forms.Label lblCategoryFilter;
        private System.Windows.Forms.Label lblNXBFilter;
        private System.Windows.Forms.TextBox txtSearchBook;
        private System.Windows.Forms.ComboBox cmbTheLoai;
        private System.Windows.Forms.ComboBox cmbNXB;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.FlowLayoutPanel pnlBookCardsContainer;
    }
}