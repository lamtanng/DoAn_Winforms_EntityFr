using DemoDoAn.Custom_Control;
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
    public partial class F_TKB_THANHTOAN : Form
    {
        TKBDao tkbDao = new TKBDao();
        HocSinhDao hsDao = new HocSinhDao();
        DataTable dt = new DataTable("ThanhToan");

        string maKH, tenKH, maLH, tenLH, ID, hocPhi, conNo;

        public F_TKB_THANHTOAN()
        {
            InitializeComponent();
            taiThongTinThanhToan();
        }
        public F_TKB_THANHTOAN(string maKH, string tenKH, string maLH, string tenLH,string ID, string hocPhi, string conNo)
        {
            InitializeComponent();
            this.maKH = maKH;
            this.tenKH = tenKH;
            this.maLH = maLH;
            this.tenLH = tenLH;
            this.ID = ID;
            this.hocPhi = hocPhi;
            this.conNo = conNo;
            taiThongTinThanhToan();
            lbl_TaiKhoan.Text = taiSoDuTaiKhoan().ToString();
        }

        private void F_TKB_THANHTOAN_Load(object sender, EventArgs e)
        {
            taiThongTinThanhToan();
        }

        //exit
        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //thanh toan hoc phi
        private void btn_HoanThanh_Click(object sender, EventArgs e)
        {
            
           
            int soTienDong;

            if (int.TryParse(txt_TienDong.Text, out soTienDong) == true)
            {
                if (Convert.ToInt32(txt_TienDong.Text) > Convert.ToInt32(lbl_ConNo.Text.ToString()) || Convert.ToInt32(txt_TienDong.Text) > Convert.ToInt32(lbl_TaiKhoan.Text))
                {
                    MessageBox.Show("Vui lòng kiểm tra số dư tài khoản và học phí của bạn!");
                }
                else
                {
                    tkbDao.thanhToanTien(ID, maLH, soTienDong);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra số tiền thanh toán!");
            }


        }

        //tai so du
        private int taiSoDuTaiKhoan()
        {
            DataTable dtTaiKhoan = tkbDao.LaySoDuTK(ID);
            int soDu = 0;
            //tai khoan
            if (dtTaiKhoan.Rows.Count >= 0)
            {
                soDu = Convert.ToInt32(dtTaiKhoan.Rows[0]["TienTaiKhoan"].ToString());
                return soDu;
            }
            else
            {
                return soDu;
            }
        }

        //
        private void taiThongTinThanhToan()
        {
            lbl_KhoaHoc.Text = tenKH.ToString().Trim();
            lbl_LopHoc.Text = tenLH.ToString().Trim();
            lbl_ConNo.Text = conNo.ToString().Trim();   
            lbl_TienHP.Text = hocPhi.ToString().Trim();
            //dt = tkbDao.loadDSL(ID);
            //load combobox
            //loadCombobox(cbb_ChonKhoaHoc, dt, "TenKH", "TenMon");
            //loadCombobox(cbb_ChonLopHoc, dt, "TenMon", "MaLop");
        }


    }

}
