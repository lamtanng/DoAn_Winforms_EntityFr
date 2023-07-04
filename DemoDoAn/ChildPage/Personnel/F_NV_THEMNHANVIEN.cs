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
    public partial class F_NV_THEMNHANVIEN : Form
    {
        NhanVienDao nvDao = new NhanVienDao();
        public F_NV_THEMNHANVIEN()
        {
            InitializeComponent();
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //them
        private void btn_HoanThanh_Click(object sender, EventArgs e)
        {

        }

        //check username
        private bool kiemTraTaiKhoan(string username)
        {
            DataTable dt_accID = new DataTable();
            dt_accID = nvDao.LayAccID(username);
            if (dt_accID.Rows.Count > 0)
            {
                //đôi icon check
                return false;
            }
            else
            {
                //đổi icon check//
                return true;
            }

        }

        //check pass
        private bool kiemTraPass(string pass, string re_pass)
        {
            return pass == re_pass;
        }

        //check thong tin rong
        private bool kiemTraThongTin(NhanVien nv, string rePass)
        {
            if (String.IsNullOrEmpty(nv.USERNAME) || String.IsNullOrEmpty(nv.PASSWORD) || String.IsNullOrEmpty(rePass) || String.IsNullOrEmpty(nv.HOTEN) || String.IsNullOrEmpty(nv.GIOITINH) || String.IsNullOrEmpty(nv.NGAYSINH.ToString()) || String.IsNullOrEmpty(nv.CMND) || String.IsNullOrEmpty(nv.SDT) || String.IsNullOrEmpty(nv.EMAIL) || String.IsNullOrEmpty(nv.DIACHI))
            { return false; }
            return true;
        }

    }
}
