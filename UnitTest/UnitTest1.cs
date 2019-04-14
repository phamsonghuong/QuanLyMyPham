using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using QuanLyMyPham;



namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        //1
        [TestMethod]
        public void TestNhapDungTaiKhoan()
        {
            string actual = TestLogin.ktdangnhap("admin", "abc@123");
            string expected = "1";

            Assert.AreEqual(expected, actual);
        }
        //2
        [TestMethod]
        public void TestUserDung_PassKoDung()
        {
            string actual = TestLogin.ktdangnhap("admin", "admin");
            string expected = "0";

            Assert.AreEqual(expected, actual);
        }
        //3
        [TestMethod]
        public void TestUserDung_KoNhapPass()
        {
            string actual = TestLogin.ktdangnhap("admin", "");
            string expected = "0";

            Assert.AreEqual(expected, actual);
        }
        //4
        [TestMethod]
        public void TestUserKoDung_PassDung()
        {
            string actual = TestLogin.ktdangnhap("ad", "abc@123");
            string expected = "0";

            Assert.AreEqual(expected, actual);
        }
        //5
        [TestMethod]
        public void TestUser_PassKoDung()
        {
            string actual = TestLogin.ktdangnhap("ad", "admin");
            string expected = "0";

            Assert.AreEqual(expected, actual);
        }
        //6
        [TestMethod]
        public void TestUserKoDung_KoNhapPass()
        {
            string actual = TestLogin.ktdangnhap("ad", "");
            string expected = "0";

            Assert.AreEqual(expected, actual);
        }
        //7
        [TestMethod]
        public void TestKoNhapUser_PassDung()
        {
            string actual = TestLogin.ktdangnhap("", "abc@123");
            string expected = "0";

            Assert.AreEqual(expected, actual);
        }
        //8
        [TestMethod]
        public void TestKoNhapUser_PassKoDung()
        {
            string actual = TestLogin.ktdangnhap("", "admin");
            string expected = "0";

            Assert.AreEqual(expected, actual);
        }
        //9
        [TestMethod]
        public void TestKoNhapUser_Pass()
        {
            string actual = TestLogin.ktdangnhap("", "");
            string expected = "0";

            Assert.AreEqual(expected, actual);
        }

    }
}
