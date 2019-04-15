using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using QuanLyMyPham;



namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        //Test Đăng nhập
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
        //Test Thêm NCC
        //1
        [TestMethod]
        public void TestThemNCC()
        {
            string actual = TestSupplier.ktThemNCC("3CE", "TP HCM", 022222222);
            string expected = "1";

            Assert.AreEqual(expected, actual);
        }
        //2
        [TestMethod]
        public void TestThemNCC1()
        {
            string actual = TestSupplier.ktThemNCC("ABC", "", 0);
            string expected = "1";

            Assert.AreEqual(expected, actual);
        }
        //3
        [TestMethod]
        public void TestThemNCC2()
        {
            string actual = TestSupplier.ktThemNCC("", "ABC", 0);
            string expected = "1";

            Assert.AreEqual(expected, actual);
        }
        //4
        [TestMethod]
        public void TestThemNCC3()
        {
            string actual = TestSupplier.ktThemNCC("", "", 0);
            string expected = "1";

            Assert.AreEqual(expected, actual);
        }
        //Test Thêm Sản phẩm
        //1
        [TestMethod]
        public void TestThemSanPham()
        {
            string actual = TestProduct.ktThemSanpham("Tẩy trang", 99000, 40, "Chai", "ABC");
            string expected = "1";

            Assert.AreEqual(expected, actual);
        }

        //2
        [TestMethod]
        public void TestThemSanPham1()
        {
            string actual = TestProduct.ktThemSanpham("", 99000, 40, "Chai", "ABC");
            string expected = "1";

            Assert.AreEqual(expected, actual);
        }
        //3
        [TestMethod]
        public void TestThemSanPham2()
        {
            string actual = TestProduct.ktThemSanpham("Tẩy trang", 99000, 40, "", "ABC");
            string expected = "1";

            Assert.AreEqual(expected, actual);
        }
        //4
        [TestMethod]
        public void TestThemSanPham3()
        {
            string actual = TestProduct.ktThemSanpham("Tẩy trang", 99000, 40, "Chai", "");
            string expected = "1";

            Assert.AreEqual(expected, actual);
        }
        //Test Thêm Tồn kho
        //1
        [TestMethod]
        public void TestThemSanPhamTonKho()
        {
            string actual = TestInventory.ktThemTonkho("Sữa rửa mặt", "chai", 3, "Lỗi nắp", "04/15/2019");
            string expected = "1";

            Assert.AreEqual(expected, actual);
        }
        //2
        [TestMethod]
        public void TestThemSanPhamTonKho1()
        {
            string actual = TestInventory.ktThemTonkho("", "", 3, "", "04/15/2019");
            string expected = "1";

            Assert.AreEqual(expected, actual);

        }
        //3
        [TestMethod]
        public void TestThemSanPhamTonKho2()
        {
            string actual = TestInventory.ktThemTonkho("", "", 3, "", "");
            string expected = "1";

            Assert.AreEqual(expected, actual);
        }
        //Test Thêm Hóa đơn
        //1
        [TestMethod]
        public void TestThemHoaDon()
        {
            string actual = TestBill.ktThemHoaDon("04/15/2019", "Hương", "Beauty Shop", "Son 3CE", 255000, 1, 255000);
            string expected = "1";

            Assert.AreEqual(expected, actual);
        }
        //2
        [TestMethod]
        public void TestThemHoaDon1()
        {
            string actual = TestBill.ktThemHoaDon("04/15/2019", "Chang", "Beauty Shop", "Son 3CE", 255000, 1, 255000);
            string expected = "1";

            Assert.AreEqual(expected, actual);
        }
        //3
        [TestMethod]
        public void TestThemHoaDon2()
        {
            string actual = TestBill.ktThemHoaDon("04/15/2019", "Chang", "", "", 255000, 1, 255000);
            string expected = "1";

            Assert.AreEqual(expected, actual);
        }
        //4
        [TestMethod]
        public void TestThemHoaDon3()
        {
            string actual = TestBill.ktThemHoaDon("", "", "", "", 255000, 1, 255000);
            string expected = "1";

            Assert.AreEqual(expected, actual);
        }


    }
}
