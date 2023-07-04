//using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DemoDoAn
{
    internal class GiaoVienDao
    {
        DEMO_TTTA dbConn = new DEMO_TTTA();
        CopyData copy = new CopyData();

        //lay ACCID
        public DataTable LayAccID(string userName)
        {
            //string sqlStr = string.Format("SELECT AccID_Tea FROM ACCOUNTS_TEACHER WHERE username = '{0}'", userName);
            var q = dbConn.ACCOUNTS_TEACHER
                    .Where(t => t.username == userName)
                    .Select(t => t.AccID_Tea).ToList();
            DataTable dt = new DataTable();
            dt = copy.ConvertToDataTable(q);
            return dt;
        }

        //gv xac nhan lop day 
        public void xacNhanDay(string malop, int xacnhan)
        {
            // string sqlStr = string.Format("Update LOPHOC set XacNhan = {0} Where MaLop = '{1}'",xacnhan, malop);
            var q = dbConn.LOPHOCs.Where(l => l.MaLop == malop).FirstOrDefault();
            if (q != null)
            {
                q.XacNhan = xacnhan;
                dbConn.SaveChanges();
            }
        }

        public DataTable LayThongTinGiaoVienVaLop(string gvID)
        {
            //string sqlStr = string.Format("SELECT * FROM GIANGVIEN join LOPHOC on  GiangVien.GvID = LOPHOC.GiangVien join KHOAHOC on KHOAHOC.MaKH = LOPHOC.MaKH WHERE  GvID='{0}'", gvID);
            DataTable dt = new DataTable();
            var result = dbConn.GIANGVIEN1s
                        .Join(dbConn.LOPHOCs, giangVien => giangVien.GvID, lopHoc => lopHoc.GiangVien, (giangVien, lopHoc) => new { GiangVien = giangVien, LopHoc = lopHoc })
                        .Join(dbConn.KHOAHOCs, lh => lh.LopHoc.MaKH, khoaHoc => khoaHoc.MaKH, (lh, khoaHoc) => new { GiangVien = lh.GiangVien, LopHoc = lh.LopHoc, KhoaHoc = khoaHoc })
                        .Where(lh => lh.GiangVien.GvID == gvID)
                        .Select(lh => new
                         {
                             GiangVien = lh.GiangVien,
                             LopHoc = lh.LopHoc,
                             KhoaHoc = lh.KhoaHoc
                         })
                        .ToList();


            copy.ConvertToDataTable(result);
            return dt;
        }
        public DataTable LayDanhSachGiaoVien()
        {
            //để sau này có đổi tên bảng dưới SQL thì chuyển cho nhanh
            //string bangTKGV = "ACCOUNTS_TEACHER";
            //string sqlStr = string.Format("SELECT *FROM GIANGVIEN left join {0} on GIANGVIEN.AccID = {1}.AccID_Tea", bangTKGV, bangTKGV);
            //return dbConn.LayDanhSach(sqlStr);
            DataTable dt = new DataTable();

            return dt;
        }
        public void Them(GiaoVien gv)
        {
            string sqlStr = string.Format("INSERT INTO GIANGVIEN(AccID, HOTEN, GIOITINH, NGAYSINH, DIACHI, SDT, CMND, EMAIL) VALUES ('{0}', N'{1}', N'{2}', '{3}', N'{4}', '{5}', '{6}','{7}')",
                                           gv.ACCID, gv.HOTEN, gv.GIOITINH, gv.NGAYSINH, gv.DIACHI, gv.SDT, gv.CMND, gv.EMAIL);
            //dbConn.ThucThi(sqlStr);
        }

        //them acc
        public void ThemAccout(string username, string password)
        {
            string sqlStr = string.Format("INSERT INTO ACCOUNTS_TEACHER(username, pass, NgayDK) VALUES ('{0}','{1}', '{2}')", username, password, DateTime.Now);
            //dbConn.ThucThi(sqlStr);
        }

        //xoa tai khoan
        public void xoaTaiKhoan(string accID)
        {
            string sqlStr = string.Format("delete ACCOUNTS_TEACHER where AccID_Tea = '{0}'", accID);
            //dbConn.ThucThi(sqlStr);
        }
        //xoa GV
        public void xoaThongTin(string GvID)
        {
            string sqlStr = string.Format("delete from GIANGVIEN where GvID ='{0}'", GvID);
            //dbConn.ThucThi(sqlStr);
        }

        //cap nhat thong tin + cap nhat tai khoan Giang Vien
        public void CapNhat(GiaoVien gv)
        {
            //cap nhat thong tin ca nhan
            string sqlStr = string.Format("UPDATE GIANGVIEN SET HOTEN = N'{0}', GIOITINH = N'{1}', NGAYSINH = '{2}', DIACHI = N'{3}', SDT = '{4}', CMND = '{5}', EMAIL = '{6}' WHERE GvID = '{7}'",
                                        gv.HOTEN, gv.GIOITINH, gv.NGAYSINH, gv.DIACHI, gv.SDT, gv.CMND, gv.EMAIL, gv.GVID);
            //cap nhat thong tin acc
            string sqlStr1 = string.Format("Update ACCOUNTS_TEACHER Set pass = '{0}' Where username = '{1}'", gv.PASSWORD, gv.USERNAME);
            //dbConn.ThucThi(sqlStr);
            //dbConn.ThucThi(sqlStr1);
        }

        //them bang luong
        public void ThemBangLuong(GiaoVien gv, int a)
        {
            string sqlStr = string.Format("INSERT INTO BANGLUONG (ID, HOTEN, CHUCVU, LuongDay, PhuCap, TienThuong, TienBaoHiem, THANG) VALUES ('{0}',N'{1}', N'Giáo viên' ,0, 0, 0, 0," + a + ");", gv.GVID, gv.HOTEN);
            //dbConn.ThucThi(sqlStr);
        }
    }
}
