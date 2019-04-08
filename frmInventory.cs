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
    public partial class frmInventory : Form
    {
        string connectionString = @"Data Source=DESKTOP-BV4LABJ\SQLEXPRESS;Initial Catalog=QLMyPham;Integrated Security=True";

        public frmInventory()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string Query = "Insert into tbl_inventory values(@name,@unit,@quantity,@description,@date)";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@unit", txtUnit.Text.Trim());
                cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(txtQuantity.Text.Trim()));
                cmd.Parameters.AddWithValue("@description", txtDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@date", txtDate.Text);

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
            string Query = "Select * from tbl_inventory";
            SqlDataAdapter sqladap = new SqlDataAdapter(Query, conn);
            DataTable dtbl = new DataTable();
            sqladap.Fill(dtbl);
            dgvInventory.AutoGenerateColumns = false;
            dgvInventory.DataSource = dtbl;
        }

        void NullTextbox()
        {
            txtName.Text = "";
            txtUnit.Text = "";
            txtQuantity.Text = "";
            txtDescription.Text = "";
        }

        int i;

        private void btnSua_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string Query = "Update tbl_inventory set name = @name, unit = @unit, quantity = @quantity, description = @description, date = @date where inventoryid = @inventoryid";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@inventoryid", i);
                cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@unit", txtUnit.Text.Trim());
                cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(txtQuantity.Text.Trim()));
                cmd.Parameters.AddWithValue("@description", txtDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@date", txtDate.Text);

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

        private void dgvInventory_DoubleClick(object sender, EventArgs e)
        {
            i = Convert.ToInt32(dgvInventory.SelectedRows[0].Cells[0].Value);
            txtName.Text = dgvInventory.SelectedRows[0].Cells[1].Value.ToString();
            txtUnit.Text = dgvInventory.SelectedRows[0].Cells[2].Value.ToString();
            txtQuantity.Text = dgvInventory.SelectedRows[0].Cells[3].Value.ToString();
            txtDate.Text = dgvInventory.SelectedRows[0].Cells[4].Value.ToString();
            txtDescription.Text = dgvInventory.SelectedRows[0].Cells[5].Value.ToString();
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnQuanTri.Enabled = false;
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {
            BindGridView();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string Query = "Delete from tbl_inventory where inventoryid = @inventoryid";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@inventoryid", i);
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            NullTextbox();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
    }
}
