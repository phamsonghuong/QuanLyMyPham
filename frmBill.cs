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
                cmd.Parameters.AddWithValue("@date", txtDate.Text);
                cmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
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
    }
}
