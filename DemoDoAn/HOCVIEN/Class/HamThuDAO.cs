using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDoAn.HOCVIEN.Class
{
    internal class HamThuDAO
    {
        DBConnection dbConn = new DBConnection();

        //

        //lưu thư xuống database
        public void Them(HamThu thu)
        {
            string sqlStr = string.Format("INSERT INTO HOPTHU(IDGui,IDNhan, ChucVu, TieuDe, Noidung, Ngay, Gio) VALUES \r\n('{0}','{1}', N'{2}' , N'{3}', N'{4}', '{5}', '{6}')",
                                          thu.IDGui, thu.IDNhan, thu.ChucVu, thu.Tieude, thu.Noidung,thu.Ngay , thu.Gio);
            dbConn.ThucThi(sqlStr);
        }

        

        //lấy thư gửi đến
        public DataTable LayThuDen(string IDNhan)
        {
            string sqlStr = string.Format("Select * From HOPTHU WHERE IDNhan = '{0}'", IDNhan);
            return dbConn.LayDanhSach(sqlStr);
        }

        //update đánh dấu\
        public void DanhDau(bool isDanhDau, string maThu)
        {
            string sqlStr = string.Format("Update HOPTHU Set DanhDau = '{0}' Where MaThu = '{1}'", isDanhDau.ToString(), maThu.ToString() );
            dbConn.ThucThi(sqlStr); 
        }

        //xoa thu
        public void xoaThu(string mathu)
        {
            string sqlStr = string.Format("delete HOPTHU where MaThu = '{0}'", mathu);
            dbConn.ThucThi(sqlStr);
        }
    }
}
