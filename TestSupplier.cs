using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyMyPham;
using System.Data.SqlClient;


namespace QuanLyMyPham
{
    public class TestSupplier
    {
        public static string ktThemNCC(string name, string address, int phone)
        {
            string connectionString = @"Data Source=DESKTOP-BV4LABJ\SQLEXPRESS;Initial Catalog=QLMyPham;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string ten = name;
                string dc = address;
                int sdt = phone;

                string Query = "Insert into tbl_supplier values(@name,@address,@phone)";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@name",ten);
                cmd.Parameters.AddWithValue("@address", dc);
                cmd.Parameters.AddWithValue("@phone", sdt);
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
