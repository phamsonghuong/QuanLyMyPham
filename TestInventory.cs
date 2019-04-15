using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QuanLyMyPham
{
    public class TestInventory
    {
        public static string ktThemTonkho(string name, string unit, int quantity, string des, string date)
        {
            string connectionString = @"Data Source=DESKTOP-BV4LABJ\SQLEXPRESS;Initial Catalog=QLMyPham;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string ten = name;
                string mota = des;
                string donvi = unit;
                int soluong = quantity;
                string ngay = date;

                string Query = "Insert into tbl_inventory values(@name,@unit,@quantity,@description,@date)";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@name", ten);
                cmd.Parameters.AddWithValue("@unit", donvi);
                cmd.Parameters.AddWithValue("@quantity", soluong);
                cmd.Parameters.AddWithValue("@description", mota);
                cmd.Parameters.AddWithValue("@date", ngay);

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
