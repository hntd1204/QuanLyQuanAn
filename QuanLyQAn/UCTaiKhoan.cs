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
    public partial class UCTaiKhoan : UserControl
    {
        private string connectionString = "Data Source=KHANHLINH\\SQLEXPRESS;Initial Catalog=QuanLyQuanAn;Integrated Security=True;";

        public UCTaiKhoan()
        {
            InitializeComponent();
            LoadUserData();
            dgvTaiKhoan.CellClick += dgvTaiKhoan_CellClick;
            btnCapNhatTK.Click += btnCapNhatTK_Click;
        }

        private void LoadUserData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id, tenDangNhap, tenHienThi, chucVu FROM TaiKhoan";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvTaiKhoan.DataSource = dt;
            }
        }



        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];
                numId.Value = Convert.ToInt32(row.Cells["id"].Value);
                txtTenDangNhap.Text = row.Cells["tenDangNhap"].Value.ToString();
                txtTenHienThi.Text = row.Cells["tenHienThi"].Value.ToString();
                txtChucVu.Text = row.Cells["chucVu"].Value.ToString();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO TaiKhoan (tenDangNhap, tenHienThi, chucVu, matKhau) VALUES (@tenDangNhap, @tenHienThi, @chucVu, @matKhau)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tenDangNhap", txtTenDangNhap.Text);
                    cmd.Parameters.AddWithValue("@tenHienThi", txtTenHienThi.Text);
                    cmd.Parameters.AddWithValue("@chucVu", txtChucVu.Text);
                    cmd.Parameters.AddWithValue("@matKhau", "123456");

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm tài khoản thành công!");
                    LoadUserData();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM TaiKhoan WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", (int)numId.Value);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa tài khoản thành công!");
                    LoadUserData();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numId.Value = 0;
            txtTenDangNhap.Clear();
            txtTenHienThi.Clear();
            txtChucVu.Clear();
            LoadUserData();
        }
        private void btnCapNhatTK_Click(object sender, EventArgs e)
        {
            if (numId.Value > 0)
            {
                int userId = (int)numId.Value;

                FrmUpdatePass updatePassForm = new FrmUpdatePass(userId);
                updatePassForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tài khoản để cập nhật mật khẩu.");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
