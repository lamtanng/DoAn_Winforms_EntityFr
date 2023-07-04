using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace DemoDoAn
{
    internal class LichHocDao
    {
        DBConnection dbConn = new DBConnection();
        //tai lich hoc
        public DataTable taiLichHoc()
        {
            string sqlStr = string.Format("Select * From LOPHOC left join LICHHOC on LICHHOC.MaLop = LOPHOC.MaLop " +
                                        "join KHOAHOC on KHOAHOC.MaKH = LOPHOC.MaKH Where TTMoLop = 1");
            return dbConn.LayDanhSach(sqlStr);
        }

        //xoa lich hoc
        public void xoaLichHoc(string maLop)
        {
            string sqlStr = string.Format("Delete LICHHOC Where MaLop = '{0}'", maLop);
            dbConn.ThucThi(sqlStr);
        }

        //xep lich hoc
        public void xepLichHoc(string maLop, string thu, string ca, string phong)
        {
            string sqlStr = string.Format("INSERT INTO LICHHOC(MaLop, Thu, Ca, Phong) VALUES ('{0}', '{1}', '{2}', '{3}')", maLop, thu, ca, phong);
            dbConn.ThucThi(sqlStr);
        }
    }
}
