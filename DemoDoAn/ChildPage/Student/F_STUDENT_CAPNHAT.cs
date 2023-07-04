using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDoAn.ChildPage.Student
{
    public partial class F_STUDENT_CAPNHAT : Form
    {
        HocSinhDao hvDao = new HocSinhDao();
        HocSinh hv = new HocSinh();
        public F_STUDENT_CAPNHAT()
        {
            InitializeComponent();
        }

        public F_STUDENT_CAPNHAT(HocSinh hv)
        {
            InitializeComponent();
            this.hv = hv;
            hienThongTin();
        }
        //hien thong tin
        private void hienThongTin()
        {
            txt_Ma.Text = hv.HSID.ToString().Trim();
            txt_Ten.Text = hv.HOTEN.ToString().Trim();
            txt_GioiTinh.Text = hv.GIOITINH.ToString().Trim();
            dPTime_NgaySinh.Value = hv.NGAYSINH;
            txt_CCCD.Text = hv.CMND.ToString().Trim();
            txt_SDT.Text = hv.SDT.ToString().Trim();
            txt_Email.Text = hv.EMAIL.ToString().Trim();
            txt_DiaChi.Text = hv.DIACHI.ToString().Trim();
            txt_UserName.Text = hv.USERNAME.ToString().Trim();
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_HoanThanh_Click(object sender, EventArgs e)
        {
            HocSinh taiKhoanHV = new HocSinh(hv.ACCID, hv.USERNAME, txt_Pass.Text.ToString().Trim());
            HocSinh thongTinHV = new HocSinh(txt_Ma.Text.ToString(), txt_Ten.Text.ToString(), txt_CCCD.Text.ToString(),  txt_GioiTinh.Text.ToString(), dPTime_NgaySinh.Value, txt_SDT.Text.ToString(),  txt_Email.Text.ToString(), txt_DiaChi.Text.ToString(), hv.TIEN);
            //cap nhat tai khoan
            hvDao.CapNhatTaiKhoan(taiKhoanHV);
            //cap nhat thong tin
            hvDao.CapNhatThongTin(thongTinHV);
            this.Close();
        }
    }
}
