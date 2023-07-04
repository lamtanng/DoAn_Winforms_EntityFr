using DemoDoAn.HOCVIEN.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDoAn.HOCVIEN
{
    public partial class UC_DANGKILOP_CHILD : UserControl
    {
        int chucVu; // 0 la admin;  1 la hocvien;  2 la giao vien

        string STT, maLop, tenLop, giangVien, trangThai;
        DateTime ngayBD, ngayKT;

        LopHocDao lhDao = new LopHocDao();
        GiaoVienDao gvDao = new GiaoVienDao();
        DangKiLopDao dklDao = new DangKiLopDao();
        HocSinhDao hsDao = new HocSinhDao();    
        DanhSachLopDao dslDao = new DanhSachLopDao();
        PhieuThuDao ptDao = new PhieuThuDao();

        public event EventHandler DeleteClicked;

        

        public UC_DANGKILOP_CHILD()
        {
            InitializeComponent();
        }
        public UC_DANGKILOP_CHILD(string STT, string maLop, string tenLop, DateTime ngayBD, DateTime ngayKT, string giangVien, string trangThai, int chucVu)
        {
            InitializeComponent();
            this.STT = STT;
            this.maLop = maLop;
            this.tenLop = tenLop;
            this.ngayBD = ngayBD;
            this.ngayKT = ngayKT;
            this.giangVien = giangVien;
            this.trangThai = trangThai;
            this.chucVu = chucVu;
        }
        
        public int CHUCVU { get { return chucVu; } set {  chucVu = value; } }

        private void UC_DANGKILOP_CHILD_Load(object sender, EventArgs e)
        {
            btn_STT.Text = STT.ToString();
            btn_MaLop.Text = maLop.ToString();
            btn_TenLop.Text = tenLop.ToString();
            btn_NgayBatDau.Text = ngayBD.ToString("dd/MM/yyyy");
            btn_NgayKetThuc.Text = ngayKT.ToString("dd/MM/yyyy");
            btn_GiangVien.Text = giangVien.ToString();
            btn_TrangThai.Text = trangThai.ToString();
        }

        //xoa
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            
            EventHandler handler = DeleteClicked;
            if (handler != null)
            {
                DataTable dtINFO = new DataTable();
                dtINFO = hsDao.Lay_MSSV(Login.userName);
                string hvID = dtINFO.Rows[0]["ID"].ToString().Trim();
                if(chucVu == 1)//HV
                {
                    //xoa hv khoi lop
                    dslDao.xoaHocVien(btn_MaLop.Text.ToString(), hvID);
                    //cap nhat si so lop
                    dklDao.CapNhatSiSoLop();
                    //xoa lich su phieu thu
                    ptDao.xoaLichSuThu(hvID, btn_MaLop.Text.ToString());
                }
                else if(chucVu == 2)
                {
                    //xoa gv day lop
                    lhDao.capNhatGiangVienChoLop(maLop, null);
                    //cap nhat trang thai XacNhan
                    gvDao.xacNhanDay(maLop, 0);
                }
                
                handler(this, e);
            }
        }
    }
}
