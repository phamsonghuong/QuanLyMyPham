﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMyPham
{
    public class TestLogin
    {
        public static string ktdangnhap(string user, string pass)
        {
            string u = "admin";
            string p = "abc@123";

            if ( user != u || pass != p || user == "" || pass == "" || 
                (user != u && pass != p) || (user == "" && pass == "") ||
                (user != u && pass == "") || (user == "" && pass != p) )
            {
                return "0";
            }
            else return "1";



            //if ((user == "") && (pass ==""))
            //{
            //    return ("1");
            //}
            //else
            //if (user == "" || pass == "")
            //{
            //    return ("2");
            //}
            //else
            //if (user != u || pass != p)
            //{
            //    return ("3");
            //}

            //else return "0";

        }
    }
}