using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDoAn.ChildPage.Personnel
{
    public partial class F_NV_CAPNHAT : Form
    {
        NhanVienDao nvDao = new NhanVienDao();  
        NhanVien nv = new NhanVien();

        public F_NV_CAPNHAT()
        {
            InitializeComponent();
        }

        public F_NV_CAPNHAT(NhanVien nv)
        {
            InitializeComponent();
            this.nv = nv;
            hienThongTin();
        }

        //hien thong tin
        private void hienThongTin()
        {
            txt_Ma.Text = nv.NVID.ToString().Trim();
            txt_Ten.Text = nv.HOTEN.ToString().Trim();
            txt_GioiTinh.Text = nv.GIOITINH.ToString().Trim();
            dPTime_NgaySinh.Value = nv.NGAYSINH;
            txt_CCCD.Text = nv.CMND.ToString().Trim();
            txt_SDT.Text = nv.SDT.ToString().Trim();
            txt_Email.Text = nv.EMAIL.ToString().Trim();
            txt_DiaChi.Text = nv.DIACHI.ToString().Trim();
            txt_UserName.Text = nv.USERNAME.ToString().Trim();
        }

        //thoat
        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //cap nhat
        private void btn_HoanThanh_Click(object sender, EventArgs e)
        {
            NhanVien nvCapNhat = new NhanVien(txt_Ma.Text.ToString(), txt_Ten.Text.ToString(), txt_GioiTinh.Text.ToString(), dPTime_NgaySinh.Value, txt_DiaChi.Text.ToString(), txt_CCCD.Text.ToString(),  txt_SDT.Text.ToString(), txt_Email.Text.ToString(), nv.ACCID, nv.USERNAME, txt_Pass.Text.ToString().Trim() );
            //cap nhat tai khoan
            nvDao.capNhatTaiKhoan(nvCapNhat);
            //cap nhat thong tin
            nvDao.capNhatThongTin(nvCapNhat);
            this.Close();
        }
    }
}
