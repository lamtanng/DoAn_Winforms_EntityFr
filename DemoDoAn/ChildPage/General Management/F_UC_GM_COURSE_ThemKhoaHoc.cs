using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDoAn.ChildPage.General_Management
{
    public partial class F_UC_GM_COURSE_ThemKhoaHoc : Form
    {
        KhoaHocDao khoahocDAO=new KhoaHocDao();
        public F_UC_GM_COURSE_ThemKhoaHoc()
        {
            InitializeComponent();
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region XuLiDoHoa
        bool isEmpty_Search = true;
        private void txt_TenPhongHoc_Click_1(object sender, EventArgs e)
        {
            if (isEmpty_Search == true)
            {
                txt_TennKhoaHoc.Text = String.Empty;
                txt_TennKhoaHoc.Font = new Font(txt_TennKhoaHoc.Font, FontStyle.Regular);
                //txt_TennKhoaHoc.ForeColor = Color.White;
                isEmpty_Search = false;
            }
        }
        #region hàm dùng chung 
        private void SelectBtn(FlowLayoutPanel fLPnl, Button btnFLPnl, Button btn, bool select)
        {
            fLPnl.Height = fLPnl.MinimumSize.Height;
            select_TrangThai = false;
            btnFLPnl.Text = btn.Text;
        }
        // show/hide list lựa chọn 
        bool select_TrangThai = false;
        private void ShowListChoss(FlowLayoutPanel fLPnl, Timer t, ref bool select)
        {
            if (select == false)
            {
                fLPnl.Height += 15;
                if (fLPnl.Height >= fLPnl.MaximumSize.Height)
                {
                    t.Stop();
                    select = true;
                }
            }
            else
            {
                fLPnl.Height -= 15;
                if (fLPnl.Height <= fLPnl.MinimumSize.Height)
                {
                    t.Stop();
                    select = false;
                }
            }
        }

        #endregion

        private void timer_LoadTrangThai_Tick(object sender, EventArgs e)
        {
            ShowListChoss(fLPnl_TrangThai, timer_LoadTrangThai, ref select_TrangThai);
        }

        private void btn_TrangThai_Click(object sender, EventArgs e)
        {
            timer_LoadTrangThai.Start();
        }

        private void btn_TT_DaDay_Click(object sender, EventArgs e)
        {
            SelectBtn(fLPnl_TrangThai, btn_TrangThai, btn_TT_DaDay, select_TrangThai);
        }

        private void btn_TT_HoatDong_Click(object sender, EventArgs e)
        {
            SelectBtn(fLPnl_TrangThai, btn_TrangThai, btn_TT_HoatDong, select_TrangThai);
        }

        #endregion


        private void btn_HoanThanh_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkTrangThai())
                {
                    KhoaHoc khoa = new KhoaHoc("", txt_TennKhoaHoc.Text, btn_TrangThai.Text);
                    khoahocDAO.Them(khoa);
                }
                else
                {
                    MessageBox.Show("Vui lòng kiểm tra lại thông tin!");
                }
            }
            catch
            {
                MessageBox.Show("Không hoàn thành!");
            }

        }
        //ktra trang thai
        private bool checkTrangThai()
        {
            if (btn_TrangThai.Text.ToString() != @"Hoạt Động" && btn_TrangThai.Text.ToString() != @"Đã Đầy")
                return false;
            return true;
        }

        private void pnl_LoaiPhieuChi_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
