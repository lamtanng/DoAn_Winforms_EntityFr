using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDoAn
{
    internal class LopHocDao
    {
        DBConnection dbConn = new DBConnection();

        //lay ds lop
        public DataTable LayDanhSachLop()
        {
            string sqlStr = string.Format("SELECT *FROM LOPHOC inner join KHOAHOC on LOPHOC.MaKH = KHOAHOC.MaKH");
            return dbConn.LayDanhSach(sqlStr);
        }

        //xep lop
        public void XepLop(LopHoc lop)
        {
            string sqlStr = string.Format("Update LOPHOC Set SoBuoiTrongTuan = '{0}', DiemTBQuaMon = '{1}', GiangVien = '{2}', SoHocVien = '{3}', NgayBatDau = '{4}', NgayKetThuc = '{5}', XacNhan = 0 Where MaLop = '{6}'",lop.SOBUOITRONGTUAN, 8.0, lop.GIANGVIEN, lop.SOHOCVIEN, lop.NGAYBATDAU, lop.NGAYKETTHUC, lop.MALOP  );
            dbConn.ThucThi(sqlStr);
        }

        //tao lop moi
        public void themLopHoc(LopHoc lop, string tengon)
        {
            string sqlStr = string.Format("INSERT INTO LOPHOC(MaKH, TenMon, TenMonGon, HocPhi) VALUES ('{0}', N'{1}', '{2}', '{3}')",
                                            lop.KHOAHOC, lop.TENLOP, tengon, lop.HOCPHI);
            dbConn.ThucThi(sqlStr);
        }

        //cap nhat thong tin lop hoc
        public void capNhatThongTinLop(LopHoc lop)
        {
            string sqlStr = string.Format("update LOPHOC Set SoBuoiTrongTuan = '{0}', GiangVien = '{1}', SoHocVien = '{2}', NgayBatDau ='{3}', NgayKetThuc = '{4}' where MaLop = '{5}'",
                                            lop.SOBUOITRONGTUAN, lop.GIANGVIEN, lop.SOHOCVIEN, lop.NGAYBATDAU, lop.NGAYKETTHUC, lop.MALOP);
             dbConn.ThucThi(sqlStr);
        }

        //lay gio hoc
        public DataTable gioHoc()
        {
            string sqlStr = string.Format("Select * From GIOHOC");
            return dbConn.LayDanhSach(sqlStr);
        }

        //lay phong hoc
        public DataTable phongHoc()
        {
            string sqlStr = string.Format("Select * From PHONGHOC");
            return dbConn.LayDanhSach(sqlStr);
        }

        //lay lich hoc
        public DataTable lichHocCacMon()
        {
            string sqlStr = string.Format("SELECT LICHHOC.MaLop, Thu, Ca, Phong, GiangVien as GvID FROM LICHHOC inner join LOPHOC on LICHHOC.MaLop = LOPHOC.MaLop");
            return dbConn.LayDanhSach(sqlStr);
        }

        //lay giang vien
        public DataTable giangVien()
        {
            string sqlStr = string.Format("Select GvID, HOTEN From GIANGVIEN");
            return dbConn.LayDanhSach(sqlStr);
        }

        //cap nhat trang thai đóng mở lớp
        public void capNhatTrangThai(string malop, int trangthai)
        {
            string sqlStr = string.Format("Update LOPHOC set TTMoLop = {0} Where MaLop = '{1}'", trangthai, malop);
            dbConn.ThucThi(sqlStr);
        }

        //xoa
        public void Xoa(string maLop)
        {
            string sqlStr = string.Format("delete from LOPHOC where MaLop = '{0}'", maLop);
            dbConn.ThucThi(sqlStr);
        }

        //tim kiem
        public DataTable TimKiem(string duLieu)
        {
            string sqlStr = string.Format("SELECT MaLop, TenMon, SoHocVien, HocPhi, NgayBatDau, NgayKetThuc, TrangThai FROM LOPHOC\n" +
                                        "Where CONCAT(MaLop, TenMon, SoHocVien, HocPhi, NgayBatDau, NgayKetThuc, TrangThai, GiangVien) like N'%{0}%'", duLieu);
            return dbConn.LayDanhSach(sqlStr);        
        }

        //capnhat giang vien day 
        public void capNhatGiangVienChoLop(string malop, string gvid)
        {
            string sqlStr = "";
            if (string.IsNullOrEmpty(gvid))
            {
                sqlStr = string.Format("Update LOPHOC set GiangVien = null Where MaLop = '{0}'", malop);
            }
            else
            {
                sqlStr = string.Format("Update LOPHOC set GiangVien = '{0}' Where MaLop = '{1}'", gvid, malop);
            }
            dbConn.ThucThi(sqlStr);
        }

    }
}

