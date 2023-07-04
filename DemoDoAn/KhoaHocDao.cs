using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDoAn
{
    internal class KhoaHocDao
    {
        DBConnection dbConn = new DBConnection();
        public DataTable LayKhoaHoc()
        {
            string sqlStr = string.Format("SELECT *FROM KHOAHOC");
            return dbConn.LayDanhSach(sqlStr);
        }
        public void Them(KhoaHoc kh)
        {
            string sqlStr = string.Format("INSERT INTO KHOAHOC( TenKH,TrangThai) VALUES (N'{0}', N'{1}')",kh.Tenkhoahoc, kh.Trangthai);
            dbConn.ThucThi(sqlStr);
        }
        public void Xoa(KhoaHoc kh)
        {
            string sqlStr = string.Format("DELETE FROM KHOAHOC WHERE MaKH = '{0}'", kh.Makhoahoc);
            dbConn.ThucThi(sqlStr);
        }
        public void CapNhat(KhoaHoc kh)
        {
            string sqlStr = string.Format("UPDATE KHOAHOC SET TenKH = N'{0}', TrangThaiKH = {1} WHERE MaKH = '{2}'", kh.Tenkhoahoc, Convert.ToInt32(kh.Trangthai), kh.Makhoahoc);
            dbConn.ThucThi(sqlStr);
        }
        public DataTable timKiem(string duLieu)
        {
            string sqlStr = string.Format("SELECT * FROM KHOAHOC WHERE CONCAT(MaKH, TenKH, TrangThai) like N'%{0}%'", duLieu);
            return dbConn.LayDanhSach(sqlStr);
        }
    }
}
