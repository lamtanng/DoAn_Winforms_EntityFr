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
    public partial class F_STUDENT_THEMHOCVIEN : Form
    {
        HocSinhDao hvDao = new HocSinhDao();
        public F_STUDENT_THEMHOCVIEN()
        {
            InitializeComponent();
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_HoanThanh_Click(object sender, EventArgs e)
        {
            string accID = "";
            string username = txt_UserName.Text.ToString().Trim();
            string password = txt_Pass.Text.ToString().Trim();
            string re_password = txt_RePass.Text.ToString().Trim();
            string hvid = "";
            string hoten = txt_Ten.Text.ToString().Trim();
            string cmnd = txt_CCCD.Text.ToString().Trim();
            DateTime ngaysinh = dPTime_NgaySinh.Value;
            string gioitinh = txt_GioiTinh.Text.ToString().Trim();
            string sdt = txt_SDT.Text.ToString().Trim();
            string diachi = txt_DiaChi.Text.ToString().Trim();
            string email = txt_Email.Text.ToString().Trim();
            int tien = 0;
            HocSinh taiKhoanHV = new HocSinh(accID, username, password);
            HocSinh thongTinHV = new HocSinh(hvid, hoten, cmnd, gioitinh, ngaysinh, sdt, email, diachi, tien);
            //check thong tin rong
            if (kiemTraThongTin(taiKhoanHV, thongTinHV, re_password))
            {
                if (kiemTraPass(password, re_password))
                {
                    //check username tồn tại chưa
                    if (kiemTraTaiKhoan(username) == true)
                    {
                        //luu acc
                        hvDao.ThemAccout(username, password);

                        //lấy acc id
                        DataTable dt_accID = new DataTable();
                        dt_accID = hvDao.LayAccID(taiKhoanHV.USERNAME);
                        taiKhoanHV.ACCID = dt_accID.Rows[0][0].ToString();

                        //lưu thông tin với accID đó
                        hvDao.themHocVien(thongTinHV, taiKhoanHV.ACCID);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản đã tồn tại!");
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu không trùng nhau!");
                }
            }
            else
            {
                MessageBox.Show("Kiểm tra lại thông tin!");
            }
        }

        //check username
        private bool kiemTraTaiKhoan(string username)
        {
            DataTable dt_accID = new DataTable();
            dt_accID = hvDao.LayAccID(username);
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
        private bool kiemTraThongTin(HocSinh taiKhoanHV, HocSinh thongTinHV, string rePass)
        {
            if (String.IsNullOrEmpty(taiKhoanHV.USERNAME) || String.IsNullOrEmpty(taiKhoanHV.PASSWORD) || String.IsNullOrEmpty(rePass) || String.IsNullOrEmpty(thongTinHV.HOTEN) || String.IsNullOrEmpty(thongTinHV.GIOITINH) || String.IsNullOrEmpty(thongTinHV.NGAYSINH.ToString()) || String.IsNullOrEmpty(thongTinHV.CMND) || String.IsNullOrEmpty(thongTinHV.SDT) || String.IsNullOrEmpty(thongTinHV.EMAIL) || String.IsNullOrEmpty(thongTinHV.DIACHI))
            { return false; }
            return true;
        }


    }
}
