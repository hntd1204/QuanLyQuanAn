using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQAn
{
    public partial class Form1 : Form
    {
        private UCTrangChu ucTrangChu = new UCTrangChu();
        private UCThucDon ucThucDon = new UCThucDon();
        private UCDSBan ucDSBan = new UCDSBan();
        private UCTaiKhoan ucTaiKhoan = new UCTaiKhoan();
        private UCGoiMon ucGoiMon = new UCGoiMon();
        private UCLogin ucLogin = new UCLogin();
        public Form1()
        {
            InitializeComponent();

            slidebarPanel.Visible = false;

            mainContentPanel.Controls.Add(ucLogin);
            ucLogin.Dock = DockStyle.Fill;

            ucLogin.LoginSuccess += OnLoginSuccess;
        }

        private void OnLoginSuccess(object sender, EventArgs e)
        {
            slidebarPanel.Visible = true;

            ShowUserControl(ucTrangChu);
        }

        private void UcLogin_LoginSuccess(object sender, EventArgs e)
        {
            ShowUserControl(ucTrangChu);
        }
        private void ShowUserControl(UserControl uc)
        {
            mainContentPanel.Controls.Clear();
            mainContentPanel.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            uc.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnTrangChu_Click_1(object sender, EventArgs e)
        {
            ShowUserControl(ucTrangChu);
        }

        private void btnThucDon_Click_1(object sender, EventArgs e)
        {
            ShowUserControl(ucThucDon);
        }

        private void btnDSBan_Click_1(object sender, EventArgs e)
        {
            ShowUserControl(ucDSBan);
        }

        private void btnGoiMon_Click_1(object sender, EventArgs e)
        {
            ShowUserControl(ucGoiMon);
        }

        private void btnTaiKhoan_Click_1(object sender, EventArgs e)
        {
            ShowUserControl(ucTaiKhoan);
        }
    }
}
