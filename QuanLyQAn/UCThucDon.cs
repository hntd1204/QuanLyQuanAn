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
    public partial class UCThucDon : UserControl
    {
        private string connectionString = "Data Source=KHANHLINH\\SQLEXPRESS;Initial Catalog=QuanLyQuanAn;Integrated Security=True;";

        public UCThucDon()
        {
            InitializeComponent();
            LoadMenu();
            dgvThucDon.CellClick += dgvThucDon_CellClick;

            cbbLoai.Items.Add("Đồ ăn");
            cbbLoai.Items.Add("Đồ uống");
            cbbLoai.Items.Add("Ăn vặt - tráng miệng");

        }

        private void LoadMenuByCategory(string loaiMonAn)
        {
            string query = "SELECT id, tenMon, giaMon, ghiChu FROM ThucDon WHERE loaiMonAn = @loaiMonAn";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@loaiMonAn", loaiMonAn);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvThucDon.DataSource = dt;
            }
        }

        private void LoadMenu()
        {
            string query = "SELECT id, tenMon, giaMon, ghiChu, loaiMonAn FROM ThucDon";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvThucDon.DataSource = dt; // dgvThucDon là tên của DataGridView hiển thị danh sách món
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadMenu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadMenuByCategory("Đồ ăn");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadMenuByCategory("Đồ uống");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadMenuByCategory("Ăn vặt - tráng miệng");
        }


        private void dgvThucDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvThucDon.Rows[e.RowIndex];

                txtTenMon.Text = row.Cells["tenMon"].Value.ToString();
                txtGia.Text = row.Cells["giaMon"].Value.ToString();
                txtGhiChu.Text = row.Cells["ghiChu"].Value.ToString();
                cbbLoai.SelectedItem = row.Cells["loaiMonAn"].Value.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string tenMon = txtTenMon.Text;
            decimal giaMon;
            string ghiChu = txtGhiChu.Text;
            string loaiMonAn = cbbLoai.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(tenMon) || !decimal.TryParse(txtGia.Text, out giaMon))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và đúng thông tin!");
                return;
            }

            string query = "INSERT INTO ThucDon (tenMon, giaMon, ghiChu, loaiMonAn) VALUES (@tenMon, @giaMon, @ghiChu, @loaiMonAn)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tenMon", tenMon);
                cmd.Parameters.AddWithValue("@giaMon", giaMon);
                cmd.Parameters.AddWithValue("@ghiChu", ghiChu);
                cmd.Parameters.AddWithValue("@loaiMonAn", loaiMonAn);


                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dgvThucDon.SelectedRows.Count > 0)
            {
                string tenMon = txtTenMon.Text;
                decimal giaMon;
                string ghiChu = txtGhiChu.Text;
                string loaiMonAn = cbbLoai.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(tenMon) || !decimal.TryParse(txtGia.Text, out giaMon))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ và đúng thông tin!");
                    return;
                }

                int id = Convert.ToInt32(dgvThucDon.SelectedRows[0].Cells["id"].Value);

                string query = "UPDATE ThucDon SET tenMon = @tenMon, giaMon = @giaMon, ghiChu = @ghiChu, loaiMonAn = @loaiMonAn WHERE id = @id";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@tenMon", tenMon);
                    cmd.Parameters.AddWithValue("@giaMon", giaMon);
                    cmd.Parameters.AddWithValue("@ghiChu", ghiChu);
                    cmd.Parameters.AddWithValue("@loaiMonAn", loaiMonAn);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                LoadMenu(); 
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món để sửa!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dgvThucDon.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvThucDon.SelectedRows[0].Cells["id"].Value);

                string query = "DELETE FROM ThucDon WHERE id = @id";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                LoadMenu();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món để xóa!");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtTenMon.Text = "";
            txtGia.Text = "";
            txtGhiChu.Text = "";

            cbbLoai.SelectedIndex = -1; 

            dgvThucDon.ClearSelection();
        }




        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tenMon = txtTim.Text.Trim();
            string loaiMonAn = cbbLoai.SelectedItem?.ToString();

            string query = "SELECT id, tenMon, giaMon, ghiChu, loaiMonAn FROM ThucDon WHERE 1=1";

            if (!string.IsNullOrEmpty(tenMon))
            {
                query += " AND tenMon LIKE '%' + @tenMon + '%'";
            }

            if (!string.IsNullOrEmpty(loaiMonAn))
            {
                query += " AND loaiMonAn = @loaiMonAn";
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);

                if (!string.IsNullOrEmpty(tenMon))
                {
                    da.SelectCommand.Parameters.AddWithValue("@tenMon", tenMon);
                }
                if (!string.IsNullOrEmpty(loaiMonAn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@loaiMonAn", loaiMonAn);
                }

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvThucDon.DataSource = dt;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
