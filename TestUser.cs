using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QuanLyMyPham
{
    public class TestUser
    {
        /* public static string ktThemUser(string username, string password,string confirm, string name, string gender, int phone, string address)
         {
             string connectionString = @"Data Source=DESKTOP-BV4LABJ\SQLEXPRESS;Initial Catalog=QLMyPham;Integrated Security=True";

             using (SqlConnection conn = new SqlConnection(connectionString))
             {
                 string Query = "Insert into tbl_user values(@username,@password,@name,@gender,@phone,@address)";

                 SqlCommand cmd = new SqlCommand(Query, conn);
                 string tendangnhap = username;
                 string matkhau = password;
                 string xacnhan = confirm;
                 string ten = name;
                 string gioitinh = gender;
                 int sdt = phone;
                 string dc = address;



                 cmd.Parameters.AddWithValue("@username", tendangnhap);
                 if (matkhau == xacnhan)
                 {
                     cmd.Parameters.AddWithValue("@password", xacnhan);
                 }
                 else
                 {
                     return "Sai pass";
                 }
                 cmd.Parameters.AddWithValue("@name", ten);

                 cmd.Parameters.AddWithValue("@gender", gioitinh);*/

        //if (rbtnMale.Checked == true)
        //{
        //    cmd.Parameters.AddWithValue("@gender", rbtnMale.Text);
        //}
        //else
        //{
        //    cmd.Parameters.AddWithValue("@gender", rbtnFemale.Text);
        //}

        /*cmd.Parameters.AddWithValue("@phone", sdt);
        cmd.Parameters.AddWithValue("@address", dc);

        conn.Open();

        int a = cmd.ExecuteNonQuery();
        if (a > 0)
        {
            return "1";
        }
        else
        {
            return "2";
        }
        conn.Close();

    }*/
    }
}
