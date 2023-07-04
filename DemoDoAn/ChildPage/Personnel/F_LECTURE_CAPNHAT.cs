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
    public partial class F_LECTURE_CAPNHAT : Form
    {
        GiaoVien gv = new GiaoVien();
        GiaoVienDao gvDao = new GiaoVienDao();
        public F_LECTURE_CAPNHAT()
        {
            InitializeComponent();
        }

        public F_LECTURE_CAPNHAT(GiaoVien gv)
        {
            InitializeComponent();
            this.gv = gv;
            hienThongTin();
        }

        //hien thong tin
        private void hienThongTin()
        {
            txt_Ma.Text = gv.GVID.ToString().Trim();
            txt_Ten.Text = gv.HOTEN.ToString().Trim();
            txt_GioiTinh.Text = gv.GIOITINH.ToString().Trim();
            dPTime_NgaySinh.Value = gv.NGAYSINH;
            txt_CCCD.Text = gv.CMND.ToString().Trim();
            txt_SDT.Text = gv.SDT.ToString().Trim();
            txt_Email.Text = gv.EMAIL.ToString().Trim();
            txt_DiaChi.Text = gv.DIACHI.ToString().Trim();
            txt_UserName.Text = gv.USERNAME.ToString().Trim();
        }

        //thoat
        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //cap nhat
        private void btn_HoanThanh_Click(object sender, EventArgs e)
        {
            GiaoVien gvCapNhat = new GiaoVien(txt_Ma.Text.ToString(), txt_Ten.Text.ToString(), txt_CCCD.Text.ToString(), dPTime_NgaySinh.Value, txt_GioiTinh.Text.ToString(), txt_SDT.Text.ToString(), txt_DiaChi.Text.ToString(), txt_Email.Text.ToString(), gv.ACCID,txt_UserName.Text.ToString(), txt_Pass.Text.ToString());
            gvDao.CapNhat(gvCapNhat);
            this.Close();
        }
    }
}
