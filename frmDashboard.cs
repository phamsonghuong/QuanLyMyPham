using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyMyPham
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            frmLogin Login = new frmLogin();
            this.Hide();
            Login.Show();
        }

        private void btnNguoiDung_Click(object sender, EventArgs e)
        {
            frmUser User = new frmUser();
            this.Hide();
            User.Show();
        }

        private void frmDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            frmProduct Product = new frmProduct();
            this.Hide();
            Product.Show();
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            frmSupplier Supplier = new frmSupplier();
            this.Hide();
            Supplier.Show();
        }

        private void btnTonKho_Click(object sender, EventArgs e)
        {
            frmInventory Inventory = new frmInventory();
            this.Hide();
            Inventory.Show();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            frmBill Bill = new frmBill();
            this.Hide();
            Bill.Show();
        }

        private void frmDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("Bạn muốn thoát?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            // Application.Exit();
        }

        
    }
}
