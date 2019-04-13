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
    public partial class frmUser : Form
    {
        int i;
        string connectionString = @"Data Source=DESKTOP-BV4LABJ\SQLEXPRESS;Initial Catalog=QLMyPham;Integrated Security=True";

        public frmUser()
        {
            InitializeComponent();
        }

        private void frmUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string Query = "Insert into tbl_user values(@username,@password,@name,@gender,@phone,@address)";

                SqlCommand cmd = new SqlCommand(Query, conn);

                cmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
                if (txtPass.Text.Trim() == txtConfirmPass.Text.Trim())
                {
                    cmd.Parameters.AddWithValue("@password", txtConfirmPass.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đúng mật khẩu để xác nhận");
                    return;
                }
                cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                if (rbtnMale.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@gender", rbtnMale.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@gender", rbtnFemale.Text);
                }

                cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());

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
            string Query = "Select * from tbl_user";
            SqlDataAdapter sqladap = new SqlDataAdapter(Query, conn);
            DataTable dtbl = new DataTable();
            sqladap.Fill(dtbl);
            dgvUser.AutoGenerateColumns = false;
            dgvUser.DataSource = dtbl;
        }
        void NullTextbox()
        {
            txtUserName.Text = "";
            txtPass.Text = "";
            txtConfirmPass.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
        }

        private void dgvUser_DoubleClick(object sender, EventArgs e)
        {
            i = Convert.ToInt32(dgvUser.SelectedRows[0].Cells[0].Value);
            txtUserName.Text = dgvUser.SelectedRows[0].Cells[1].Value.ToString();
            txtPass.Text = dgvUser.SelectedRows[0].Cells[2].Value.ToString();
            txtName.Text = dgvUser.SelectedRows[0].Cells[3].Value.ToString();
            if (dgvUser.SelectedRows[0].Cells[4].Value.ToString() == "Nam")
            {
                rbtnMale.Checked = true;
            }
            else { rbtnFemale.Checked = true; }
            txtPhone.Text = dgvUser.SelectedRows[0].Cells[5].Value.ToString();
            txtAddress.Text = dgvUser.SelectedRows[0].Cells[6].Value.ToString();

            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnQuanTri.Enabled = false;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string Query = "Update tbl_user set username = @username, password = @password, name = @name, gender = @gender, phone = @phone, address = @address where userid = @userid";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@userid", i);
                cmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
                if (txtPass.Text.Trim() == txtConfirmPass.Text.Trim())
                {
                    cmd.Parameters.AddWithValue("@password", txtConfirmPass.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đúng mật khẩu để xác nhận");
                    return;
                }
                cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                if (rbtnMale.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@gender", rbtnMale.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@gender", rbtnFemale.Text);
                }
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

        private void frmUser_Load(object sender, EventArgs e)
        {
            BindGridView();
            btnThem.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string Query = "Delete from tbl_user where userid = @userid";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@userid", i);
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
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnQuanTri.Enabled = true;
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

        private void frmUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            //Application.Exit();
        }
    }
}
