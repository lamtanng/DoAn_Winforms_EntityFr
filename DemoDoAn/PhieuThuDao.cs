using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDoAn
{
    internal class PhieuThuDao
    {
        DBConnection dbConn = new DBConnection();
        
        //tai ds phieu thu
        public DataTable LayDanhSachPhieuThu()
        {
            string sqlStr = string.Format("select * from LICHSUTHUTIEN join HOCVIEN on LICHSUTHUTIEN.HVID = HOCVIEN.HVID");
            return dbConn.LayDanhSach(sqlStr);
        }

        //xoa lich su thu tien cua hoc vien
        public void xoaLichSuThu(string hvid, string maLop)
        {
            string sqlStr = string.Format("delete LICHSUTHUTIEN where HVID = '{0}' and MaLop ='{1}'", hvid, maLop);
            dbConn.ThucThi(sqlStr);
        }

        //load nguoi nop tien
        public DataTable loadNguoiNop(string hvid)
        {
            string sqlStr = string.Format("SELECT * FROM HOCVIEN WHERE HVID = '{0}'", hvid);
            return dbConn.LayDanhSach(sqlStr);
        }

        //load lop hoc da dang ky cua hoc vien
        public DataTable taiLopHoc(string hvid)
        {
            string sqlStr = string.Format("select *from LOPHOCDADANGKI Where HVID = '{0}'", hvid);
            return dbConn.LayDanhSach(sqlStr);
        }

        //tao phieu thu
        public void taoPhieuThu(PhieuThu pt)
        {
            string sqlStr = string.Format("INSERT INTO LICHSUTHUTIEN(HVID, MaLop, LoaiTien, SoTienDong, Ngay, Gio) VALUES\r\n('{0}', '{1}', N'{2}', {3}, '{4}', '{5}')",
                                        pt.HVID, pt.MALOP, pt.LOAIPT, pt.TONGTIEN, pt.NGAYTHU, pt.NGAYTHU);
            dbConn.ThucThi(sqlStr);
        }

        //xoa phieu thu
        public void xoaPhieuThu(string maPT)
        {
            string sqlStr = string.Format("Delete LICHSUTHUTIEN Where MaPT = '{0}'", maPT);
            dbConn.ThucThi(sqlStr);
        }
    }
}
