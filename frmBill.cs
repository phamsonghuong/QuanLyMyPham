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
    public partial class frmBill : Form
    {
        string connectionString = @"Data Source=DESKTOP-BV4LABJ\SQLEXPRESS;Initial Catalog=QLMyPham;Integrated Security=True";
        public frmBill()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string Query = "Insert into tbl_bill values(@date,@username,@name,@productname,@price,@quantity,@total)";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
                cmd.Parameters.AddWithValue("@date", txtDate.Text);
               
                cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@productname", txtProductName.Text.Trim());
                cmd.Parameters.AddWithValue("@price", Convert.ToInt32(txtPrice.Text));
                cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(txtQuantity.Text));
                cmd.Parameters.AddWithValue("@total", Convert.ToInt32(txtTotal.Text));

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
            string Query = "Select * from tbl_bill";
            SqlDataAdapter sqladap = new SqlDataAdapter(Query, conn);
            DataTable dtbl = new DataTable();
            sqladap.Fill(dtbl);
            dgvBill.AutoGenerateColumns = false;
            dgvBill.DataSource = dtbl;
        }

        void NullTextbox()
        {
            txtName.Text = "";
            txtTotal.Text = "";
            txtUserName.Text = "";
            txtProductName.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            int sum = Convert.ToInt32(txtPrice.Text) * Convert.ToInt32(txtQuantity.Text);
            txtTotal.Text = sum.ToString();
        }

        private void btnQuanTri_Click(object sender, EventArgs e)
        {
            frmDashboard Dash = new frmDashboard();
            this.Hide();
            Dash.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmBill_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            NullTextbox();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            btnQuanTri.Enabled = true;
        }

        int i;

        private void btnSua_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string Query = "Update tbl_bill set date = @date, username = @username, name = @name, productname = @productname , price = @price , quantity = @quantity , total = @total where billid = @billid";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@billid", i);
                cmd.Parameters.AddWithValue("@date", txtDate.Text);
                cmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
                cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@productname", txtProductName.Text.Trim());
                cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(txtQuantity.Text.Trim()));
                cmd.Parameters.AddWithValue("@price", Convert.ToInt32(txtPrice.Text.Trim()));
                cmd.Parameters.AddWithValue("@total", Convert.ToInt32(txtTotal.Text.Trim()));
                conn.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Cập nhật thành công");
                    BindGridView();
                    NullTextbox();
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnThem.Enabled = true;
                    btnQuanTri.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại");
                }
                conn.Close();

            }
        }

        private void dgvBill_DoubleClick(object sender, EventArgs e)
        {
            i = Convert.ToInt32(dgvBill.SelectedRows[0].Cells[0].Value);
            txtUserName.Text = dgvBill.SelectedRows[0].Cells[1].Value.ToString();
            txtDate.Text = dgvBill.SelectedRows[0].Cells[2].Value.ToString();

           
            txtName.Text = dgvBill.SelectedRows[0].Cells[3].Value.ToString();
            txtProductName.Text = dgvBill.SelectedRows[0].Cells[4].Value.ToString();
            txtPrice.Text = dgvBill.SelectedRows[0].Cells[5].Value.ToString();
            txtQuantity.Text = dgvBill.SelectedRows[0].Cells[6].Value.ToString();
            txtTotal.Text = dgvBill.SelectedRows[0].Cells[7].Value.ToString();

            btnSua.Enabled = true;
            btnXoa.Enabled = true; 
            btnThem.Enabled = false;
            btnQuanTri.Enabled = false;

        }

        private void frmBill_Load(object sender, EventArgs e)
        {
            BindGridView();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
    }
}
