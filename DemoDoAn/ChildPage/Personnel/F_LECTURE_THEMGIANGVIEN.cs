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
    public partial class F_LECTURE_THEMGIANGVIEN : Form
    {
        GiaoVienDao gvDao = new GiaoVienDao();
        LoginDAO loginDAO = new LoginDAO();
        BangLuongDao luongDao = new BangLuongDao();
        HocSinhDao hsDao = new HocSinhDao();

        string ID;
        public F_LECTURE_THEMGIANGVIEN()
        {
            InitializeComponent();
            //layID();
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //lay ID user
        private void layID(string username)
        {
            DataTable dtID = new DataTable();
            dtID = hsDao.Lay_MSSV(username);
            ID = dtID.Rows[0]["ID"].ToString().Trim();
        }

        private void btn_HoanThanh_Click(object sender, EventArgs e)
        {
            string accID = "";
            string username = txt_UserName.Text.ToString().Trim();
            string password = txt_Pass.Text.ToString().Trim();
            string re_password = txt_RePass.Text.ToString().Trim();
            string gvid = "";
            string hoten = txt_Ten.Text.ToString().Trim();
            string cmnd = txt_CCCD.Text.ToString().Trim();
            DateTime ngaysinh = dPTime_NgaySinh.Value;
            string gioitinh = txt_GioiTinh.Text.ToString().Trim();
            string sdt = txt_SDT.Text.ToString().Trim();
            string diachi = txt_DiaChi.Text.ToString().Trim();
            string email = txt_Email.Text.ToString().Trim();
            GiaoVien gv = new GiaoVien(gvid, hoten, cmnd, ngaysinh, gioitinh, sdt, diachi, email, accID, username, password);
            //check thong tin rong
            if(kiemTraThongTin(gv, re_password))
            {
                if(kiemTraPass(password, re_password))
                {
                    //check username tồn tại chưa
                    if (kiemTraTaiKhoan(username) == true)
                    {
                        //luu acc
                        gvDao.ThemAccout(username, password);

                        //lấy acc id
                        DataTable dt_accID = new DataTable();
                        dt_accID = gvDao.LayAccID(username);
                        accID = dt_accID.Rows[0][0].ToString();

                        //lưu thông tin với accID đó
                        GiaoVien gv1 = new GiaoVien(gvid, hoten, cmnd, ngaysinh, gioitinh, sdt, diachi, email, accID, username, password);
                        gvDao.Them(gv1);
                        //luu thong tin vao bang luong
                        //GiaoVien gv = new GiaoVien(txt_UserName.Text, txt_Ten.Text);

                        //gvdao.Them(giaoVien);
                        layID(username);
                        gv.GVID = ID;
                        for (int i = 1; i <= 12; i++)
                        {
                            gvDao.ThemBangLuong(gv, i);
                        }
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
            dt_accID = gvDao.LayAccID(username);
            if(dt_accID.Rows.Count > 0 )
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
        private bool kiemTraThongTin(GiaoVien gv, string rePass)
        {
            if(String.IsNullOrEmpty(gv.USERNAME) || String.IsNullOrEmpty(gv.PASSWORD) || String.IsNullOrEmpty(rePass) || String.IsNullOrEmpty(gv.HOTEN) || String.IsNullOrEmpty(gv.GIOITINH) || String.IsNullOrEmpty(gv.NGAYSINH.ToString()) || String.IsNullOrEmpty(gv.CMND) || String.IsNullOrEmpty(gv.SDT) || String.IsNullOrEmpty(gv.EMAIL) || String.IsNullOrEmpty(gv.DIACHI))
            { return false; }
            return true;
        }

        private void pBox_CheckPass_Click(object sender, EventArgs e)
        {

        }
    }
}
