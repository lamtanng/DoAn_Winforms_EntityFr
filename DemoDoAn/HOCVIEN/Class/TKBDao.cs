using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDoAn.HOCVIEN.Class
{
    internal class TKBDao
    {
        DBConnection dbConn = new DBConnection();


        //load ds lop dang dạy cho giảng viên
        public DataTable loadDSLopDay(string gvid)
        {
            string sqlStr = string.Format("SELECT DISTINCT GvID, MaLop, Thu, Ca, Phong,GioBatDau, GioKetThuc, TenMon, TenMonGon " +
                                           "FROM THOIKHOABIEU WHERE GvID = '{0}' and TTMoLop = 1 and XacNhan = 1 order by TenMon", gvid);
            return dbConn.LayDanhSach(sqlStr);
        }

        //load ds lớp đã đăng kí
        public DataTable loadDSL(string hvID)
        {
            string sqlStr = string.Format("Select * from BANGHOCPHI Where HVID = '{0}'", hvID);
                return dbConn.LayDanhSach(sqlStr);
        }

        //lấy thời khóa biểu học
        public DataTable LayTKB(string hvID)
        {
            string sqlStr = string.Format("Select * From THOIKHOABIEU Where HVID = '{0}' and TTMoLop = 1 order by TenMon", hvID);
            return dbConn.LayDanhSach(sqlStr);
        }

        //update tinh trang hoc phi
        public void updTrangThaiHP(string malop, string hvid)
        {
            string sqlStr = string.Format("UPDATE DANHSACHLOP SET TrangThai = N'Hoàn thành' WHERE MaLop = '{0}' and HVID = '{1}'", malop, hvid);
            dbConn.ThucThi(sqlStr);
        }

        //lấy số dư tài khoản
        public DataTable LaySoDuTK(string hvid)
        {
            string thuocTinh = "TienTaiKhoan";
            string sqlStr = string.Format("select {0} from HOCVIEN Where HVID = '{1}'",thuocTinh, hvid);
            return dbConn.LayDanhSach(sqlStr);
        }

        //thanh toán tiền
        public void thanhToanTien(string hvid, string maLop, int soTien)
        {
            //add phieu thu moi
            string sqlStr = string.Format("INSERT INTO LICHSUTHUTIEN(HVID, MaLop, LoaiTien, SoTienDong, Ngay, Gio) VALUES ('{0}', '{1}', N'Học phí', {2}, '{3}', '{4}')",
                                          hvid, maLop, soTien, DateTime.Now, DateTime.Now );
            //cap nhat so du tai khoan
            string sqlStr2 = string.Format("Update HOCVIEN Set TienTaiKhoan = TienTaiKhoan - {0} Where HVID = '{1}'", soTien, hvid);
            dbConn.ThucThi(sqlStr);
            dbConn.ThucThi(sqlStr2);
        }
    }
}
