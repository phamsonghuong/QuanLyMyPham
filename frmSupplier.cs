using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyMyPham
{
    public partial class frmSupplier : Form
    {
        string connectionString = @"Data Source=DESKTOP-BV4LABJ\SQLEXPRESS;Initial Catalog=QLMyPham;Integrated Security=True";

        public frmSupplier()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string Query = "Insert into tbl_supplier values(@name,@address,@phone)";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                conn.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Thêm thành công");
                    BindGridView();
                    NullTextbox();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
                conn.Close();

            }

        }

        void BindGridView()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string Query = "Select * from tbl_supplier";
            SqlDataAdapter sqladap = new SqlDataAdapter(Query, conn);
            DataTable dtbl = new DataTable();
            sqladap.Fill(dtbl);
            dgvSupplier.AutoGenerateColumns = false;
            dgvSupplier.DataSource = dtbl;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            NullTextbox();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            btnQuanTri.Enabled = true;
        }

        void NullTextbox()
        {
            txtName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnQuanTri_Click(object sender, EventArgs e)
        {
            frmDashboard Dash = new frmDashboard();
            this.Hide();
            Dash.Show();
        }

        int i;
        private void dgvSupplier_DoubleClick(object sender, EventArgs e)
        {
            i = Convert.ToInt32(dgvSupplier.SelectedRows[0].Cells[0].Value);
            txtName.Text = dgvSupplier.SelectedRows[0].Cells[1].Value.ToString();
            txtAddress.Text = dgvSupplier.SelectedRows[0].Cells[2].Value.ToString();
            txtPhone.Text = dgvSupplier.SelectedRows[0].Cells[3].Value.ToString();

            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnQuanTri.Enabled = false;

        }

        private void frmSupplier_Load(object sender, EventArgs e)
        {
            BindGridView();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void frmSupplier_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            //Application.Exit();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string Query = "Update tbl_supplier set name = @name, phone = @phone, address = @address where supplierid = @supplierid";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@supplierid", i);
                cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                conn.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Cập nhật thành công");
                    BindGridView();
                    NullTextbox();
                    btnThem.Enabled = true;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnQuanTri.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại");
                }
                conn.Close();

            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string Query = "Delete from tbl_supplier where supplierid = @supplierid";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@supplierid", i);
                conn.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Đã xóa thành công");
                    BindGridView();
                    NullTextbox();
                    btnThem.Enabled = true;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnQuanTri.Enabled = true;
                }

                else
                {
                    MessageBox.Show("Xóa không thành công");
                }
                conn.Close();

            }

        }

        private void frmSupplier_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }
    }
}
