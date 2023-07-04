using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DemoDoAn
{
    internal class PhieuChiDao
    {
        DBConnection dbConn = new DBConnection();

        //load ds pc
        public DataTable taiDSPC()
        {
            string sqlStr = string.Format("SELECT MaPC, ID, CONCAT(GIANGVIEN.HOTEN, NHANVIEN.HOTEN, HOCVIEN.HOTEN) as HOTEN, LICHSUCHITIEN.ChucVu, LoaiTien, SoTien, Ngay, Gio\r\nFROM LICHSUCHITIEN left join GIANGVIEN on LICHSUCHITIEN.ID = GIANGVIEN.GvID\r\n\t\t\t\t\tleft join NHANVIEN on LICHSUCHITIEN.ID = NHANVIEN.NVID\r\n\t\t\t\t\tleft join HOCVIEN on LICHSUCHITIEN.ID = HOCVIEN.HVID");
            return dbConn.LayDanhSach(sqlStr);
        }

        //load ten nguoi nhan
        public DataTable loadNguoiNhan(string table, string cotMaSo, string maso)
        {
            string sqlStr = string.Format("SELECT * FROM {0} WHERE {1} = '{2}'", table, cotMaSo, maso);
            return dbConn.LayDanhSach(sqlStr);
        }

        //them phieu chi
        public void themPhieuChi(PhieuChi pc)
        {
            string sqlStr = string.Format("INSERT INTO LICHSUCHITIEN(ID, ChucVu, LoaiTien, SoTien, Ngay, Gio) VALUES('{0}', N'{1}', N'{2}', {3}, '{4}', '{5}')",
                                            pc.ID, pc.CHUCVU, pc.LOAITIEN, pc.TIEN, pc.NGAYGIO, pc.NGAYGIO);
            dbConn.ThucThi(sqlStr);
        }

        //xoa phieu chi
        public void xoaPhieuChi(string maPC)
        {
            string sqlStr = string.Format("delete LICHSUCHITIEN Where MaPC = '{0}'", maPC);
            dbConn.ThucThi(sqlStr);
        }
    }
}
