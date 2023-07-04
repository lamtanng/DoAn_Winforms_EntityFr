using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDoAn
{
    internal class LopHocMoiDao
    {
        DBConnection dbConn = new DBConnection();
        public DataTable LayDanhSachLopMoi()
        {
            string sqlStr = string.Format("SELECT *FROM LOPHOCMOI");
            return dbConn.LayDanhSach(sqlStr);
        }
        public void ADDLopHocMoi(LopHocMoi lop)
        {
            string sqlStr = string.Format("INSERT INTO LOPHOCMOI(KhoaHoc,TenLop,HocPhi,TrangThai) VALUES ('{0}','{1}','{2}','{3}')",lop.KHOAHOC,lop.Tenlop,lop.Hocphi,lop.Transgthai);
            dbConn.ThucThi(sqlStr);
        }
    }
}
