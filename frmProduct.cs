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
    public partial class frmProduct : Form
    {
        int i;
        string connectionString = @"Data Source=DESKTOP-BV4LABJ\SQLEXPRESS;Initial Catalog=QLMyPham;Integrated Security=True";

        public frmProduct()
        {
            InitializeComponent();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            BindGridView();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        void BindGridView()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string Query = "Select * from tbl_product";
            SqlDataAdapter sqladap = new SqlDataAdapter(Query, conn);
            DataTable dtbl = new DataTable();
            sqladap.Fill(dtbl);
            dgvProduct.AutoGenerateColumns = false;
            dgvProduct.DataSource = dtbl;
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
            txtPrice.Text = "";
            txtUnit.Text = "";
            txtSupplierName.Text = "";
            txtQuantity.Text = "";
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string Query = "Insert into tbl_product values(@name,@price,@quantity,@unit,@suppliername)";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@price", Convert.ToInt32(txtPrice.Text));
                cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(txtQuantity.Text));
                cmd.Parameters.AddWithValue("@unit", txtUnit.Text.Trim());
                cmd.Parameters.AddWithValue("@suppliername", txtSupplierName.Text.Trim());

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

        private void btnSua_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string Query = "Update tbl_product set name = @name, price = @price, quantity = @quantity, unit = @unit, suppliername = @suppliername where productid = @productid";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@productid", i);
                cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@price", Convert.ToInt32(txtPrice.Text));
                cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(txtQuantity.Text));
                cmd.Parameters.AddWithValue("@unit", txtUnit.Text.Trim());
                cmd.Parameters.AddWithValue("@suppliername", txtSupplierName.Text.Trim());
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

        private void dgvProduct_DoubleClick(object sender, EventArgs e)
        {
            i = Convert.ToInt32(dgvProduct.SelectedRows[0].Cells[0].Value);
            txtName.Text = dgvProduct.SelectedRows[0].Cells[1].Value.ToString();
            txtPrice.Text = dgvProduct.SelectedRows[0].Cells[2].Value.ToString();
            txtQuantity.Text = dgvProduct.SelectedRows[0].Cells[3].Value.ToString();
            txtUnit.Text = dgvProduct.SelectedRows[0].Cells[4].Value.ToString();
            txtSupplierName.Text = dgvProduct.SelectedRows[0].Cells[5].Value.ToString();
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnQuanTri.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string Query = "Delete from tbl_product where productid = @productid";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@productid", i);
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

        //private void frrmProduct_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    Application.Exit();
        //}
    }
}
