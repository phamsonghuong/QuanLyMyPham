using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QuanLyMyPham
{
    public class TestBill
    {
        public static string ktThemHoaDon(string date, string username, string name, string productname, double price, int quantity, double total)
        {
            string connectionString = @"Data Source=DESKTOP-BV4LABJ\SQLEXPRESS;Initial Catalog=QLMyPham;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string ngay = date;
                string nguoilap = username;
                string ten = name;
                string tensp = productname;
                double gia = price;
                int soluong = quantity;
                double tong = total;

                string Query = "Insert into tbl_bill values(@date,@username,@name,@productname,@price,@quantity,@total)";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@username", nguoilap);
                cmd.Parameters.AddWithValue("@date", ngay);

                cmd.Parameters.AddWithValue("@name", ten);
                cmd.Parameters.AddWithValue("@productname", tensp);
                cmd.Parameters.AddWithValue("@price", gia);
                cmd.Parameters.AddWithValue("@quantity", soluong);
                cmd.Parameters.AddWithValue("@total", tong);

                conn.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    return "1";
                }
                else
                {
                    return "0";

                }
                conn.Close();



            }
        }
    }
}
