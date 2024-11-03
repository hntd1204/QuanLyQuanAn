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
    public partial class UCDSBan : UserControl
    {
        private string connectionString = "Data Source=KHANHLINH\\SQLEXPRESS;Initial Catalog=QuanLyQuanAn;Integrated Security=True;";

        public UCDSBan()
        {
            InitializeComponent();
            LoadDanhSachBan();
            dgvDSBan.CellClick += dgvDSBan_CellClick;
            SetUpTrangThaiComboBox();
        }

        private void SetUpTrangThaiComboBox()
        {
            cbbTrangThai.Items.Add("Đã đặt");
            cbbTrangThai.Items.Add("Trống");
            cbbTrangThai.Items.Add("Đang dùng");
        }
        private void LoadDanhSachBan()
        {
            string query = "SELECT idBan AS [ID], tenBan AS [Tên Bàn], trangThai AS [Trạng Thái] FROM DSBan";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvDSBan.DataSource = dt;
            }
        }

        private void dgvDSBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDSBan.Rows[e.RowIndex];
                txtId.Text = row.Cells["ID"].Value.ToString();
                txtTenBan.Text = row.Cells["Tên Bàn"].Value.ToString();
                cbbTrangThai.SelectedItem = row.Cells["Trạng Thái"].Value.ToString();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string tenBan = txtTenBan.Text;
            string trangThai = cbbTrangThai.SelectedItem.ToString();

            string query = "INSERT INTO DSBan (tenBan, trangThai) VALUES (@tenBan, @trangThai)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tenBan", tenBan);
                cmd.Parameters.AddWithValue("@trangThai", trangThai);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadDanhSachBan();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                int id = Convert.ToInt32(txtId.Text);
                string tenBan = txtTenBan.Text;
                string trangThai = cbbTrangThai.SelectedItem.ToString();

                string query = "UPDATE DSBan SET tenBan = @tenBan, trangThai = @trangThai WHERE idBan = @id";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@tenBan", tenBan);
                    cmd.Parameters.AddWithValue("@trangThai", trangThai);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                LoadDanhSachBan();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bàn để cập nhật!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                int id = Convert.ToInt32(txtId.Text);

                string query = "DELETE FROM DSBan WHERE idBan = @id";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                LoadDanhSachBan();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bàn để xóa!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtTenBan.Clear();
            cbbTrangThai.SelectedIndex = -1;

            LoadDanhSachBan();
        }
    }
}
