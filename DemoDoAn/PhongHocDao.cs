using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;

namespace DemoDoAn
{
    internal class PhongHocDao
    {
        DEMO_TTTA dbConn = new DEMO_TTTA();
        CopyData copy =new CopyData();

        //DBConnection db = null;
        public DataTable LayDanhSachPhong()
        {
            string sqlStr = string.Format("SELECT *FROM PHONGHOC");
            //return dbConn.LayDanhSach(sqlStr);
        }
        public DataTable TimKiem(string duLieu)
        {
            string sqlStr = string.Format("SELECT * FROM PHONGHOC WHERE CONCAT(Phong, TrangThai) like N'%{0}%'", duLieu);
            return dbConn.LayDanhSach(sqlStr);
        }
        //tao phong hoc
        public void TaoPhong(PhongHoc lop)
        {
            string sqlStr = string.Format("INSERT INTO PHONGHOC(Phong,TrangThai) VALUES ('{0}',N'{1}')", lop.PHONGHOC, lop.TRANGTHAI);
            dbConn.ThucThi(sqlStr);
        }

        //xoa phong
        public void Xoa(PhongHoc phong)
        {
            string sqlStr = string.Format("DELETE FROM PHONGHOC WHERE Phong = '{0}'", phong.PHONGHOC);
            dbConn.ThucThi(sqlStr);
        }

        //cap nhat
        public void capNhat(PhongHoc phong)
        {
            string sqlStr = string.Format("UPDATE PHONGHOC SET TrangThai = N'{0}' Where PHONG = '{1}'", Convert.ToInt32(phong.TRANGTHAI), phong.PHONGHOC);
            dbConn.ThucThi(sqlStr);
        }
    }
}
