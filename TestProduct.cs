using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QuanLyMyPham
{
    public class TestProduct
    {
        public static string ktThemSanpham(string name, double price, int quantity, string unit, string suppliername)
        {
            string connectionString = @"Data Source=DESKTOP-BV4LABJ\SQLEXPRESS;Initial Catalog=QLMyPham;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string ten = name;
                string donvi = unit;
                string tenncc = suppliername;
                double gia = price;
                int soluong = quantity;

                string Query = "Insert into tbl_product values(@name,@price,@quantity,@unit,@suppliername)";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@name", ten);
                cmd.Parameters.AddWithValue("@price", gia);
                cmd.Parameters.AddWithValue("@quantity", soluong);
                cmd.Parameters.AddWithValue("@unit", donvi);
                cmd.Parameters.AddWithValue("@suppliername", tenncc);

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
