using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDoAn
{
    internal class DanhSachLopDao
    {
        //DBConnection dbConn = new DBConnection();

        DEMO_TTTA dbConn = new DEMO_TTTA();
        //them hoc vien vao lop
        public void themHocVienVaoLop(string maLop, string hvID)
        {
            //string sqlStr = string.Format("INSERT INTO DANHSACHLOP (MaLop, HVID, TrangThai) VALUES('{0}', '{1}', N'{2}') ", maLop, hvID, "Chưa hoàn thành");
            var dsLop = new DANHSACHLOP();
            {
                dsLop.MaLop = maLop;
                dsLop.HVID = hvID;
                dsLop.TrangThai = "Chưa hoàn thành";
            }
            dbConn.DANHSACHLOPs.Add(dsLop);
            dbConn.SaveChanges();
        }

        //xoa hoc vien khoi lop
        public void xoaHocVien(string maLop, string hvID)
        {
            //string sqlStr = string.Format("DELETE DANHSACHLOP Where MaLop = '{0}' and HVID = '{1}'", maLop, hvID);
            //dbConn.ThucThi(sqlStr);
            var dsLop = dbConn.DANHSACHLOPs.FirstOrDefault(d => d.MaLop == maLop && d.HVID == hvID);
            if (dsLop != null)
            {
                dbConn.DANHSACHLOPs.Remove(dsLop);
                dbConn.SaveChanges();
            }

        }
    }

}
