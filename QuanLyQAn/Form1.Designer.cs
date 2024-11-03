namespace QuanLyQAn
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.slidebarPanel = new System.Windows.Forms.Panel();
            this.btnTaiKhoan = new System.Windows.Forms.Button();
            this.btnGoiMon = new System.Windows.Forms.Button();
            this.btnDSBan = new System.Windows.Forms.Button();
            this.btnThucDon = new System.Windows.Forms.Button();
            this.btnTrangChu = new System.Windows.Forms.Button();
            this.mainContentPanel = new System.Windows.Forms.Panel();
            this.slidebarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // slidebarPanel
            // 
            this.slidebarPanel.Controls.Add(this.btnTaiKhoan);
            this.slidebarPanel.Controls.Add(this.btnGoiMon);
            this.slidebarPanel.Controls.Add(this.btnDSBan);
            this.slidebarPanel.Controls.Add(this.btnThucDon);
            this.slidebarPanel.Controls.Add(this.btnTrangChu);
            this.slidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.slidebarPanel.Location = new System.Drawing.Point(0, 0);
            this.slidebarPanel.Name = "slidebarPanel";
            this.slidebarPanel.Size = new System.Drawing.Size(152, 650);
            this.slidebarPanel.TabIndex = 0;
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiKhoan.Image = ((System.Drawing.Image)(resources.GetObject("btnTaiKhoan.Image")));
            this.btnTaiKhoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaiKhoan.Location = new System.Drawing.Point(0, 180);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(152, 45);
            this.btnTaiKhoan.TabIndex = 4;
            this.btnTaiKhoan.Text = "Tài khoản";
            this.btnTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTaiKhoan.UseVisualStyleBackColor = false;
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click_1);
            // 
            // btnGoiMon
            // 
            this.btnGoiMon.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGoiMon.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoiMon.Image = ((System.Drawing.Image)(resources.GetObject("btnGoiMon.Image")));
            this.btnGoiMon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGoiMon.Location = new System.Drawing.Point(0, 135);
            this.btnGoiMon.Name = "btnGoiMon";
            this.btnGoiMon.Size = new System.Drawing.Size(152, 45);
            this.btnGoiMon.TabIndex = 3;
            this.btnGoiMon.Text = "Gọi món";
            this.btnGoiMon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGoiMon.UseVisualStyleBackColor = true;
            this.btnGoiMon.Click += new System.EventHandler(this.btnGoiMon_Click_1);
            // 
            // btnDSBan
            // 
            this.btnDSBan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDSBan.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDSBan.Image = ((System.Drawing.Image)(resources.GetObject("btnDSBan.Image")));
            this.btnDSBan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDSBan.Location = new System.Drawing.Point(0, 90);
            this.btnDSBan.Name = "btnDSBan";
            this.btnDSBan.Size = new System.Drawing.Size(152, 45);
            this.btnDSBan.TabIndex = 2;
            this.btnDSBan.Text = "DS Bàn";
            this.btnDSBan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDSBan.UseVisualStyleBackColor = true;
            this.btnDSBan.Click += new System.EventHandler(this.btnDSBan_Click_1);
            // 
            // btnThucDon
            // 
            this.btnThucDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThucDon.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThucDon.Image = ((System.Drawing.Image)(resources.GetObject("btnThucDon.Image")));
            this.btnThucDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThucDon.Location = new System.Drawing.Point(0, 45);
            this.btnThucDon.Name = "btnThucDon";
            this.btnThucDon.Size = new System.Drawing.Size(152, 45);
            this.btnThucDon.TabIndex = 1;
            this.btnThucDon.Text = "Thực đơn";
            this.btnThucDon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThucDon.UseVisualStyleBackColor = true;
            this.btnThucDon.Click += new System.EventHandler(this.btnThucDon_Click_1);
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTrangChu.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrangChu.Image = ((System.Drawing.Image)(resources.GetObject("btnTrangChu.Image")));
            this.btnTrangChu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrangChu.Location = new System.Drawing.Point(0, 0);
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.Size = new System.Drawing.Size(152, 45);
            this.btnTrangChu.TabIndex = 0;
            this.btnTrangChu.Text = "Trang chủ";
            this.btnTrangChu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTrangChu.UseVisualStyleBackColor = true;
            this.btnTrangChu.Click += new System.EventHandler(this.btnTrangChu_Click_1);
            // 
            // mainContentPanel
            // 
            this.mainContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContentPanel.Location = new System.Drawing.Point(152, 0);
            this.mainContentPanel.Name = "mainContentPanel";
            this.mainContentPanel.Size = new System.Drawing.Size(755, 650);
            this.mainContentPanel.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 650);
            this.Controls.Add(this.mainContentPanel);
            this.Controls.Add(this.slidebarPanel);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.slidebarPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel slidebarPanel;
        private System.Windows.Forms.Button btnDSBan;
        private System.Windows.Forms.Button btnThucDon;
        private System.Windows.Forms.Button btnTrangChu;
        private System.Windows.Forms.Button btnTaiKhoan;
        private System.Windows.Forms.Button btnGoiMon;
        private System.Windows.Forms.Panel mainContentPanel;
    }
}