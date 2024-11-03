using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQAn
{
    public partial class FrmUpdatePass : Form
    {
        private string connectionString = "Data Source=KHANHLINH\\SQLEXPRESS;Initial Catalog=QuanLyQuanAn;Integrated Security=True;";
        private int userId;
        public FrmUpdatePass(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadUserData();
        }
        private void LoadUserData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT tenDangNhap, tenHienThi FROM TaiKhoan WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", userId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtTenDangNhap.Text = reader["tenDangNhap"].ToString();
                            txtTenHienThi.Text = reader["tenHienThi"].ToString();
                        }
                    }
                }
            }
        }
        private void FrmUpdatePass_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMatKhauHienTai.Text) || string.IsNullOrEmpty(txtMatKhauMoi.Text) || string.IsNullOrEmpty(txtNhapLaiMatKhauMoi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (txtMatKhauMoi.Text != txtNhapLaiMatKhauMoi.Text)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Kiểm tra mật khẩu hiện tại
                string checkPasswordQuery = "SELECT matKhau FROM TaiKhoan WHERE id = @id";
                using (SqlCommand checkCmd = new SqlCommand(checkPasswordQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@id", userId);
                    string currentPassword = checkCmd.ExecuteScalar()?.ToString();

                    if (currentPassword != txtMatKhauHienTai.Text)
                    {
                        MessageBox.Show("Mật khẩu hiện tại không đúng!");
                        return;
                    }
                }

                // Cập nhật mật khẩu mới
                string updatePasswordQuery = "UPDATE TaiKhoan SET matKhau = @matKhauMoi WHERE id = @id";
                using (SqlCommand updateCmd = new SqlCommand(updatePasswordQuery, conn))
                {
                    updateCmd.Parameters.AddWithValue("@matKhauMoi", txtMatKhauMoi.Text);
                    updateCmd.Parameters.AddWithValue("@id", userId);

                    updateCmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật mật khẩu thành công!");
                    this.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
