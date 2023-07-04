using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace DemoDoAn
{
    internal class BangLuongDao
    {
        DBConnection dbConn = new DBConnection();
        public DataTable LayThongTinLuong()
        {
            string sqlStr = string.Format("WITH CTE AS (\r\n    SELECT *,\r\n        RANK() OVER (ORDER BY Tongluong DESC) AS XepHang\r\n    FROM BANGLUONG\r\n  \n)\r\nSELECT XepHang, ID, HOTEN, CHUCVU, Luong, LuongDay, PhuCap, TienThuong, TienBaoHiem, Tongluong, THANG\r\nFROM CTE\r\nORDER BY Tongluong DESC, XepHang;\r\n");
            return dbConn.LayDanhSach(sqlStr);


        }
        public DataTable taiBangLuong(string maLop)
        {
            string sqlStr = string.Format("WITH CTE AS (\r\n    SELECT *,\r\n        RANK() OVER (ORDER BY Tongluong DESC) AS XepHang\r\n    FROM BANGLUONG\r\n\t\r\n)\r\nSELECT XepHang, ID, HOTEN, CHUCVU, Luong, LuongDay, PhuCap, TienThuong, TienBaoHiem, Tongluong, THANG\r\nFROM CTE\r\nORDER BY Tongluong DESC, XepHang;", maLop);
            return dbConn.LayDanhSach(sqlStr);
        }

        public void LUULUONG(BangLuong a)
        {
            string sqlStr = string.Format("UPDATE BANGLUONG SET  Luong = {1}, PhuCap = {2}, TienThuong = {3}, TienBaoHiem = {4} ,  TONGLUONG = {1} + {2} + {3} - {4} + LuongDay WHERE ID = '{0}' AND THANG={5}  ", a.ID, a.LUONG, a.PHUCAP, a.TIENTHUONG, a.TIENBAOHIEM, a.THANGLUONG);
            dbConn.ThucThi(sqlStr);
        }

        public DataTable NhapLuong()
        {
            string sqlStr = string.Format("go INSERT INTO BANGLUONG (ID, HOTEN, LuongDay, PhuCap, TienThuong, TienBaoHiem) SELECT GIANGVIEN.GVID, GIANGVIEN.HOTEN, 0, 0, 0, 0 FROM GIANGVIEN, LOPHOC GROUP BY GIANGVIEN.GVID, GIANGVIEN.HOTEN" +
                " go UPDATE BANGLUONG SET LuongDay=LOPHOC.LUONG FROM BANGLUONG INNER JOIN LOPHOC ON BANGLUONG.ID = LOPHOC.GiangVien go" +
                " go INSERT INTO BANGLUONG (ID,HOTEN, Luong, PhuCap, TienThuong, TienBaoHiem)SELECT NVID,HOTEN, 5000000, 0, 0, 0 FROM NHANVIEN");
            return dbConn.LayDanhSach(sqlStr);
        }
        public DataTable TimKiem(string tengv)
        {

            string sqlStr = string.Format("select GvID ,HOTEN ,GIOITINH from GIAOVIEN where HOTEN like '%" + tengv + "%' ");
            //string sqlStr1 = string.Format("select GvID ,HOTEN ,GIOITINH from GIAOVIEN where HOTEN like '%" +  + "%' ");
            return dbConn.LayDanhSach(sqlStr);
        }
    }
}
