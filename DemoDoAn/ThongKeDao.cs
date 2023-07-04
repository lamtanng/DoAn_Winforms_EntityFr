using DemoDoAn.FORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDoAn
{
    internal class ThongKeDao
    {
        DEMO_TTTA dbConn = new DEMO_TTTA();
        CopyData copy = new CopyData();
        //lay bang ghi danh
        public DataTable layBangGhiDanh()
        {
            //string sqlStr = string.Format("Select * From ACCOUNTS_STUDENT join HOCVIEN on ACCOUNTS_STUDENT.AccID_Stu = HOCVIEN.ACCID");
            var q = from accStu in dbConn.ACCOUNTS_STUDENT
                    join hv in dbConn.HOCVIENs on accStu.AccID_Stu equals hv.ACCID
                    select new { Student = accStu, HocVien = hv };
                    
            return copy.ConvertToDataTable(q.ToList());
        }

        //lay bang hoc phi
        public DataTable layBangHocPhi()
        {
            //string sqlStr = string.Format("Select * From BANGHOCPHI join HOCVIEN on BANGHOCPHI.HVID = HOCVIEN.HVID");
            var result = dbConn.BANGHOCPHIs
                    .Join(dbConn.HOCVIENs, banghocphi => banghocphi.HVID, hocvien => hocvien.HVID, (banghocphi, hocvien) => new { BangHocPhi = banghocphi, HocVien = hocvien })
                    .ToList();
            return copy.ConvertToDataTable (result);
        }

        //lay bang hoc tap
        public DataTable layBangHocTap()
        {
            //string sqlStr = string.Format("Select XepHang, BANGDIEM.HVID, HOTEN, BANGDIEM.MaLop, TenMon, DiemGiuaKy, DiemCuoiKy, DiemTB, BANGDIEM.TrangThai\r\nFrom BANGDIEM join HOCVIEN on BANGDIEM.HVID = HOCVIEN.HVID\r\n\t\t\tjoin LOPHOC on BANGDIEM.MaLop = LOPHOC.MaLop");
            var result = (from bangdiem in dbConn.BANGDIEMs
                          join hocvien in dbConn.HOCVIENs on bangdiem.HVID equals hocvien.HVID
                          join lophoc in dbConn.LOPHOCs on bangdiem.MaLop equals lophoc.MaLop
                          select new
                          {
                              bangdiem.XepHang,
                              bangdiem.HVID,
                              hocvien.HOTEN,
                              bangdiem.MaLop,
                              lophoc.TenMon,
                              bangdiem.DiemGiuaKy,
                              bangdiem.DiemCuoiKy,
                              bangdiem.DiemTB,
                              bangdiem.TrangThai
                          }).ToList();
            return copy.ConvertToDataTable(result);
        }

    }
}
