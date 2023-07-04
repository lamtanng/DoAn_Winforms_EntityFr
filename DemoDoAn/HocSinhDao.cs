using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DemoDoAn
{
    internal class HocSinhDao
    {
        DBConnection dbConn = new DBConnection();

        //lay ACCID
        public DataTable LayAccID(string userName)
        {
            //string thuocTinh = "AccID_Stu";
            string sqlStr = string.Format("SELECT * FROM FULL_THONGTIN Where USERNAME = '{0}'", userName);
            return dbConn.LayDanhSach(sqlStr);
        }

        //Lấy MSSV
        public DataTable Lay_MSSV(string username)
        {
            //string thuocTinh = "HVID";
            string sqlStr = string.Format("SELECT * FROM FULL_THONGTIN Where USERNAME = '{0}'", username);
            return dbConn.LayDanhSach(sqlStr);
        }

        //load thong tin ca nhan hoc vien
        public DataTable LoadThongTin(string AccID)
        {
            string sqlStr = string.Format("SELECT *FROM HOCVIEN WHERE HVID = '{0}'", AccID);
            return dbConn.LayDanhSach(sqlStr);
        }
        
        //tai bang diem các mon của hoc vien
        public DataTable taiBangDiem(string hvID)
        {
            string sqlStr = string.Format("Select BANGDIEM.MaLop, LOPHOC.TenMon, DiemGiuaKy, DiemCuoiKy, DiemTB, BANGDIEM.TTMoLop, BANGDIEM.XacNhan \r\nFrom BANGDIEM join LOPHOC on BANGDIEM.MaLop = LOPHOC.MaLop\r\n Where HVID = '{0}'", hvID);
            return dbConn.LayDanhSach(sqlStr);
        }

        //tim kiem
        public DataTable TimKiem(string tengv)
        {
            string sqlStr = string.Format("SELECT GvID ,HOTEN ,GIOITINH FROM GIAOVIEN where HOTEN like '%" + tengv +"%' ");
            return dbConn.LayDanhSach(sqlStr);
        }

        //lay ds hoc vien
        public DataTable LayDanhSachSinhVien()
        {
            string sqlStr = string.Format("Select * From HOCVIEN left join ACCOUNTS_STUDENT on HOCVIEN.AccID = ACCOUNTS_STUDENT.AccID_Stu");
            return dbConn.LayDanhSach(sqlStr);
        }

        //them acc
        public void ThemAccout(string username, string password)
        {
            string sqlStr = string.Format("INSERT INTO ACCOUNTS_STUDENT (username ,pass, NgayDK) VALUES ('{0}','{1}', '{2}')", username, password, DateTime.Now);
            dbConn.ThucThi(sqlStr);
        }

        //them hoc vien
        public void themHocVien(HocSinh hv, string accID)
        {
            string sqlStr = string.Format("INSERT INTO HOCVIEN(ACCID, HOTEN, GIOITINH, NGAYSINH, DIACHI, SDT, CMND, EMAIL, TienTaiKhoan) VALUES\r\n('{0}', N'{1}', N'{2}', '{3}', N'{4}', '{5}','{6}', '{7}', '{8}')",
                                        accID, hv.HOTEN, hv.GIOITINH, hv.NGAYSINH, hv.DIACHI, hv.SDT, hv.CMND, hv.EMAIL, hv.TIEN);
            dbConn.ThucThi(sqlStr);
        }

        //cap nhat thong tin hv
        public void CapNhatThongTin(HocSinh hs)
        {
            string sqlStr = string.Format("UPDATE HOCVIEN SET HOTEN = N'{0}', GIOITINH =N'{1}', NGAYSINH = '{2}', DIACHI = N'{3}', SDT = '{4}', CMND = '{5}', EMAIL = '{6}' WHERE HOCVIEN.HVID = '{7}'",
                                            hs.HOTEN, hs.GIOITINH, hs.NGAYSINH, hs.DIACHI, hs.SDT, hs.CMND, hs.EMAIL, hs.HSID);
            dbConn.ThucThi(sqlStr);
        }

        //cap nhat tai khoan hv
        public void CapNhatTaiKhoan(HocSinh hv)
        {
            string sqlStr = string.Format("Update ACCOUNTS_STUDENT Set pass = '{0}' Where username ='{1}'", hv.PASSWORD, hv.USERNAME);
            dbConn.ThucThi(sqlStr);
        }

        //xoa tai khoan\
        public void xoaTaiKhoan(string accID)
        {
            string sqlStr = string.Format("delete ACCOUNTS_STUDENT where AccID_Stu = '{0}'", accID);
            dbConn.ThucThi(sqlStr);
        }

        //xoa hoc vien
        public void Xoa()
        {
            string sqlStr = string.Format("update HocSinh set Diachi = '{0}' where Ten = '{1}'");
            dbConn.ThucThi(sqlStr);
        }
    }
}
