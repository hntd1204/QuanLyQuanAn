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
    public partial class UCGoiMon : UserControl
    {
        private string connectionString = "Data Source=KHANHLINH\\SQLEXPRESS;Initial Catalog=QuanLyQuanAn;Integrated Security=True;";

        public UCGoiMon()
        {
            InitializeComponent();
            LoadMenu();
            LoadBanDangDung();
            dgvThucDon.CellClick += dgvThucDon_CellClick;
            cbbChonBan.SelectedIndexChanged += cbbChonBan_SelectedIndexChanged;
        }

        private void LoadMenu()
        {
            string query = "SELECT id, tenMon, giaMon, ghiChu, loaiMonAn FROM ThucDon";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvThucDon.DataSource = dt;
                LoadChiTietGoiMon();

            }
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

        private void dgvThucDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvThucDon.Rows[e.RowIndex];
                string tenMon = row.Cells["tenMon"].Value.ToString();

                cbbChonMon.Items.Clear(); 
                cbbChonMon.Items.Add(tenMon);
                cbbChonMon.SelectedIndex = 0;
            }
        }


        private void LoadBanDangDung()
        {
            string query = "SELECT tenBan FROM DSBan WHERE trangThai = N'Đang dùng'";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cbbChonBan.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        cbbChonBan.Items.Add(row["tenBan"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi tải danh sách bàn: " + ex.Message);
                }
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

        private void button5_Click(object sender, EventArgs e)
        {
            string tenMon = cbbChonMon.SelectedItem.ToString();
            int soLuong = int.Parse(txtSoLuong.Text);
            int idBan = GetIdBanFromName(cbbChonBan.SelectedItem.ToString());

            decimal giaMon = 0;
            int idMon = 0; 
            foreach (DataGridViewRow row in dgvThucDon.Rows)
            {
                if (row.Cells["tenMon"].Value.ToString() == tenMon)
                {
                    giaMon = Convert.ToDecimal(row.Cells["giaMon"].Value);
                    idMon = Convert.ToInt32(row.Cells["id"].Value);
                    break;
                }
            }


            string query = "INSERT INTO ChiTietGoiMon (tenMonDaChon, soLuong, giaMon, idMon, idBan) VALUES (@tenMon, @soLuong, @giaMon, @idMon, @idBan)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tenMon", tenMon);
                cmd.Parameters.AddWithValue("@soLuong", soLuong);
                cmd.Parameters.AddWithValue("@giaMon", giaMon);
                cmd.Parameters.AddWithValue("@idMon", idMon);
                cmd.Parameters.AddWithValue("@idBan", idBan);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

  
            LoadChiTietGoiMon(idBan);
        }

        private void LoadChiTietGoiMon(int? idBan = null)
        {
            string query = "SELECT tenMonDaChon, giaMon, soLuong FROM ChiTietGoiMon";
            if (idBan.HasValue)
            {
                query += " WHERE idBan = @idBan";
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                if (idBan.HasValue)
                {
                    da.SelectCommand.Parameters.AddWithValue("@idBan", idBan.Value);
                }

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvChiTietGoiMon.DataSource = dt;

                txtTongTien.Text = CalculateTotalPrice(dt).ToString("N0") + " VND";
            }
        }

        private decimal CalculateTotalPrice(DataTable dt)
        {
            decimal total = 0;
            foreach (DataRow row in dt.Rows)
            {
                decimal giaMon = Convert.ToDecimal(row["giaMon"]);
                int soLuong = Convert.ToInt32(row["soLuong"]);
                total += giaMon * soLuong;
            }
            return total;
        }
        private void cbbChonBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbChonBan.SelectedItem != null)
            {
                string selectedBan = cbbChonBan.SelectedItem.ToString();

                int idBan = GetIdBanFromName(selectedBan);


                LoadChiTietGoiMon(idBan);
            }
        }

        private int GetIdBanFromName(string tenBan)
        {
            string query = "SELECT idBan FROM DSBan WHERE tenBan = @tenBan";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tenBan", tenBan);
                conn.Open();

                return (int)cmd.ExecuteScalar();
            }
        }



        private void button6_Click(object sender, EventArgs e)
        {
            if (dgvChiTietGoiMon.SelectedRows.Count > 0)
            {
                dgvChiTietGoiMon.Rows.RemoveAt(dgvChiTietGoiMon.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món để xóa!");
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {

        }

  

        private void cbbChonMon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
